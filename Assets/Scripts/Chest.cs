using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Animator))]
public class Chest : MonoBehaviour
{
    public void Open()
    {
        GetComponent<Animator>().SetTrigger("open");
        GetComponent<AudioSource>().Play();
        StartCoroutine(RemoveChest());
    }

    IEnumerator RemoveChest()
    {
        yield return new WaitForSeconds(2);
        transform.localScale = new Vector3(0, 0, 0);
    }
}
