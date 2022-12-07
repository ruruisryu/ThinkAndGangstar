using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupAchieve : MonoBehaviour
{
    public AudioClip buttonClk;

    public void PopupAchieve()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(buttonClk);

        GameObject go = Resources.Load<GameObject>("Prefabs/UI/Popup/UI_Achievement");
        Instantiate(go);
    }
}
