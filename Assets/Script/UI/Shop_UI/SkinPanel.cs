using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPanel : MonoBehaviour
{
    public GameObject skinToEquipMain;
    public ScriptableObject skinToEquipGame;

    CostumeState costume;

    public void EquipSkin()
    {
        costume = new CostumeState();
        costume.SaveCostume(skinToEquipGame.name);
    }
}
