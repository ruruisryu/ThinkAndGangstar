using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTileInfo : MonoBehaviour
{

    public TileText tileText;
    public FixedTileText fixedTileText;
    public QuizTile quizTile;
    public string info;

    // Start is called before the first frame update
    void Start()
    {
        tileText = GetComponentInChildren<TileText>();
        fixedTileText = GetComponentInChildren<FixedTileText>();
        quizTile = GetComponentInParent<QuizTile>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if(tileText != null)
            {
                if (gameObject.tag.Equals("NumberTile"))
                {
                    quizTile.UpdateInfo(tileText.text_num);
                }
                else if (gameObject.tag.Equals("SymbolTile"))
                {
                    quizTile.UpdateInfo(tileText.text_sign);
                }
            }
            
            else
            {
                if (gameObject.tag.Equals("NumberTile"))
                {
                    quizTile.UpdateInfo(fixedTileText.fixedNum);
                }
                else if (gameObject.tag.Equals("SymbolTile"))
                {
                    quizTile.UpdateInfo(fixedTileText.fixedSymbol) ;
                }
            }
        }
    }
}
