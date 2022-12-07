using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NormalTile : MonoBehaviour
{

    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject[] poolingObjectPrefab;

    private List<GameObject> poolingObjectList = new List<GameObject>();
    private List<GameObject> currentObjectList = new List<GameObject>();
    private List<int> objectPositionList = new List<int>();


    private bool isStart = true;
    private int seed;
    private int check;

    private void Awake()
    {
        Initialize(2);
        seed = (int)transform.position.z * Random.Range(1, 999);
    }

    private void OnEnable()
    {
        seed = (int)(transform.position.z * Random.Range(1, 999) * (float)Time.deltaTime);
        Random.InitState(seed);
        int randomNum = Random.Range(1, 5); // 1~4개 오브젝트 생성
        int randomObject;

        if (!isStart)
        {
            for (int i = randomNum; i >= 0; i--)
            {
                ReturnObject(i);
            }
            for(int i=0; i< objectPositionList.Count; i++)
            {
                objectPositionList.RemoveAt(0);
            }
        }
        for (int i = 0; i < randomNum; i++)
        {
            randomObject = Random.Range(0, 16); // 엔비 폭탄이 대강 1/16 확률
            
            if (randomObject == 15)
            {
                randomObject = 8;
            }
            else
            {
                randomObject %= 8;
            }

            if (randomObject < poolingObjectList.Count - 1)
                randomObject = +1;
            else
                randomObject = 0;

            if (!GetObject(randomObject))  // 위치 중복시 false 리턴
            {
                i--;
                randomObject = Random.Range(0, poolingObjectList.Count - 1);
            }
        
        }
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            for(int j=0; j < poolingObjectPrefab.Length; j++)
            {
                var newObj = Instantiate(poolingObjectPrefab[j]);
                poolingObjectList.Add(newObj);
                newObj.SetActive(false);
                newObj.transform.SetParent(transform);
            } 
        }
    }

    public bool GetObject(int randomObject)
    {
        isStart = false;
        int random = Random.Range(0, 101);
        int randomRotation = 5;

        if (random < 11) { randomRotation = random; }
        else if(random > 11 && random < 41) { randomRotation = 10; }
        else if(random > 40 && random < 71) { randomRotation = 0; }
        else if(random > 70 && random < 86) { randomRotation = 9; }
        else if(random > 85) { randomRotation = 8; }
        
        var obj = poolingObjectList[randomObject];

        if (objectPositionList.Count > 0)
        {
            for (check = objectPositionList.Count-1; check >= 0; check--)
            {
                if (objectPositionList[check] == randomRotation)
                {
                    return false;
                }
            }
            if (check < 0)
            {
                objectPositionList.Add(randomRotation);
                currentObjectList.Add(obj);
                poolingObjectList.RemoveAt(randomObject);

                obj.SetActive(true);
                obj.transform.position = spawnPos.position;
                obj.transform.Translate(Vector3.right * (randomRotation * 1.25f));
            }
        }
        else if(objectPositionList.Count == 0)
        {
            objectPositionList.Add(randomRotation);
            currentObjectList.Add(obj);
            poolingObjectList.RemoveAt(randomObject);

            obj.SetActive(true);
            obj.transform.position = spawnPos.position;
            obj.transform.Translate(Vector3.right * (randomRotation * 1.25f));
        }
        
        return true;
    }

    public void ReturnObject(int index)
    {
        if(index < currentObjectList.Count)
        {
            GameObject obj = currentObjectList[index];
            currentObjectList.RemoveAt(index);
            obj.SetActive(false);
            poolingObjectList.Add(obj);
        }
    }


}
