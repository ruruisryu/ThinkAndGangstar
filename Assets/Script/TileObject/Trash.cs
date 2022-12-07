using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public float trashSpeed;
    public TrashSpawner trashSpawner;
    [SerializeField] private ParticleSystem[] particle;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        trashSpawner = GetComponent<TrashSpawner>();
        anim.SetBool("isCrush", false);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * trashSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ast" || other.gameObject.tag == "Player")
        {
            anim.SetBool("isCrush", true);
            for(int i=0; i < particle.Length; i++)
            {
                particle[i].Play();
            }
            StartCoroutine(Crush());
        }
    }

    IEnumerator Crush()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("isCrush", false);
        this.gameObject.SetActive(false);
    }
    
}
