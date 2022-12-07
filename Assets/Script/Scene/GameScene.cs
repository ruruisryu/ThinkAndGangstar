using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override void Clear()
    {
        // TODO
        // Scene이 종료되었을 때 Scene을 날려주는 부분
    }

    private void Awake()
    {
        SceneType = Define.Scene.Game;
    }

    public void MoveToMain()
    {
        ChangeScene(Define.Scene.Main);
    }
}
