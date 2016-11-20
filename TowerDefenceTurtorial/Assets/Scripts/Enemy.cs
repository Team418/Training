using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	[Header("Debugging. Read only")]
	public Transform target;
	public int WayPointIndex = 0;
	public float speed;
	public float HP;

	[Header("Parameters")]
	public string type;//TODO
	/*
		Должен узнавать свой тип от Wavespawner
		Подумать, возможно сделать через метод sting{return type}
    */

	void Start()
	{
		target = Waypoints.points [0];
		HP = EnemieChars.HP[EnemieChars.NumberOfType("Standart_Unit_No_1")];
		speed = EnemieChars.Speed[EnemieChars.NumberOfType("Standart_Unit_No_1")];
	}

	void Update()
	{
		if (HP <= 0f) 
		{
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.transform.position - this.transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime);

		if (Vector3.Distance (this.transform.position, target.transform.position) <= 0.2f)
			GetNextWayPoint ();
	}

	void GetNextWayPoint()
	{
		if (WayPointIndex >= Waypoints.points.Length - 1) 
		{
			Destroy (gameObject);
			return;
		}
		WayPointIndex++;
		target = Waypoints.points [WayPointIndex];
	}

	public void RecieveDamage(float dmg)
	{
		HP -= dmg;
	}
}
