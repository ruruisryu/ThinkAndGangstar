using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTile : MonoBehaviour
{
    public TileCycle tileCycle;
    public TileCycle_UI tileCycle_UI;   
    private int intInfo;

    private void Start()
    {
        tileCycle_UI = GameObject.Find("@SceneUI_Game").transform.Find("Current_TileCycle").gameObject.GetComponent<TileCycle_UI>();
        tileCycle = GetComponentInParent<TileCycle>();
    }

    public void UpdateInfo(string info)
    {
        if (gameObject.tag.Equals("FirstNumber"))
        {
            if (!tileCycle.isUpdated[0])
            {
                intInfo = int.Parse(info);
                tileCycle._firstNum = intInfo;
                tileCycle.isUpdated[0] = true;
                // UI Update
                UpdateUIText(0, info);
            }
        }
        else if (gameObject.tag.Equals("Symbol"))
        {
            if (!tileCycle.isUpdated[1])
            {
                tileCycle._symbol = info;
                tileCycle.isUpdated[1] = true;

                // UI Update
                UpdateUIText(1, info);
            }
        }
        else if (gameObject.tag.Equals("SecondNumber"))
        {
            if (!tileCycle.isUpdated[2])
            {
                intInfo = int.Parse(info);
                tileCycle._secondNum = intInfo;
                tileCycle.isUpdated[2] = true;

                // UI Update
                UpdateUIText(2, info);
            }
        }
        else if (gameObject.tag.Equals("Answer"))
        {
            if (!tileCycle.isUpdated[3])
            {
                intInfo = int.Parse(info);
                tileCycle._answer = intInfo;
                tileCycle.isUpdated[3] = true;



                // UI Update
                UpdateUIText(3, info);

                tileCycle.CheckAnswer(tileCycle.tileinfo);
            }
        }
    }

    private void UpdateUIText(int index, string info)
    {
        if (tileCycle.tcType == Define.TileCylcle.AnswerFixed)
        {
            if (index == 3) return;
            tileCycle_UI._tileSet[index].transform.GetChild(0).gameObject.SetActive(false);
            tileCycle_UI._tileSet[index].transform.GetChild(1).gameObject.SetActive(true);
            tileCycle_UI._tileSet[index].transform.GetChild(1).GetComponent<TileText_UI>().SetText(info);
        }
        else if (tileCycle.tcType == Define.TileCylcle.SymbolFixed)
        {
            if (index == 1) return;
            tileCycle_UI._tileSet[index+4].transform.GetChild(0).gameObject.SetActive(false);
            tileCycle_UI._tileSet[index+4].transform.GetChild(1).gameObject.SetActive(true);
            tileCycle_UI._tileSet[index+4].transform.GetChild(1).GetComponent<TileText_UI>().SetText(info);
        }
    }
}
