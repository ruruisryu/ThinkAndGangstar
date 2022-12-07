using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFall : MonoBehaviour
{
    public float fallSpeed;

    private float time;
    private bool isEnterTile = false;
    private bool isDrop = false;

    void Update()
    {
        if (isEnterTile)
        {
            time += Time.deltaTime;
            // Debug.Log(Mathf.Floor(time));
            if (9 == Mathf.Floor(time))
            {
                isDrop = true;
            }
        }

        if (isDrop)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // æÓ¥¿¡§µµ ∂≥æÓ¡ˆ∏È ∏ÿ√„
            if (transform.position.y < -30f)
            {
                isDrop = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isEnterTile = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isEnterTile = false;
        time = 0;
    }

}
