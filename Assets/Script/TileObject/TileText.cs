using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileText : MonoBehaviour
{
    public TMPro.TextMeshPro tileText;
    public GameObject parentObject;
    private int seed;

    public string text_num;
    public string text_sign;
    public string text_answer;


    // Start is called before the first frame update
    void Start()
    {
        tileText = GetComponent<TMPro.TextMeshPro>();
        
    }

    private void OnEnable()
    {
        seed = (int)(parentObject.transform.position.x * parentObject.transform.position.z * Random.Range(10000, 99999));
        Random.InitState(seed);
        if (this.tag == "NumberText")
            ShowNumText();
        else if (this.tag == "SymbolText")
            ShowSignText();
    }


    private void ShowNumText()
    {
        int num;
        
        if(parentObject.transform.parent.gameObject.CompareTag("SecondNumber"))
        {
            num = Random.Range(1, 7);
            text_num = num.ToString();
            tileText.text = text_num;
        }
        else
        {
            num = Random.Range(1, 13);
            text_num = num.ToString();
            tileText.text = text_num;
        }

    }

    private void ShowSignText()
    {
        int sign_num = Random.Range(0, 9);
        text_sign = null;
        // 더하기, 뺴기 확률이 나누기의 3배, 곱하기 확률이 나누기의 2배
        if (sign_num < 3)
            text_sign = "+";
        else if (sign_num >= 3 && sign_num < 6)
            text_sign = "-";
        else if(sign_num >= 6 && sign_num < 8)
            text_sign = "×";
        else if(sign_num == 8)
            text_sign = "÷";

        tileText.text = text_sign;
    }

}
