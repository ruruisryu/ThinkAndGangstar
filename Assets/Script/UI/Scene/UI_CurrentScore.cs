using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_CurrentScore : MonoBehaviour
{
    void Start()
    {
        updateCurrentScoreUI();
    }

    void Update()
    {
        updateCurrentScoreUI();
    }

    public void updateCurrentScoreUI()
    {
        TextMeshProUGUI scoreText;

        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = $"{Manager.currentScore}";
    }
}
