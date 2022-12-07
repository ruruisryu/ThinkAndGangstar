using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : BaseScene
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
        SceneType = Define.Scene.Intro;

        StartCoroutine("MoveToMain", 3.0f);
        // TODO
        // UIManager를 이용해 UI 호출
    }

    IEnumerator MoveToMain(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ChangeScene(Define.Scene.Main);
    }
}
