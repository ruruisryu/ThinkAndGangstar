using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainScene : BaseScene
{
    public override void Clear()
    {

    }

    private void Awake()
    {
        SceneType = Define.Scene.Main;
    }

    public void MoveToShop()
    {
        ChangeScene(Define.Scene.Shop);
    }

    public void MoveToGame()
    {
        ChangeScene(Define.Scene.Game);
    }

    public void MoveToAchivement()
    {
        ChangeScene(Define.Scene.Achivement);
    }
}
