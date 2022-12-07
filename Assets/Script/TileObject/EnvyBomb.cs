using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvyBomb : MonoBehaviour
{

    public ParticleSystem particle;
    public SpriteRenderer sprite;
    private bool isPlayerIn = false;


    void Start()
    {
        sprite.color = new Color(1, 1, 1, 0);
        //GameObject character = new GameObject();
        //character = GameObject.FindGameObjectWithTag("Player");

        //gameObject.GetComponent<BoxCollider>().enabled = false;

        // 플레이어 위치보다 10칸 앞에 생성
        //gameObject.transform.position = character.transform.position + new Vector3(0f, 0f, 13f);
        
        //StartCoroutine(ActiveAfterSeconds());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerIn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(ActiveAfterSeconds());
            isPlayerIn = true;
        }
        else
            return;
    }

    IEnumerator ActiveAfterSeconds()
    {
        UI_Popup popup = UI_Manager.UI_Instance.Popup<UI_Popup>("UI_EnvyAlert");
        StartCoroutine(SpritePadeIn());
        yield return new WaitForSeconds(3.0f); // 3초 뒤 펑
        particle.Play();
        sprite.color = new Color(1, 1, 1, 0);
        Check();
        Destroy(popup.gameObject);
    }

    IEnumerator SpritePadeIn()
    {
        yield return new WaitForSeconds(0.3f);
        for (float f = 0f; f < 1; f += 0.25f)
        {
            sprite.color = new Color(1, 1, 1, f);
            if (f == 1)
                yield break;
        }
    }

    void Check()
    {
        if (isPlayerIn)
        {
            Manager.currentStamina = 0;
            Debug.Log($"current stamina: {Manager.currentStamina}");
        }
    }
}
