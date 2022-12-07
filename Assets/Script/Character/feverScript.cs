using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feverScript : MonoBehaviour
{
    // Start is called before the first frame update
    //게이지 변수
    public int feverState = 0;
    public int feverState2 = 0;
    
    private Vector3 destination;
    private Vector3 destination2;
    private Vector3 destination3;

    // speed
    public float speed;
    GameObject character;
    Animator anim;
    public float time1;
    public float time2;
    float x = 0;
    float y = 0;
    float z = 0;

    GameObject feverUI;
    public AudioClip feverAudio;

    void Start()
    {
       
        
        Manager.feverGauge = 0;
    }
    void Awake()
    {
        character = transform.gameObject;
        //anim = character.GetComponent<Animator>();
        anim = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        capsuleCollider.enabled = true;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|think_fly_2"))
        {
            rigidbody.useGravity = false;
            capsuleCollider.enabled = true;
            feverState = 1;
            character.transform.rotation = Quaternion.Euler(15, 0, 0);
            character.transform.position =
                Vector3.MoveTowards(character.transform.position, destination2, 0.2f);
            //character.transform.position = new Vector3(x, y + 1.95f, z);

        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|think_fly_1"))
        {
            rigidbody.useGravity = false;
            character.transform.rotation = Quaternion.Euler(0, 0, 0);
            capsuleCollider.enabled = false;
            // 지우 add
            if(feverState2 == 1)
            {
                ObjectPool.Instance.FeverModeTile();
                feverState2 = 0;
            }
            

            character.transform.position =
                 Vector3.MoveTowards(character.transform.position, destination, speed);

        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|think_fly_3"))
        {
            rigidbody.useGravity = true;
            capsuleCollider.enabled = false;
            character.transform.rotation = Quaternion.Euler(0, 0, 0);
            character.transform.position =
            Vector3.MoveTowards(character.transform.position, destination3, speed);
            character.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            //capsuleCollider.enabled = true;
        }
        //Debug.Log(gauge + " 게이지 ");
        
        //character.transform.position = new Vector3(x, y + 1.95f, z);
        if (character.transform.position.z >= destination2.z)
        {
            feverState = 0;
            feverState2 = 0;
            anim.SetBool("isFeverDown", true);
            anim.SetBool("isFeverJump", false);
            destination3 = new Vector3(x, y - 3.95f, z + 52.0f);
            
        }
    }

    public void FeverTime()
    {
        Manager.feverGauge -= 100;

        

        //anim = transform.GetComponent<Animator>();
        character = GameObject.Find("Character").transform.GetChild(0).gameObject;
        // anim = character.GetComponent<Animator>();
        //anim = character.GetComponent<Animator>();
        anim = character.GetComponent<Animator>();
        anim.SetBool("isFeverJump", true);
        anim.SetBool("isFeverDown", false);
        x = character.transform.position.x;
        y = character.transform.position.y + 3.95f;
        z = character.transform.position.z;
        destination = new Vector3(x, y, z);
        destination2 = new Vector3(x, y, z + 52.0f);

        Debug.Log(character.transform.position + "시작");

        destination = new Vector3(x, y, z);
        Debug.Log(destination + "도착");


        //Debug.Log(time1 + " 피버시작 ");
        //Debug.Log(time2 + " 피버진행 ");
        feverState2 = 1;

    }

    IEnumerator FeverUIsec()
    {
        feverUI = Resources.Load<GameObject>("Prefabs/UI/Popup/UI_Fever.prefab");
        Instantiate(feverUI);
        yield return new WaitForSeconds(3.0f);
        Destroy(feverUI);
    }
}
