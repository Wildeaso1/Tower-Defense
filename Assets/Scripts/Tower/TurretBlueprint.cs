using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
	public GameObject Tower;
	public int cost;
	public GameObject UpgradedTower;
	public int upgradeCost;

	public int GetSellAmount()
	{
		return cost / 2;
	}

	public int GetUpgradeSellAmount()
	{
		return upgradeCost / 2;
	}
}
