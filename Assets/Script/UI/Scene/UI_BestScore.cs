using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_BestScore : MonoBehaviour
{
    BestRecord bestRecord = new BestRecord();

    void Start()
    {
        updateBestScoreUI();
    }

    void Update()
    {
    }

    public void updateBestScoreUI()
    {
        TextMeshProUGUI scoreText;
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();

        int BR = bestRecord.Load();
        scoreText.text = $"{BR}";
    }
}
