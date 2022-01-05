using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
	[SerializeField] GameObject _interactionPanel;
	GameObject _interactableObject;

	public void OnInteraction()
	{
		GameManager.Instance.ChestOpened(_interactableObject);
	}

	#region OnTrigger
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Chest"))
		{
			_interactableObject = other.gameObject;
			_interactionPanel.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Chest"))
		{
			_interactableObject = null;
			_interactionPanel.SetActive(false);
		}
	}
	#endregion
}