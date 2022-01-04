using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
	[SerializeField] GameObject _ui;
	[SerializeField] GameObject _compass;

	GameObject _interactableObject;

	public void OnInteraction()
	{
		if (_interactableObject != null &&_interactableObject.tag == "Chest")
        {
			_compass.GetComponent<Compass>().RemoveCompassMark(_interactableObject.GetComponent<CompassMark>());
			_interactableObject.gameObject.SetActive(false);
			_interactableObject = null;
			_ui.GetComponent<UI>().InteractionPanelSetActive(false);

            if (LevelManager.Instance.Chests.Count == 0)
            {
				LevelManager.Instance.Won = true;
				GameManager.Instance.SetState(GameState.END);
            }
		}
	}

	public void Die()
    {
		LevelManager.Instance.Won = false;
		GameManager.Instance.SetState(GameState.END);
	}

	#region OnTrigger
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Chest"))
		{
			_interactableObject = other.gameObject;
			_ui.GetComponent<UI>().InteractionPanelSetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Chest"))
		{
			_interactableObject = null;
			_ui.GetComponent<UI>().InteractionPanelSetActive(false);
		}
	}
	#endregion
}