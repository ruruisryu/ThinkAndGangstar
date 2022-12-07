using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class gameobjectBlink : MonoBehaviour
{
    public GameObject blinckGO;

    void Start()
    {
        StartCoroutine(BlinkGO());
    }

    public IEnumerator BlinkGO()
    {
        while(true)
        {
            blinckGO.SetActive(false);
            yield return new WaitForSeconds(.4f);
            blinckGO.SetActive(true);
            yield return new WaitForSeconds(.4f);
        }
    }
}
