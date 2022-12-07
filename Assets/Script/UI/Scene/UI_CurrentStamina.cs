using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CurrentStamina : MonoBehaviour
{
    public Image[] staminas = new Image[5];

    void Start()
    {
        updateCurrentStaminaUI();
    }

    void Update()
    {
        updateCurrentStaminaUI();
    }

    public void updateCurrentStaminaUI()
    {
        int stamina = Manager.currentStamina;

        for ( int i = 0; i < staminas.Length; i++)
        {
            if (i < stamina)
                staminas[i].gameObject.SetActive(true);
            else
                staminas[i].gameObject.SetActive(false);
        }
    }
}
