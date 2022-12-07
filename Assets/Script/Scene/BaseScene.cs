using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType;

    // 초기화 함수
    protected virtual void Init() { }

    public abstract void Clear();

    protected void ChangeScene(Define.Scene nextScene)
    {
       switch (nextScene)
        {
            case Define.Scene.Intro:
                LoadingSceneManager.LoadScene("Intro_Scene"); 
                break;
            case Define.Scene.Main:
                LoadingSceneManager.LoadScene("Main_Scene");
                break;
            case Define.Scene.Game:
                LoadingSceneManager.LoadScene("New Scene");
                break;
            case Define.Scene.Shop:
                LoadingSceneManager.LoadScene("Shop_Scene");
                break;
            case Define.Scene.Achivement:
                LoadingSceneManager.LoadScene("Achivement_Scene");
                break;
        }
    }
}
