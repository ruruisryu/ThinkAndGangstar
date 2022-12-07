using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TotalGem : MonoBehaviour
{
    GemState gemState = new GemState();

    private void Start()
    {
        updateTotalGemUI();
    }

    private void Update()
    {
        updateTotalGemUI();
    }

    public void updateTotalGemUI()
    {
        TextMeshProUGUI totalGem;

        totalGem = gameObject.GetComponent<TextMeshProUGUI>();
        int tGem = gemState.Load();
        totalGem.text = $"{tGem}";
    }
}
