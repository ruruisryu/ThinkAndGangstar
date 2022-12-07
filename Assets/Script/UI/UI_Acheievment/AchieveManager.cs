using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class AchieveManager : MonoBehaviour
{
    public AchieveItemSO[] achieve_ItemSO;
    public AcheiveTemplate[] acheivePanels;
    public GameObject[] achieve_PanelsGO;
    public Button[] getAwardBtns;

    public Sprite DoneSprite;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < achieve_ItemSO.Length; i++)
            achieve_PanelsGO[i].SetActive(true);

        LoadPanels();
        CheckAcheivable();
        CheckGainable();
    }

    private void Update()
    {
        CheckGainable();
        CheckAcheivable();
    }

    public void LoadPanels()
    {
        for(int i =0; i < achieve_ItemSO.Length; i++ )
        {
            acheivePanels[i].acheiveInform.text = achieve_ItemSO[i].achieveInform;
            acheivePanels[i].award.text = achieve_ItemSO[i].award;
        }
    }

    public void CheckAcheivable()
    {
        for(int i =0; i < achieve_ItemSO.Length; i++)
        {
            if (achieve_ItemSO[i].isCompleted)
                getAwardBtns[i].interactable = true;
            else
                getAwardBtns[i].interactable = false;
        }
    }

    public void CheckGainable()
    {
        for(int i=0; i <achieve_ItemSO.Length; i++)
        {
            if (achieve_ItemSO[i].isGained)
            {
                getAwardBtns[i].interactable = false;
                getAwardBtns[i].GetComponent<Image>().sprite = DoneSprite;
            }
        }
    }
}
