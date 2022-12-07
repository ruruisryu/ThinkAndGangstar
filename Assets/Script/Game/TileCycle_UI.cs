using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCycle_UI : MonoBehaviour
{
    public GameObject tileCycle_Panel;
    public GameObject[] _fixedTileSet = new GameObject[2];
    public GameObject[] _fixedText = new GameObject[2];
    public GameObject[] _tileSet = new GameObject[8];

    public TileText_UI[] fixedText = new TileText_UI[2];

    private Animator animator;

    void Start()
    { 
        Init();
        animator = tileCycle_Panel.GetComponent<Animator>();
    }

    private void Init()
    {
        // tileCycle_Panel = this.gameObject.transform.GetChild(0).gameObject;
        tileCycle_Panel.SetActive(false);
        for (int i = 0; i < _fixedTileSet.Length; i++)
        {
            fixedText[i] = _fixedText[i].GetComponent<TileText_UI>();
        }
            
    }

    // 아래는 UI 관련함수 
    // 
    public void popFixedTile(string fix)
    {
        tileCycle_Panel.SetActive(true);
        animator.SetBool("isOpen", true);
        animator.SetBool("isClose", false);
        switch (fix)
        {
            case "AnswerFixed":
                SetOnlyOne(0);
                break;
            case "SymbolFixed":
                SetOnlyOne(1);
                break;
        }

    }

        private void SetOnlyOne(int index)
    {
        for (int i = 0; i < _fixedTileSet.Length; i++)
        {
            if (i == index)
            {
                _fixedTileSet[i].SetActive(true);
                StartCoroutine(FadeInStart(_fixedTileSet[i]));
            }
            else
            {
                _fixedTileSet[i].GetComponent<CanvasGroup>().alpha = 0;
            }

            for(int j=0; j < _tileSet.Length; j++)
            {
                if (j == 3 || j == 5) continue;
                _tileSet[j].transform.GetChild(0).gameObject.SetActive(true);
                _tileSet[j].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void OffTileCycleUI()
    {
        animator.SetBool("isClose", true);
        StartCoroutine(FadeOutStart(_fixedTileSet[0]));
        StartCoroutine(FadeOutStart(_fixedTileSet[1]));
    }



    //페이드 인
    public IEnumerator FadeInStart(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);

        for (float f = 0f; f < 1; f += 0.25f)
        {
            float a = gameObject.GetComponent<CanvasGroup>().alpha;

            if (a == 1)
                yield break;

            a = f;
            gameObject.GetComponent<CanvasGroup>().alpha = a;
        }
    }
    //페이드 아웃
    public IEnumerator FadeOutStart(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);

        for (float f = 1f; f > 0; f -= 0.25f)
        {
            float a = gameObject.GetComponent<CanvasGroup>().alpha;

            if(a == 0)
                yield break;

            a = f;
            gameObject.GetComponent<CanvasGroup>().alpha = a;
            
        }
    }

}

