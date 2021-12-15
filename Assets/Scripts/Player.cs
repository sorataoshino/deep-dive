using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
	public UI UI;

	PlayerController _controller;

	private void Start()
	{
		UI = UI.GetComponent<UI>();
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