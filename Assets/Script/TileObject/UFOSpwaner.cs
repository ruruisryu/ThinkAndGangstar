using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpwaner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private GameObject poolingObjectPrefab;

    private Queue<GameObject> poolingObjectQueue = new Queue<GameObject>();
    private Queue<GameObject> currentObjectQueue = new Queue<GameObject>();

    private int ufoType;

    private void Awake()
    {
        Initialize(6);
        ufoType = Random.Range(0, 2); // 0:哭率, 1:坷弗率
    }

    private void OnEnable()
    {
        //int ufoSpeed = Random.Range(5, 7);
        int ufoSpeed = 5;
        int ufoNum = Random.Range(2, 4);
        float waitTime = 0.5f;
        SetObject(ufoType, ufoSpeed);
        StartCoroutine(SpawnTrash(ufoType, ufoNum, waitTime));
    }
    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            var newObj = Instantiate(poolingObjectPrefab);
            poolingObjectQueue.Enqueue(newObj);
            newObj.SetActive(false);
            newObj.transform.SetParent(this.transform);
        }
    }

    public void SetObject(int ufoType, int ufoSpeed)
    {
        for (int i = 0; i < poolingObjectQueue.Count; i++)
        {
            var obj = poolingObjectQueue.Dequeue();
            poolingObjectQueue.Enqueue(obj);
            obj.GetComponent<UFO>().ufoSpeed = ufoSpeed;
            if (ufoType == 0)
            {
                obj.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                obj.transform.localEulerAngles = new Vector3(0, -180, 0);
            }
        }

    }

    public GameObject GetObject(int ufoType)
    {
        var obj = poolingObjectQueue.Dequeue();
        currentObjectQueue.Enqueue(obj);
        obj.SetActive(true);
        obj.transform.position = spawnPos[ufoType].position;
        return obj;
    }

    public void ReturnObject()
    {
        GameObject obj = currentObjectQueue.Dequeue();
        obj.gameObject.SetActive(false);
        poolingObjectQueue.Enqueue(obj);
    }

    private IEnumerator SpawnTrash(int ufoType, int ufoNum, float waitTime)
    {
        // 0:哭率, 1:坷弗率
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (poolingObjectQueue.Count == 0)
            {
                ReturnObject();
                ReturnObject();
                GetObject(ufoType);
            }
            else GetObject(ufoType);
            if (currentObjectQueue.Count % ufoNum == 0)
            {
                waitTime = Random.Range(2.5f, 4f);
            }
            else
            {
                waitTime = 0.5f;
            }
        }
    }
}
