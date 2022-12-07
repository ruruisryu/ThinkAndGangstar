using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menupopup : UI_Popup
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CloseMenu()
    {
        Destroy(gameObject);
        Manager.Instance.ContinueGame();
        GameObject go =  Resources.Load<GameObject>("Prefabs/UI/Popup/Wait3sec");
        Instantiate(go);
    }
}
