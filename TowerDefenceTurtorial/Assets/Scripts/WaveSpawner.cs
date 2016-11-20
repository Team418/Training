using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
	[Header("Parameters")]
	public float timeBetweenWaves;
	public Transform spawnPoint;
	public Text countDownText;
	public GameObject groundEnemyPrefab;
	public GameObject airEnemyPrefab;

	[Header("Debugging. Read only")]
	public int waveIndex = 0;
	public float countDown = 6f;

	void Update()
	{
		if (countDown <= 0f) 
		{
			StartCoroutine (SpawnWave ());
			countDown = timeBetweenWaves;
		}
		countDown -= Time.deltaTime;
		countDownText.text = Mathf.Round (countDown).ToString();
	}

	IEnumerator SpawnWave()
	{
		waveIndex++;
		Debug.Log ("Wave #" + waveIndex + " is coming!");

		for (int i = 1; i <= waveIndex; i++) 
		{
			SpawnEnemy ();
			yield return new WaitForSeconds (0.3f);
		}
	}

	void SpawnEnemy()
	{
		Instantiate (groundEnemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}
}
