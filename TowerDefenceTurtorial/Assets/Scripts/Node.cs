using UnityEngine;


public class Node : MonoBehaviour 
{
	[Header("Changable")]
	public Color preClickColor;
	public Color destroyColor;
	public Color upgradeColor;

	private Color defaultColor;
	private Renderer rend;

	private GameObject turret = null;

	void Start()
	{
		rend = GetComponent<Renderer>();
		defaultColor = rend.material.color;
	}

	void OnMouseUpAsButton()//Срабатывает, если нажате и отпускание кнопки произошли на одном объекте
	{
		if (turret != null) 
		{
			Debug.LogError ("Building error! " + this.name + " already has building on it!");
			return;
		}
		GameObject turretToBuild = BuildManager.Instance.getTurretToBuild();
		turret = (GameObject)Instantiate (turretToBuild, this.transform.position, this.transform.rotation);
		turret.transform.position += new Vector3 (0f, 0.5f, 0f);
		rend.material.color = upgradeColor;
	}

	void OnMouseEnter()
	{
		if (turret == null)
			rend.material.color = preClickColor;
		else
			rend.material.color = upgradeColor;
	}

	void OnMouseExit()
	{
		rend.material.color = defaultColor;
	}
}
