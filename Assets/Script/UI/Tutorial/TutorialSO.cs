using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Tutorial_Item" , menuName = "Scriptable_Objects/Tutorial_Item", order = 1)]
public class TutorialSO : ScriptableObject
{
    public string objectName;
    public string TutorialTxt;
}
