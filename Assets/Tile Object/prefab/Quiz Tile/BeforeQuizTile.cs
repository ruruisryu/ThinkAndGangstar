using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeQuizTile : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

        }
    }

}
