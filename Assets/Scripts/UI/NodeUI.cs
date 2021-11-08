using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
	public GameObject ui;
	public Text UpgradeCostText;
	public Button UpgradeButton;
	public Text SellAmount;
	private Node target;

	public void setTarget(Node nodeTarget)
	{
		target = nodeTarget;

		transform.position = target.GetBuildPosition();

		if (!target.isUpgraded)
		{
			UpgradeCostText.text = "$ " + target.turretBlueprint.upgradeCost;
			UpgradeButton.interactable = true;
			SellAmount.text = "$ " + target.turretBlueprint.GetSellAmount();
		}
		else
		{
			UpgradeCostText.text = "Max";
			UpgradeButton.interactable = false;
			SellAmount.text = "$ " + target.turretBlueprint.GetUpgradeSellAmount();
		}


		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

	public void Upgrade()
	{
		target.UpgradeTurret();
		BuildManagement.instance.DeselectNode();
	}

	public void Sell()
	{
		target.SellTurret();
		BuildManagement.instance.DeselectNode();
	}
}
