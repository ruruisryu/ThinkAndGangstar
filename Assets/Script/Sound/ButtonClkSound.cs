using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClkSound : MonoBehaviour
{
    public AudioClip ButtonClk;

    public void BtnClkSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(ButtonClk);
    }
}
