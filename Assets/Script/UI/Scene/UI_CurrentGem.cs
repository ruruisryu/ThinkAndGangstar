using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_CurrentGem : MonoBehaviour
{
    private void Start()
    {
        updateCurrentGemUI();
    }
    void Update()
    {
        updateCurrentGemUI();
    }

    public void updateCurrentGemUI()
    {
        TextMeshProUGUI scoreText;

        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = $"{Manager.currentGem}";
    }

}
