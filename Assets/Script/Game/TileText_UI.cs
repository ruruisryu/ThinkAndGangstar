using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileText_UI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void SetText(string _text)
    {
        text.text = _text;
    }
}
