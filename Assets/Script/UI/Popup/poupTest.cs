using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poupTest : MonoBehaviour
{
    void Start()
    {
        //UI_Popup go = UI_Manager.UI_Instance.Popup<UI_Popup>("UI_Popup");
        //Debug.Log($"Pop {go.name}");
        //StartCoroutine(closePopupAfterSeconds(3.0f, go));
    }

    void Update()
    {

    }
    //UI_Popup go = UI_Manager.UI_Instance.Popup<UI_Popup>("UI_Popup");
    //Debug.Log($"Pop {go.name}");
    //StartCoroutine(closePopupAfterSeconds(3.0f, go));
    IEnumerator closePopupAfterSeconds(float sec, UI_Popup go)
    {
        Debug.Log("closePopupAfterSeconds!");
        yield return new WaitForSeconds(sec);
        Debug.Log("closePopup!");
        Object.Destroy(go.gameObject);
    }
}
