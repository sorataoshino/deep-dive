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
    }
}
