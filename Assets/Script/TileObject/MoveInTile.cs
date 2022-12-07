using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInTile : MonoBehaviour
{
    private int tileType; // 0: Number Tile, 1: Symbol Tile, 2: UFO, 3: Etc
    GameObject character;

    private void Start()
    {
        character = GameObject.Find("Character");

        if (gameObject.tag.Equals("NumberTile")) tileType = 0;
        else if (gameObject.tag.Equals("SymbolTile")) tileType = 1;
        else if (gameObject.tag.Equals("UFO")) tileType = 2;
        else tileType = 3;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
            MoveInEachTile(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.parent.gameObject == gameObject)
            {
                other.gameObject.transform.SetParent(character.transform);
                if(tileType == 2) // UFO 내릴 때 뒤돌기 방지
                {
                    other.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && character.GetComponent<MoveScript>().canEnterTile)
        {
            character.GetComponent<MoveScript>().canEnterTile = false;
            collision.gameObject.transform.SetParent(transform);
            MoveInEachTile(collision.gameObject);
            Invoke(nameof(WaitForEnter), 0.01f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.parent.gameObject == gameObject)
            {
                collision.gameObject.transform.SetParent(character.transform);
            }
        }
    }


    private void MoveInEachTile(GameObject player)
    {
        if(tileType == 0)
        {
            player.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        }
        else if(tileType == 2)
        {
            player.transform.localPosition = new Vector3(0f, 0.1f, 0f);
        }
        else if(tileType == 1)
        {
            if(player.transform.localPosition.x > 0)
            {
                player.transform.localPosition = new Vector3(0.75f, 0.5f, 0f);
            }
            else if(player.transform.localPosition.x <= 0)
            {
                player.transform.localPosition = new Vector3(-0.75f, 0.5f, 0f);
            }
        }
        /*
        else
        {
            int i = 1;
            if(player.transform.localPosition.x < 0)
            {
                i = -1;
            }
            int j = (int)(player.transform.localPosition.x / 0.75);
            player.transform.localPosition = new Vector3((float)i* (float)j * 0.75f, 0.1f, 0f);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        */
    }

    private void WaitForEnter()
    {
        character.GetComponent<MoveScript>().canEnterTile = true;

        return;
    }

}
