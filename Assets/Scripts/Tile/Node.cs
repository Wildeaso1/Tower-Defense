using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	[Header("Color Attributes")]
	[SerializeField] private Color hoverColor;
	[SerializeField] private Color unableToBuyColor;
	private Renderer rend;
	private Color startColor;

	[Header("Turret Attributes")]
	public GameObject Tower;
	[SerializeField] private Vector3 positionOffset;

	public TurretBlueprint turretBlueprint;
	public bool isUpgraded = false;


	BuildManagement buildManager;


	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		buildManager = BuildManagement.instance;
	}

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		if (!buildManager.CanBuild)
		{
			return;
		}

		if (Tower != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("No money!");
			return;
		}

		turretBlueprint = blueprint;

		PlayerStats.Money -= blueprint.cost;
		GameObject turret = (GameObject)Instantiate(blueprint.Tower, GetBuildPosition(), Quaternion.identity);
		Tower = turret;

	}

	public void UpgradeTurret()
	{
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("No money!");
			return;
		}

		Destroy(Tower);

		PlayerStats.Money -= turretBlueprint.upgradeCost;
		GameObject turret = (GameObject)Instantiate(turretBlueprint.UpgradedTower, GetBuildPosition(), Quaternion.identity);
		Tower = turret;

		isUpgraded = true;

	}

	public void SellTurret()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		Destroy(Tower);
	}

	//Zorgt voor de color change
	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		if (!buildManager.CanBuild)
		{
			return;
		}
		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = unableToBuyColor;
		}

	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
