using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public void CloseCurrentPopup()
    {
        Destroy(gameObject);
        Manager.Instance.ContinueGame();
    }
}
