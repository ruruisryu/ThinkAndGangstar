using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBtn : MonoBehaviour
{
    public GameObject testPanel;
    private bool isOpen = false;
    public void ShowBtns()
    {
        if (isOpen)
        {
            testPanel.SetActive(false);
            isOpen = false;
        }
        else
        {
            testPanel.SetActive(true);
            isOpen = true;
        }
    }
}
