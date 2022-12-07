using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainbtn : MonoBehaviour
{
    GameScene _gameScene = new GameScene();

    public void GoToMainBtn()
    {
        Time.timeScale = 1;
        _gameScene.MoveToMain();
    }
}
