using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneUI_Game : UI_Base
{
    GameScene _gameScene;
    

    enum Buttons
    {
        Menu,
        Menu_Close,
        Back_To_Main
    }

    enum Texts
    {
        Gained_Gem_Number,
        Current_Score
    }

    enum GameObjects
    {
        Gem,
        Stamina,
        Current_TileCycle,
        GameOver
    }


    private void Start()
    {
        Init();
    }

    public void LateUpdate()
    {
        
    }

    public override void Init()
    {
        _gameScene = GameObject.Find("@Scene").GetComponent<GameScene>();

        // enum 바인딩
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        // UI에 이벤트 연결하는 부분
        GetButton((int)Buttons.Menu).gameObject.BindEvent(popMenu);
        GameObject menuClose = GameObject.Find("@SceneUI_Game").transform.Find("popup_Menu").transform.Find("Menu_UI").transform.Find("Menu_Close").gameObject;
        menuClose.BindEvent(closeMenu);

        GameObject backToMain = GameObject.Find("@SceneUI_Game").transform.Find("GameOver").transform.Find("GameOver_UI").transform.Find("Back_To_Menu").gameObject;
        backToMain.BindEvent(MoveMainScene);
    }

    private void popMenu(PointerEventData data)
    {
        Time.timeScale = 0;
        GameObject go = GameObject.Find("@SceneUI_Game").transform.Find("popup_Menu").gameObject;
        Debug.Log("popMenu");
        go.SetActive(true);
    }

    private void closeMenu(PointerEventData data)
    {
        GameObject go = GameObject.Find("@SceneUI_Game").transform.Find("popup_Menu").gameObject;
        go.SetActive(false);
        Time.timeScale = 1;
    }

    public void MoveMainScene(PointerEventData data)
    {
        _gameScene.MoveToMain();
    }
}
