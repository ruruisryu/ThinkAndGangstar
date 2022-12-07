using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchivementMessage : MonoBehaviour
{
    void Start()
    {
        if (Manager.isAnyAchived)
            gameObject.GetComponent<TextMeshProUGUI>().text = "도전과제를 달성했어!\n도전과제 목록을 확인해보자";
        else
            gameObject.GetComponent<TextMeshProUGUI>().text = "다음번엔 더\n잘할 수 있을 거야!힘내!";
    }
}
