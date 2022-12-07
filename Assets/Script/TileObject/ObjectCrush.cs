using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCrush : MonoBehaviour
{
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ast"))
        {
            particle.Play();
            StartCoroutine(Crush());
        }
    }


    IEnumerator Crush()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
