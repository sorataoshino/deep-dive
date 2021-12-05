using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
	//public HUD HUD;

	PlayerController _controller;

	private void Start()
	{
		//HUD = HUD.GetComponent<HUD>();
		_controller = GetComponent<PlayerController>();
	}

	public void OnInteraction()
	{

	}

	#region OnTrigger
	private void OnTriggerEnter(Collider other)
	{

	}

	private void OnTriggerStay(Collider other)
	{

	}

	private void OnTriggerExit(Collider other)
	{

	}
	#endregion
}