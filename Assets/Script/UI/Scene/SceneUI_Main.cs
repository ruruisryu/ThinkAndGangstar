using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUI_Main : UI_Base
{
    MainScene _mainScene = new MainScene();

    public override void Init()
    {
        
    }

    public void MoveGameScene()
    {
        _mainScene.MoveToGame();
    }

    public void MoveShopScene()
    {
        _mainScene.MoveToShop();
    }

    public void popupMenuMain()
    {
        UI_Manager.UI_Instance.Popup<UI_Popup>("UI_MenuPopMain");
    }
}
