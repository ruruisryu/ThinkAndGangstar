using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : UI_Popup
{
    public GameObject[] tutorialGO;
    public TutorialPannel[] tutorialPannels;
    public TutorialSO[] tutorialSO;

    public Button leftBtn;
    public Button rightBtn;

    public Sprite nextSprite;
    public Sprite destroySprite;
    

    static int currentTutorialPannel;

    void Start()
    {
        LoadPanels();
        currentTutorialPannel = 0;
        leftBtn.interactable = false;
    }

    void Update()
    {
        checkbtn();
    }

    public void LoadPanels()
    {
        for (int i = 0; i < tutorialSO.Length; i++)
        {
            tutorialPannels[i].TutorialInfo.text = tutorialSO[i].TutorialTxt;
        }
    }

    public void LeftBtn()
    {
        if(currentTutorialPannel == 0)
        {
            leftBtn.interactable = false;
        }
        else
        {
            currentTutorialPannel--;
            for (int i = 0; i < tutorialSO.Length; i++)
            {
                if (i == currentTutorialPannel)
                    tutorialGO[i].SetActive(true);
                else
                {
                    tutorialGO[i].SetActive(false);
                }
            }
        }
    }

    public void RightBtn()
    {
        if(currentTutorialPannel == 3)
        {
            Destroy(gameObject);
            Manager.Instance.ContinueGame();
        }
        else
        {
            currentTutorialPannel++;
            for (int i = 0; i < tutorialSO.Length; i++)
            {
                if (i == currentTutorialPannel)
                    tutorialGO[i].SetActive(true);
                else
                {
                    tutorialGO[i].SetActive(false);
                }
            }
        }
    }

    public void checkbtn()
    {
        if(currentTutorialPannel == 0)
        {
            leftBtn.interactable = false;
        }
        else
        {
            leftBtn.interactable = true;
        }

        if(currentTutorialPannel == 3)
        {
            rightBtn.GetComponent<Image>().sprite = destroySprite;
        }
        else
        {
            rightBtn.GetComponent<Image>().sprite = nextSprite;
        }
    }
}
