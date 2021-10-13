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
	public GameObject GokuTurret;
	[SerializeField] private Vector3 positionOffset;


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
		if (!buildManager.CanBuild)
		{
			return;
		}

		if (GokuTurret != null)
		{
			Debug.Log("Can't build here! Sorry bud!");
			return;
		}

		buildManager.BuildTurretOn(this);
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
