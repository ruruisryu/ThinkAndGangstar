using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBlock : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Manager.Instance.GameOver();
        }
    }


}
