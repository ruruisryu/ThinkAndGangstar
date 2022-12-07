using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashSpawner : MonoBehaviour
{
    // public static TrashSpawner TrashTile;

    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparationTime;
    [SerializeField] private GameObject poolingObjectPrefab;

    private Queue<GameObject> poolingObjectQueue = new Queue<GameObject>();
    private Queue<GameObject> currentObjectQueue = new Queue<GameObject>();

    private void Awake()
    {
        Initialize(2);
    }

    private void OnEnable()
    {
        int trashType = Random.Range(0, 2); // 0:哭率, 1:坷弗率
        int trashSpeed = Random.Range(2, 5);
        SetObject(trashType, trashSpeed);
        StartCoroutine(SpawnTrash(trashType));
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

    public void SetObject(int trashType, int trashSpeed)
    {
        for (int i = 0; i < poolingObjectQueue.Count; i++)
        {
            var obj = poolingObjectQueue.Dequeue();
            poolingObjectQueue.Enqueue(obj);
            obj.GetComponent<Trash>().trashSpeed = trashSpeed;
            if (trashType == 0)
            {
                obj.transform.localEulerAngles = new Vector3(90, 0, 0);
            }
            else
            {
                obj.transform.localEulerAngles = new Vector3(90, 180, 0);
            }
        }

    }

    public GameObject GetObject(int trashType)
    {
        var obj = poolingObjectQueue.Dequeue();
        currentObjectQueue.Enqueue(obj);
        // obj.transform.SetParent(null);
        obj.SetActive(true);
        obj.transform.position = spawnPos[trashType].position;
        return obj;
    }

    public void ReturnObject()
    {
        GameObject obj = currentObjectQueue.Dequeue();
        obj.gameObject.SetActive(false);
        // obj.transform.SetParent(transform);
        poolingObjectQueue.Enqueue(obj);
    }

    private IEnumerator SpawnTrash(int trashType)
    {
        // 0:哭率, 1:坷弗率
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            if (poolingObjectQueue.Count == 0)
            {
                ReturnObject();
                GetObject(trashType);
            }
            else GetObject(trashType);
        }
    }
}
