using UnityEngine;
using System.IO;
using System;

public class GameCooficients : MonoBehaviour 
{
	public static float[,] DmgCoofs;

	/*public static void InitDmgCoofs()//Unlock when ready
	{
		StreamReader sr = File.OpenText ("C:/Users/admin/Documents/TowerDefenceTurtorial/Assets/UnitsChars/DmgCoofs.chars");
		DmgCoofs = new float[TurretChars.Damage.Length, EnemieChars.Speed.Length];
		int n = TurretChars.Damage.Length;
		int m = EnemieChars.Speed.Length;

		for (int i = 1; i <= n; i++) 
		{
			string[] s = sr.ReadLine ().Split (' ');
			for (int j = 1; j <= m; j++) 
			{
				DmgCoofs [i, j] = Convert.ToSingle(s [j - 1]);
			}
		}

		sr.Close ();
	}*/

	void Update()
	{
		if (EnemieChars.DCReady && TurretChars.DCReady) 
		{
			//InitDmgCoofs ();
			EnemieChars.DCReady = false;
		}
	}
}
