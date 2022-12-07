using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleScrolling_Symbol : MonoBehaviour
{
    [SerializeField] private float tileSpeed = 1f;
    Vector3 startPos;

    private void OnEnable()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.right * tileSpeed * Time.deltaTime);
        if(transform.position.x > 15)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            transform.position = new Vector3(-15f, startPos.y, startPos.z);
        }
    }
}
