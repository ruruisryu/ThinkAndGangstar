using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateZem : MonoBehaviour
{
    public GameObject tetraGem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spwanZem(Vector3 position) {
        Instantiate(tetraGem,position,
            Quaternion.identity);
    }
}
