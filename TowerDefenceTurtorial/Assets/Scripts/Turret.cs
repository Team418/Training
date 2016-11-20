using UnityEngine;

public class Turret : MonoBehaviour 
{
	[Header ("Characteristics")]

	public string enemyTag = "Enemy";
	public float fireRate = 1f;
	public float range = 15f;
	public float rotationSpeed = 4f;
	public float damage;


	[Header("Aiming")]

	public Transform rotateDirector;
	public float UPS;//Aiming updates per sesond

	[Header("Shooting")]
	public GameObject fireEffect;
	public Transform bulletSpawnPoint;
	public AudioSource ShootSound;

	[Header("Debugging. Read only")]
	public Transform target;

	private float fireCountDown = 0f;

	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 1f / UPS);//Проверять каждый фрейм бессмысленно, будем 10 раз в секунду, если реже, то некоторые башни примороженные
	}

	GameObject nearestEnemy = null;

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		nearestEnemy = null;
		float minimalDistance = Mathf.Infinity;
		foreach (GameObject enemy in enemies) 
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < minimalDistance) 
			{
				minimalDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && minimalDistance <= range) 
		{
			target = nearestEnemy.transform;
		} 
		else
			target = null;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	void Update()
	{
		if (target == null)
			return;
		//Далее - удержание прицела на враге с плавными доворотами
		Vector3 arrowToEnemy = target.position - this.transform.position;
		Quaternion a = Quaternion.LookRotation(arrowToEnemy);
		Vector3 rotation = Quaternion.Lerp(rotateDirector.rotation, a, Time.deltaTime * rotationSpeed).eulerAngles;//Плавный поворот
		rotateDirector.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (fireCountDown <= 0f) 
		{
			Shoot ();
			fireCountDown = 1f / fireRate;
		}
		fireCountDown -= Time.deltaTime;
	}

	void Shoot()
	{
		nearestEnemy.GetComponent<Enemy> ().RecieveDamage (damage);

		GameObject _fireEffect = (GameObject)Instantiate (fireEffect, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
		Destroy (_fireEffect, 0.3f);

		ShootSound.Play ();

	}
}
