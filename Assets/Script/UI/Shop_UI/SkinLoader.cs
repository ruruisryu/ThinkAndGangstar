using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public GameObject[] SkinMain;
    public GameObject[] SkinGame;

    private void Awake()
    {
        CostumeState costume = new CostumeState();
        string costumeData = costume.LoadCostume();
        if (costumeData == null)
            costume.SaveCostume("Costume_Think");

        Define.Scene currentScene = GameObject.Find("@Scene").GetComponent<BaseScene>().SceneType;

        switch (currentScene)
        {
            case Define.Scene.Main:
                if (costumeData != null)
                {
                    CheckCostume(costumeData, ref SkinMain);
                }
                break;
            case Define.Scene.Game:
                if (costumeData != null)
                {
                    CheckCostume(costumeData, ref SkinGame);
                }
                break;
        }
    }

    public void CheckCostume(string skinToLoad, ref GameObject[] skinArray)
    {
        if (skinToLoad == null)
        {
            skinArray[0].SetActive(true);
            skinArray[1].SetActive(false);
            skinArray[2].SetActive(false);

        }

        switch (skinToLoad)
        {
            case "Costume_Think":
                skinArray[0].SetActive(true);
                skinArray[1].SetActive(false);
                skinArray[2].SetActive(false);
                break;

            case "Costume_Cowboy":
                skinArray[0].SetActive(false);
                skinArray[1].SetActive(true);
                skinArray[2].SetActive(false);
                break;

            case "Costume_Bee":
                skinArray[0].SetActive(false);
                skinArray[1].SetActive(false);
                skinArray[2].SetActive(true);
                break;
        }
    }
}
