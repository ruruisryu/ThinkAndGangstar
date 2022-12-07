using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveBestAlert : MonoBehaviour
{
    [SerializeField]
    Image bestScoreAlert;

    int bScoreint;

    void Start()
    {
        bScoreint = GameObject.Find("JsonUtility").GetComponent<BestRecord>().Load();
    }

    private void Update()
    {
        CheckBestRecord(bScoreint);
    }

    public void CheckBestRecord(int bestScore)
    {
        Debug.Log($"bestRecord is {bestScore}");
        if (Manager.currentScore > bestScore)
            bestScoreAlert.gameObject.SetActive(true);
    }

}
