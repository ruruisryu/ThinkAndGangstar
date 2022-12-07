using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstScript : MonoBehaviour
{
    public GameObject ast;
    private GameObject _ast;
    private GameObject character;
    private Vector3 astPosition = new Vector3(0,0,0);
    private float time =0 ;
    int i = 0;
    float x, y, z = 0;

    bool isAlertOn = false;
    bool isUIPop = false;

    public AudioClip astAlert;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.GetChild(0).gameObject;
        // 지우 삭제
        /*
        if (GameObject.Find("r_moving_00"))
        {
            character = GameObject.Find("r_moving_00");
        }
        else if (GameObject.Find("bee_stand (Clone)"))
        {
            character = GameObject.Find("bee_stand (Clone)");
        }
        else if (GameObject.Find("cawboy_stand (Clone)"))
        {
            character = GameObject.Find("cawboy_stand (Clone)");
        }
        else if (GameObject.Find("r_moving_00 (Clone)"))
        {
            character = GameObject.Find("r_moving_00 (Clone)");
        } */
        // 지우 수정
        _ast = Instantiate(ast, astPosition, Quaternion.identity);
        _ast.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.GetComponent<feverScript>().feverState == 0)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }

        if ((Mathf.Floor(time) % 28) == 0 && Mathf.Floor(time) != 0)
        {
            if (isUIPop)
            {
                isUIPop = false;

                y = character.transform.position.y + 1.0f;
                z = character.transform.position.z + 13.0f;
                astPosition = new Vector3(x, y, z);
                Debug.Log("소행성 생성");
                // Instantiate(ast, astPosition, Quaternion.identity);
                _ast.SetActive(true);
                _ast.transform.SetPositionAndRotation(astPosition, Quaternion.identity);

            }
        }
        else if ((Mathf.Floor(time) % 25) == 0 && Mathf.Floor(time) != 0 && isAlertOn == false)
        {
            if (ObjectPool.Instance.isNormalTile)
            {
                //경고창 띄우기
                isAlertOn = true;
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(astAlert);

                x = character.transform.position.x;
                UI_Popup go = UI_Manager.UI_Instance.Popup<UI_Popup>("UI_Alert");
                Debug.Log($"Pop {go.name}");
                StartCoroutine(closePopupAfterSeconds(3.0f, go));
                isUIPop = true;
            }
        }
        else if((Mathf.Floor(time) % 31) == 0 && Mathf.Floor(time) != 0) // 시간 지나면 비활성화
        {
            _ast.SetActive(false);
            time = 0;
        }


    }

    IEnumerator closePopupAfterSeconds(float sec, UI_Popup go)
    {
        Debug.Log("closePopupAfterSeconds!");
        yield return new WaitForSeconds(sec);
        Debug.Log("closePopup!");
        // Object.Destroy(go.gameObject);
        go.gameObject.SetActive(false);
        isAlertOn = false;
    }
}
