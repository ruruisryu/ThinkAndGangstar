using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScript : MonoBehaviour
{
    RaycastHit hit;
    private GameObject character;
    public GameObject tetraGem1;
    public GameObject tetraGem5;
    public GameObject tetraGem10;


    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Touch touch;

    private float Z;
    private float cZ;
    private Vector3 gemPosition;

    public float time;

    private IEnumerator goCoroutine;
    private bool coroutineAllowd;

    float x = 0;
    float z = 0;
    public int isTreeCol1;
    public int isTreeCol2 ;
    public int isTreeCol3 ;
    int ColState = 0;
    int MoveState = 0;
    Animator anim;

    public GameObject tileCreateScript;
    private Rigidbody rigid;
    public GameObject RandomSelect;

    // 지우 add
    public ParticleSystem particle;
    private Manager manager;
    public bool canEnterTile = true;

    // 서현 add
    public AudioClip GemGain;

    void Awake()
    {

        character = transform.GetChild(0).gameObject;
        anim = character.GetComponent<Animator>();
        // 지우 add
        manager = GameObject.Find("@Manager").GetComponent<Manager>();
        // particle = transform.GetChild(0).gameObject.GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        GameObject.Find("JsonUtility").GetComponent<BestRecord>().SaveRecord(2);

        z = character.transform.position.z;
        coroutineAllowd = true;
        rigid = character.GetComponent<Rigidbody>();
    }
  
        private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "gem_green(Clone)")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(GemGain);
            Destroy(other.gameObject);
            manager.updateGem(1);
            //Debug.Log("gem_green");
        }
        else if (other.gameObject.name == "gem_blue(Clone)")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(GemGain);
            Destroy(other.gameObject);
            manager.updateGem(5);
            //Debug.Log("gem_blue");
        }
        else if (other.gameObject.name == "gem_purple(Clone)")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(GemGain);
            Destroy(other.gameObject);
            manager.updateGem(10);
            //Debug.Log("gem_purple");
        }
        else if (other.gameObject.tag.Equals("ArcadeTile"))
        {
            ObjectPool.Instance.standingAcadeTile = other.gameObject;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "collider");
        if (other.gameObject.name == "Trash(Clone)")
        {
            // collision.gameObject.gameObject.SetActive(false);
            // 캐릭터가 밀리는 현상 때문에 트리거로 교체.
            // Debug.Log("                ");
            manager = GameObject.Find("@Manager").GetComponent<Manager>();
            manager.updateStamina(-1);
        }
        else if (other.gameObject.name == "Tree1(Clone)")
        {
            if(other.gameObject.transform.position.x  < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z) {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
                

            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */
        }
        else if (other.gameObject.name == "Tree2(Clone)")
        {
            isTreeCol1 = 1;
            isTreeCol2 = 1;
            isTreeCol3 = 1;
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */
        }
        else if (other.gameObject.name == "Tree3(Clone)")
        {
            manager.isCol1 = 1;
            manager.isCol2 = 1;
            manager.isCol3 = 1;
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */
        }
        else if (other.gameObject.name == "Tree4(Clone)")
        {
            manager.isCol1 = 1;
            manager.isCol2 = 1;
            manager.isCol3 = 1;
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */
        }
        else if (other.gameObject.name == "Tree5(Clone)")
        {
            manager.isCol1 = 1;
            manager.isCol2 = 1;
            manager.isCol3 = 1;
            // Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */
        }
          else if (other.gameObject.name == "Stone1(Clone)")
          {
              manager.isCol1 = 1;
              manager.isCol2 = 1;
              manager.isCol3 = 1;
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */
        }
        else if (other.gameObject.name == "Stone2(Clone)")
          {
              manager.isCol1 = 1;
              manager.isCol2 = 1;
              manager.isCol3 = 1;
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
            }
            else
            {
                Debug.Log("엥!");
            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */
        }
        else if (other.gameObject.name == "Stone3(Clone)")
          {
              manager.isCol1 = 1;
              manager.isCol2 = 1;
              manager.isCol3 = 1;
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                if (manager.MoveState == 1)
                {
                    manager.isCol1 = 1;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 1;
                    manager.isCol3 = 0;
                }
                else if (manager.MoveState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 3;
                }
            }
            /*
            //Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (manager.MoveState == 1)
            {
                //manager.ColState = 1;
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 2)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (manager.MoveState == 3)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            */

        }

        else if (other.gameObject.tag.Equals("ArcadeTile")) 
        {
            ObjectPool.Instance.standingAcadeTile = other.gameObject;
        }
        //Debug.Log(other.gameObject.name);
        // 지우 add
        else if (other.gameObject.tag.Equals("Ast"))
        {
            particle.Play();
            Manager.currentStamina = 0;
        }
        else
        {
            /*
            Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "충돌!!");
            if (other.gameObject.transform.position.x < character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 1;
                manager.isCol3 = 0;
            }
            else if (other.gameObject.transform.position.x > character.transform.position.x && other.gameObject.transform.position.z < character.transform.position.z)
            {
                manager.isCol1 = 0;
                manager.isCol2 = 0;
                manager.isCol3 = 1;
            }
            else if (other.gameObject.transform.position.z > character.transform.position.z)
            {
                manager.isCol1 = 1;
                manager.isCol2 = 0;
                manager.isCol3 = 0;
            }
            */
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(character.transform.position, new Vector3(1.0f, 0,0),Color.red);
        Debug.DrawRay(character.transform.position, new Vector3(-1.0f, 0, 0), Color.red);
        Debug.DrawRay(character.transform.position, new Vector3(0.0f, 0, 1.0f), Color.red);
        if (character.transform.position.y <= -5.0f)
        {
            Manager.Instance.GameOver();
        }
        //character.transform.rotation = Quaternion.Euler(0, -90.0f, 0);
        
        Debug.Log("자식 오브젝트" + character);
       

        
        // character.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cZ = character.transform.position.z;
        //Debug.Log((cZ - Z) / 1.25f);
        if (anim.GetBool("isFeverJump") == true)
        {
            time = 0;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|think_stepR") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            anim.SetBool("isStand", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|think_stepL") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            anim.SetBool("isStand", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("시간" + Mathf.Floor(time));
            time = 0;
            startTouchPosition = Input.GetTouch(0).position;
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && coroutineAllowd)
        {
            Debug.Log("시간" + Mathf.Floor(time));
            time = 0;
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.y > startTouchPosition.y) && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
            {

                if ((Mathf.Floor(((cZ - Z) / 1.25f)) % 7 == 0))
                {
                    string gemColor = RandomSelect.GetComponent<RandomSelect>().RandomGem().gemColor;
                    Debug.Log(gemColor);
                    int randomX = Random.Range(-7, 8);
                    gemPosition = new Vector3(randomX * 1.25f, -0.3f, cZ + 11);
                    if (gemColor == "green")
                    {
                        Instantiate(tetraGem1, gemPosition, Quaternion.identity);
                    }
                    else if (gemColor == "blue")
                    {
                        Instantiate(tetraGem5, gemPosition, Quaternion.identity);
                    }
                    else if (gemColor == "purple")
                    {
                        Instantiate(tetraGem10, gemPosition, Quaternion.identity);
                    }

                }
               
                anim.SetBool("isRight", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isStand", false);
                if (Physics.Raycast(character.transform.position, (new Vector3(0, 0, 0.1f)), out hit))
                {
                    float distance = Vector3.Distance(character.transform.position, hit.transform.position);
                    Debug.Log(distance + "up");
                    if (distance < 1.5f)
                    {

                        if (hit.collider.name == "Tree1(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree2(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree3(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree4(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree5(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone1(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone2(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone3(Clone)")
                        {

                        }
                        else
                        {
                            Up();
                        }

                    }
                    else
                    {
                        
                           Up();
                        
                    }

                }
                else
                {
                    


                    Up();
                }
                /*
                manager.MoveState = 1;
                
                if (manager.isCol1 != 1 )
                {
                    Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "확인!!");
                    
                    anim.SetBool("isRight", true);
                    anim.SetBool("isLeft", false);
                    anim.SetBool("isStand", false);

                   
                    Up();

                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;

                    //
                }
                else
                {
                   
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                    //manager.ColState = 1;
                }*/
                character.transform.localRotation = Quaternion.Euler(0, 0.0f, 0);


                //goCoroutine = Go(new Vector3(0f, 0f, 0.25f));
                //StartCoroutine(goCoroutine);
            }
            /*else if ((endTouchPosition.y < startTouchPosition.y) && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
            {
                anim.SetBool("isStand", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                Down();
                character.transform.rotation = Quaternion.Euler(0, 180.0f, 0);
               
                //goCoroutine = Go(new Vector3(0f, 0f, -0.25f));
                //StartCoroutine(goCoroutine);
            }*/
            else if ((endTouchPosition.x < startTouchPosition.x) && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {

                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isStand", false);
                character.transform.localEulerAngles = new Vector3(0, -90.0f, 0);
                Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "확인!!");

                /*if (manager.ColState == 1)
                {
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.ColState == 2)
                {
                    manager.isCol1 = 0;
                    manager.isCol3 = 0;
                }
                else if (manager.ColState == 3)
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                }
                manager.MoveState = 2;
                if (manager.isCol2 != 1 )
                {
                    Left();

                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else
                {
                    manager.isCol1 = 0;
                    manager.isCol3 = 0;
                    //manager.ColState = 2;
                }*/
                if (Physics.Raycast(character.transform.position, new Vector3(-0.1f, 0, 0), out hit))
                {
                    float distance = Vector3.Distance(character.transform.position, hit.transform.position);
                    Debug.Log(distance + "left");
                    if (distance < 1.5f)
                    {

                        if (hit.collider.name == "Tree1(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree2(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree3(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree4(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree5(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone1(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone2(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone3(Clone)")
                        {

                        }
                        else
                        {
                            Left();
                        }

                    }
                    else
                    {
                        
                            Left();
                        
                    }


                }
                else
                {
                    Left();
                }


                //goCoroutine = Go(new Vector3(-0.25f, 0f, 0f));
                // StartCoroutine(goCoroutine);
            }
            else if ((endTouchPosition.x > startTouchPosition.x) && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {
                anim.SetBool("isRight", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isStand", false);
                character.transform.localEulerAngles = new Vector3(0, 90.0f, 0);
                if (Physics.Raycast(character.transform.position, new Vector3(0.1f, 0, 0),out hit))
                {
                    float distance = Vector3.Distance(character.transform.position, hit.transform.position);
                    Debug.Log(distance + "right");
                    if (distance < 1.5f) {

                        if (hit.collider.name == "Tree1(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree2(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree3(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree4(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Tree5(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone1(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone2(Clone)")
                        {

                        }
                        else if (hit.collider.name == "Stone3(Clone)")
                        {

                        }
                        else
                        {
                            Right();
                        }

                    }
                    else
                    {
                        
                            Right();
                        
                        
                    }


                }
                else
                {
                    Right();
                }
                Debug.Log(manager.isCol1 + ":" + manager.isCol2 + ":" + manager.isCol3 + ":" + "확인!!");
                /*if (manager.ColState == 1)
               {
                   manager.isCol2 = 0;
                   manager.isCol3 = 0;
               }
               else if (manager.ColState == 2)
               {
                   manager.isCol1 = 0;
                   manager.isCol3 = 0;
               }
               else if (manager.ColState == 3)
               {
                   manager.isCol1 = 0;
                   manager.isCol2 = 0;
               }
               */
                /*
                manager.MoveState = 3;
                if (manager.isCol3 != 1)
                {
                    Right();
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    manager.isCol3 = 0;
                }
                else
                {
                    manager.isCol1 = 0;
                    manager.isCol2 = 0;
                    //manager.ColState = 3;
                }
                */

                //goCoroutine = Go(new Vector3(0.25f, 0f, 0f));
                //StartCoroutine(goCoroutine);
            }

        }
        else
        {

            time += Time.deltaTime;
            Debug.Log("시간" + Mathf.Floor(time));
            if (10 == Mathf.Floor(time))
            {
                //게임오버
                //manager.GameOver();
                //tenSecGameOver();

            }
        }

    }

    private void tenSecGameOver()
    {
        //Debug.Log(Mathf.Floor(time));
        anim.SetBool("isFall", true);

        // 게임오버 UI 팝업
        StartCoroutine(GameOverUIpop(3f));
    }

    private IEnumerator Go(Vector3 direction)
    {
        coroutineAllowd = false;

        for (int i = 0; i <= 2; i++)
        {
            transform.Translate(direction);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i <= 2; i++)
        {
            transform.Translate(direction);
            yield return new WaitForSeconds(0.01f);
        }
        transform.Translate(direction);
        coroutineAllowd = true;
    }

    private IEnumerator GameOverUIpop(float sec)
    {
        yield return new WaitForSeconds(sec);
        Manager.Instance.GameOver();
    }

    private void Right()
    {

        //anim.SetBool("isStand", true);
        //anim.SetBool("isLeft", false);
        //anim.SetBool("isRight", false);
        x = character.transform.position.x + 1.25f;
       // new Vector3(x, character.transform.position.y, character.transform.position.z);
        
        if (x >= 6.25f)
        {
            return;
        }
        character.transform.position = Vector3.Lerp(character.transform.position, new Vector3(x, character.transform.position.y, character.transform.position.z), 1.0f);

    }

    private void Left()
    {
        //anim.SetBool("isStand", true);
        //anim.SetBool("isLeft", false);
        //anim.SetBool("isRight", false);

        x = character.transform.position.x - 1.25f;
        if (x <= -6.35f)
        {
            return;
        }
        //character.transform.position = new Vector3(x, character.transform.position.y, character.transform.position.z);
        character.transform.position = Vector3.Lerp(character.transform.position, new Vector3(x, character.transform.position.y, character.transform.position.z), 1.0f);
       // isTreeCol1 = 0;
        //isTreeCol3 = 0;
    }

    private void Up()
    {
        //isTreeCol1 = 0;
        z = character.transform.position.z + 1.3f; // 1.25 -> 1.3
        //character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, z);
        character.transform.position = Vector3.Lerp(character.transform.position, new Vector3(character.transform.position.x, character.transform.position.y, z), 1.0f);
        //isTreeCol2 = 0;
       // isTreeCol1 = 0;
        //isTreeCol3 = 0;

        //  ̺κ      ּ       ϱ 
        // Tile create
        tileCreateScript.GetComponent<ObjectPool>().PlayerJumpTileCreate();

    }

    private void Down()
    {

        z = character.transform.position.z - 1.3f;
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, z);

    }
}