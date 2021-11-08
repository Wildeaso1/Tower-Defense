using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
	BuildManagement buildManagement;
	public TurretBlueprint Goku;
	public TurretBlueprint Gohan;

	void Start()
	{
		buildManagement = BuildManagement.instance;
	}
	public void SelectGokuTurret()
	{
		Debug.Log("Goku purchased");
		buildManagement.SelectTurretToBuild(Goku);
	}
	public void SelectGohanTurret()
	{
		buildManagement.SelectTurretToBuild(Gohan);
	}
}
