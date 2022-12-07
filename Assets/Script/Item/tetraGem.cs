using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GemNumber{One,Five,Ten}

[System.Serializable]
public class tetraGem 
{
    public string gemColor;
    public GemNumber gemNumber;
    public int weight;
    public tetraGem(tetraGem Gem)
    {
        this.gemColor = Gem.gemColor;
        this.gemNumber = Gem.gemNumber;
        this.weight = Gem.weight;
    }
}
