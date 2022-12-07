using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScene : BaseScene
{
    public override void Clear()
    {
        // TODO
        // Scene이 종료되었을 때 Scene을 날려주는 부분
    }

    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Main;

        // TODO
        // UIManager를 이용해 UI 호출
    }

    public void MoveToMain()
    {
        ChangeScene(Define.Scene.Main);
    }
}
