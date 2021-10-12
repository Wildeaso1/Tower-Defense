using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManagement : MonoBehaviour
{
	public static BuildManagement instance;

	public GameObject GokuTower;
	public GameObject SeccondTower;
	private TurretBlueprint turretToBuild;
	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}
	public bool CanBuild { get { return turretToBuild != null; } }

	public void BuildTurretOn(Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("No money!");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;
		GameObject turret = (GameObject)Instantiate(turretToBuild.Tower, node.GetBuildPosition(), Quaternion.identity);
		node.GokuTurret = turret; 

	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
	}
}
