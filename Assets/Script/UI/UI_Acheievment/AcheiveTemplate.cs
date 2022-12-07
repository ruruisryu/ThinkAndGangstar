using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AcheiveTemplate : MonoBehaviour
{
    GemState gemState = new GemState();

    public TextMeshProUGUI acheiveInform;
    public TextMeshProUGUI award;

    [SerializeField]
    Button completeButton;

    [SerializeField]
    AchieveItemSO achieveSO;

    private void Start()
    {
        if (achieveSO.isCompleted)
            completeButton.interactable = true;
    }

    public void CompleteAchieve()
    {
        if(completeButton.IsActive())
        {
            {
                if (!achieveSO.isCompleted)
                    return;
                if (achieveSO.isGained)
                    return;

                GemState gemState = new GemState();
                int saveGem = Convert.ToInt32(achieveSO.award);
                gemState.SaveGem(saveGem);

                achieveSO.isGained = true;
            }
        }
    }
}
