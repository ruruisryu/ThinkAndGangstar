using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Shop_Manager : UI_Base
{
    protected GemState gemstate = new GemState();

    public TMP_Text gemUI;
    public Shop_ItemSO[] shop_ItemSO;
    public GameObject[] shop_PanelsGO;
    public Shop_Template[] shopPanels;

    public Button[] myPurchaseBtns;
    public Button[] myEquipBtn;
    public Sprite btn_sprite;

    public sObject isPurchased;
    public static bool[] isPurchasedBool = new bool[3];

    private void Start()
    {
        ScriptObject scriptObject = new ScriptObject();
        isPurchased = scriptObject.LoadObjectCount();

        /**
        if (isPurchased == null)
            scriptObject.SaveSObjectCount(true, false, false);

        isPurchased = scriptObject.LoadObjectCount();
        **/

        isPurchasedBool[0] = isPurchased.sobject1;
        isPurchasedBool[1] = isPurchased.sobject2;
        isPurchasedBool[2] = isPurchased.sobject3;

        Init();
    }

    public override void Init()
    {
        gemUI.text = $"{gemstate.Load()}";

        // 판매 스킨 띄우기
        for (int i= 0; i< shop_ItemSO.Length; i++)
            shop_PanelsGO[i].SetActive(true);
        LoadPanels();

        CheckPurchaseable();
        CheckEquipable();
    }

    public void LoadPanels()
    {
        for ( int i=0; i < shop_ItemSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shop_ItemSO[i].title;
            shopPanels[i].costTxt.text = shop_ItemSO[i].baseCost.ToString();    
        }
    }

    public void CheckPurchaseable()
    {
        int Gems = gemstate.Load();

        for (int i= 0; i < isPurchasedBool.Length; i++)
        {
            if (!(shop_ItemSO[i].isSelling))
            {
                myPurchaseBtns[i].interactable = false;
                myPurchaseBtns[i].transform.GetChild(0).gameObject.SetActive(false);
                continue;
            }    

            if (isPurchasedBool[i])
            {
                myPurchaseBtns[i].interactable = false;
                myPurchaseBtns[i].transform.GetChild(0).gameObject.SetActive(false);
                myPurchaseBtns[i].GetComponent<Image>().sprite = btn_sprite;
                continue;
            }

            if (Gems < shop_ItemSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = false;
                continue;
            }

            myPurchaseBtns[i].interactable = true;
        }
    }

    public void CheckEquipable()
    {
        for (int i = 0; i <  isPurchasedBool.Length; i++)
        {
            if ((isPurchasedBool[i]))
            {
                myEquipBtn[i].interactable = true;
                continue;
            }
            myEquipBtn[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNum)
    {
        int Gems = gemstate.Load();

        if (Gems >= shop_ItemSO[btnNum].baseCost)
        {
            gemstate.SaveGem(-shop_ItemSO[btnNum].baseCost);
            gemUI.text = $"{gemstate.Load()}";

            bool[] ispurchased = new bool[3];

            ScriptObject scriptObject = new ScriptObject();
            sObject purSObject = scriptObject.LoadObjectCount();

            ispurchased[0] = purSObject.sobject1;
            ispurchased[1] = purSObject.sobject2;
            ispurchased[2] = purSObject.sobject3;

            ispurchased[btnNum] = true;

            scriptObject.SaveSObjectCount(ispurchased[0], ispurchased[1], ispurchased[2]);
            isPurchasedBool = ispurchased;

            CheckPurchaseable();
            CheckEquipable();
        }
    }

    void checksObject(sObject isPurchased)
    {

    }
}
