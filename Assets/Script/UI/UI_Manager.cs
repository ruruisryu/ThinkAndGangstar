using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    private static UI_Manager ui_instance = null;

    void Awake()
    {
        if (null == ui_instance)
        {
            ui_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static UI_Manager UI_Instance
    {
        get
        {
            if (null == ui_instance)
            {
                return null;
            }
            return ui_instance;
        }
    }

    int _order = 0;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();

    public T Popup<T>(string name) where T : UI_Popup
    {
        GameObject go = Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        return popup;
    }

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab: {path}");
            return null;
        }
        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject go)
    {
        if (go = null)
            return;
        Object.Destroy(go);
    }

    public void GameOverUI()
    {
        if (!Manager.isGameOverUIPopedUp)
        {
            Time.timeScale = 0;
            UI_Popup go = Popup<UI_Popup>("UI_GameOver");
            Debug.Log($"Pop {go.name}");
            Manager.isGameOverUIPopedUp = true;
        }
    }
    
}
