using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizUITrigger : MonoBehaviour
{
    public TileCycle_UI tileCycle_UI;
    public TileCycle _tileCycle;

    void Start()
    {
        tileCycle_UI = GameObject.Find("@SceneUI_Game").transform.Find("Current_TileCycle").gameObject.GetComponent<TileCycle_UI>();
        _tileCycle = GetComponentInParent<TileCycle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ObjectPool.Instance.isNormalTile = false;
            QuizUISetting();
            // UI SetActive
            tileCycle_UI.popFixedTile(_tileCycle.gameObject.tag);
        }
        else if (other.gameObject.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ObjectPool.Instance.isNormalTile = true;
            // ¹®Á¦ UI Off
            tileCycle_UI.OffTileCycleUI();
        }
    }

    private void QuizUISetting()
    {
        switch (_tileCycle.tcType)
        {
            case Define.TileCylcle.AnswerFixed:
                tileCycle_UI.fixedText[0].SetText(_tileCycle._answer.ToString());
                break;
            case Define.TileCylcle.SymbolFixed:
                tileCycle_UI.fixedText[1].SetText(_tileCycle._symbol);
                break;
        }
    }

}
