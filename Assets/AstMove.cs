using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstMove : MonoBehaviour
{
    float x, y, z = 0;
    private Vector3 destination;
    private Manager manager;
 
    // speed
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        manager = GameObject.Find("@Manager").GetComponent<Manager>();
        string name = GameObject.Find("character").transform.GetChild(0).gameObject.name;
        if (collision.gameObject.name == name)
        {
            
            //게임오버
            Destroy(gameObject);
            Debug.Log("행성 충돌");
            Manager.Instance.GameOver();
        }
        else
        {
            //Destroy(collision.gameObject);
        }
       

    }
    // Update is called once per frame
    void Update()
    {
        
        x = transform.position.x;
        y = transform.position.y ;
        z = transform.position.z - 13.0f;
        destination = new Vector3(x, y, z);
        transform.position =
            Vector3.MoveTowards(transform.position, destination, speed);
    }
}
