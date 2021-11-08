using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManagement : MonoBehaviour
{
	public static BuildManagement instance;

	public GameObject GokuTower;
	public GameObject GohanTower;

	private TurretBlueprint turretToBuild;
	private Node SelectedNode;

	public NodeUI nodeUI;

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
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void SelectNode(Node node)
	{
		if (SelectedNode == node)
		{
			DeselectNode();
			return;
		}

		SelectedNode = node;
		turretToBuild = null;

		nodeUI.setTarget(node);
	}

	public void DeselectNode()
	{
		SelectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
}
