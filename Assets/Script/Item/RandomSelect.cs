using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{

    public List<tetraGem> deck = new List<tetraGem>();
    public int total = 0;
    public tetraGem RandomGem()
    {
        int weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(total*Random.Range(0.0f,1.0f));

        for (int i = 0; i < deck.Count; i++) {
            weight += deck[i].weight;
            if (selectNum <= weight)
            {
                tetraGem temp = new tetraGem(deck[i]);
                return temp;
            }
        }

        return null;
    }

    void Start()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            total += deck[i].weight;
        }
    }

     
    
}
