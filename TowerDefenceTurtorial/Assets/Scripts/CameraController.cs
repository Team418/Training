using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [Header("Parameters")]
	public float moveSpeed;

    [Header("Debugging. Read only!")]
	public bool ableToMove = true;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			ableToMove = !ableToMove;

		if (!ableToMove)
			return;

		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - 10f) 
		{
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("s") || Input.mousePosition.y <= 10f) 
		{
			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - 10f) 
		{
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("a") || Input.mousePosition.x <= 10f) 
		{
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime, Space.World);
		}

	}
}
