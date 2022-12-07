using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AchieveMenu", menuName = "Scriptable Objects/New Achieve Item", order = 1)]
public class AchieveItemSO : ScriptableObject
{
    public string achieveInform;
    public int acheievScore;
    public string award;

    public bool isCompleted;
    public bool isGained;
}
