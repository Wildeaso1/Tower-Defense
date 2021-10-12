using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
	BuildManagement buildManagement;
	public TurretBlueprint GokuTower;

	void Start()
	{
		buildManagement = BuildManagement.instance;
	}
	public void SelectGokuTurret()
	{
		Debug.Log("Goku purchased");
		buildManagement.SelectTurretToBuild(GokuTower);
	}
}
