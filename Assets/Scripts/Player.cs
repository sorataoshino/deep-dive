using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
	[SerializeField] GameObject _interactionPanel;
	GameObject _interactableObject;

	public void OnInteraction()
	{
        if (_interactableObject != null)
        {
			_interactableObject.GetComponent<Chest>().Open();
			GameManager.Instance.ChestOpened(_interactableObject);
			_interactableObject = null;
        }
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
		if (hit.transform.CompareTag("Box"))
		{
			hit.transform.GetComponent<Rigidbody>().AddForce(transform.position, ForceMode.Force);
		}
	}
    #endregion
}