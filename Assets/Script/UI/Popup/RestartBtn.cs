using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtn : MonoBehaviour
{
    public void Restartbtn()
    {
        Manager.Instance.RestartGame();
        Manager.isGameOverUIPopedUp = false;
    }
}
