using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private MoveScript player;
    public GameObject holePoint;
    public Transform currentTransform;

    Animator anim;

    private bool isEnterTile = false;
    void Awake()
    {
        anim = holePoint.GetComponent<Animator>();
    }

    void Update()
    {
        if (isEnterTile)
        {
            if (9 == Mathf.Floor(player.time))
            {
                currentTransform = player.gameObject.transform;
                holePoint.transform.SetPositionAndRotation(currentTransform.position, currentTransform.rotation);
                
                anim.SetBool("isFall", true);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = collision.gameObject.GetComponent<MoveScript>();
            isEnterTile = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isEnterTile = false;
        }
    }


}
