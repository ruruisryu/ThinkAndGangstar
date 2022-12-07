using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "shopMenu" , menuName ="Scriptable_Objects/New_Shop_Item", order = 1)] 
public class Shop_ItemSO : ScriptableObject
{
    public string title;
    public int baseCost;
    public Image Costume;
    public bool isPurchased;
    public bool isSelling;
    public bool isEquiped;
}
