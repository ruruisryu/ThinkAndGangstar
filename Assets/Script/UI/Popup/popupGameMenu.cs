using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupGameMenu : MonoBehaviour
{
    public void PopupMenu()
    {
        UI_Popup go = Resources.Load<UI_Popup>("Prefabs/UI/Popup/UI_MenuPop");
        Instantiate(go);
        Manager.Instance.PauseGame();
    }
}
