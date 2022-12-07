using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleScrolling_Num : MonoBehaviour
{
    [SerializeField] private float tileSpeed = 2f;
    Vector3 startPos;

    private void OnEnable()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.right * tileSpeed * Time.deltaTime);
        if(transform.position.x > 10.5)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            transform.position = new Vector3(-10.5f, startPos.y, startPos.z);
        }
    }
}
