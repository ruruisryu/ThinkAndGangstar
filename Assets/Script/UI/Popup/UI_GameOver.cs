using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : UI_Popup
{
    GameScene _gameScene = new GameScene();

    public void moveToMain()
    {
        _gameScene.MoveToMain();
    }

    public void PlayAgain()
    {
        Manager.Instance.RestartGame();
    }
}
