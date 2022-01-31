using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public AudioSource won;
    public AudioSource lost;

    // Start is called before the first frame update
    void Start()
    {
        if (EndScreenInfo.won == true)
        {
            text.text = "You Won!";
            won.Play();
        }
        else
        {
            text.text = "You Died :(";
            lost.Play();
        }
    }
}
