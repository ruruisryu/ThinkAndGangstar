using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemScript : MonoBehaviour
{
    Animator anim;
    GameObject character;
    float x, y, z = 0;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("r_moving_00")){
            character = GameObject.Find("r_moving_00");
        }else if (GameObject.Find("bee_stand (Clone)"))
        {
            character = GameObject.Find("bee_stand (Clone)");
        }
        else if (GameObject.Find("cawboy_stand (Clone)"))
        {
            character = GameObject.Find("cawboy_stand (Clone)");
        }
        else if (GameObject.Find("r_moving_00 (Clone)"))
        {
            character = GameObject.Find("r_moving_00 (Clone)");
        }

    }
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(character.transform.position.z+"Ä³¸¯ÅÍÁÂÇ¥");
        //Debug.Log(transform.position.z + "ÁªÁÂÇ¥");
        if ((character.transform.position.z -3.0f) > transform.position.z)
        {
            Destroy(gameObject);
        }
        if(character.GetComponent<feverScript>().feverState == 1)
        {
            x = character.transform.position.x;
            y = character.transform.position.y;
            z = character.transform.position.z;
            destination = new Vector3(x, y, z);
            transform.position =
                Vector3.MoveTowards(transform.position, destination, 0.3f);
        }
    }
}
