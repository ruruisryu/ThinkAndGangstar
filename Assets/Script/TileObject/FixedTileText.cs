using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTileText : MonoBehaviour
{
    public TMPro.TextMeshPro tileText;
    public GetTileInfo getTileInfo;

    public string fixedNum;
    public string fixedSymbol;
    
    void Start()
    {
        tileText = GetComponent<TMPro.TextMeshPro>();
        getTileInfo = GetComponentInParent<GetTileInfo>();

    }

    private void OnEnable()
    {
        if (this.tag == "NumberText")
            ShowNumText();
        else if (this.tag == "SymbolText")
            ShowSignText();
    }

    private void ShowNumText()
    {
        fixedNum = getTileInfo.quizTile.tileCycle._answer.ToString();
        tileText.text = fixedNum;
    }

    private void ShowSignText()
    {
        fixedSymbol = getTileInfo.quizTile.tileCycle._symbol;
        tileText.text = fixedSymbol;
    }
}
