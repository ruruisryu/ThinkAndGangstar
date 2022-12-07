using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Content_Buttons : MonoBehaviour
{
    public GameObject[] contentGO;
    public Button[] contentBtn;
    public Sprite[] contentOnSpr;
    public Sprite[] contentOffSpr;

    void Awake()
    {
        contentGO[0].SetActive(true);
        contentBtn[0].GetComponent<Image>().sprite = contentOnSpr[0];
        ActiveContent();
    }

    public void ActiveContent()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        if (go == null)
            go = contentBtn[0].gameObject;

        for (int i = 0; i < contentGO.Length; i++)
        {
            if (go == contentBtn[i].gameObject)
            {
                contentGO[i].SetActive(true);
                contentBtn[i].GetComponent<Image>().sprite = contentOnSpr[i];
            }
            else
            {
                contentGO[i].SetActive(false);
                contentBtn[i].GetComponent<Image>().sprite = contentOffSpr[i];
            }
        }
    }
}
