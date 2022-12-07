// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject[] poolingObjectPrefab;
    [SerializeField] private GameObject[] poolingObjectPrefabQ;
    [SerializeField] private int maxTerrainCount;

    private List<GameObject> poolingObjectList = new List<GameObject>();
    private List<GameObject> currentTerrains = new List<GameObject>();
    public List<GameObject> currentQuizTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0, -1, 0);

    private float tileInterval = 1.3f;

    private int tileCount = 0;
    private bool isQuizStart = false;
    bool isQuizPlaying = false;
    private int waitForUFO = 0;
    private int waitForBigTile = 0;
    private int quizIndex1 = 0;
    private int quizIndex2 = 0;
    private int waiForQuizmode = 0;
    private int quizTileCount = 0;
    

    private List<GameObject> answerFixedTile = new List<GameObject>();
    private List<GameObject> simbolFixedTile = new List<GameObject>();

    private bool isFeverStart = false;
    private bool isFeverEnd = false;
    public bool isNormalTile = true;

    public feverScript feverScript; // 씽크 오브젝트 수정되면 수정
    public GameObject standingAcadeTile;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Initialize(5);
        for (int i = 0; i < maxTerrainCount; i++)
        {
            InitTerrain();
        }
    }


    private void Initialize(int initCount)
    {
        // 일반 타일 생성
        for (int i = 0; i < initCount; i++)
        {
            for(int j=0;j< poolingObjectPrefab.Length; j++)
            {
                if (j == 3)
                {
                    i++;
                }
                var newObj = Instantiate(poolingObjectPrefab[j]);
                poolingObjectList.Add(newObj);
                newObj.SetActive(false);
                newObj.transform.SetParent(Instance.transform);
            }
            // poolingObjectQueue.Enqueue(CreateNewObject(0));
        }
        // 퀴즈 타일 생성
        for(int i=0; i< 3; i++)
        {
            var newObj0 = Instantiate(poolingObjectPrefabQ[i]);
            answerFixedTile.Add(newObj0);
            answerFixedTile[i].SetActive(false);
            var newObj1 = Instantiate(poolingObjectPrefabQ[i+3]);
            simbolFixedTile.Add(newObj1);
            simbolFixedTile[i].SetActive(false);
        }
    }


    private void InitTerrain()
    {
        var terrain = GetObject(0);
        currentTerrains.Add(terrain);
    }


    public GameObject GetObject(int tileType)
    {
        if (tileType == 0)
        {
            int random = UnityEngine.Random.Range(0, poolingObjectList.Count);
            var obj = poolingObjectList[random];


            poolingObjectList.RemoveAt(random);

            obj.transform.SetParent(null);
            obj.transform.position = currentPosition;
            obj.SetActive(true);

            if (obj.gameObject.tag.Equals("UFO"))
            {
                currentPosition.z += tileInterval * 3f;
            }
            else
            {
                currentPosition.z += tileInterval * 10f;
            }
            return obj;
        }
        else if (tileType == 1)
        {
            quizIndex1++;
            if (quizIndex1 == 3)
            {
                quizIndex1 = 0;
            }

            answerFixedTile[quizIndex1].transform.position = currentPosition;
            answerFixedTile[quizIndex1].SetActive(false);
            answerFixedTile[quizIndex1].SetActive(true);
            currentPosition.z += tileInterval * 5f;

            return answerFixedTile[quizIndex1];
        }
        else
        {
            quizIndex2++;
            if (quizIndex2 == 3)
            {
                quizIndex2 = 0;
            }

            simbolFixedTile[quizIndex2].transform.position = currentPosition;
            simbolFixedTile[quizIndex2].SetActive(false);
            simbolFixedTile[quizIndex2].SetActive(true);
            currentPosition.z += tileInterval * 5f;
            
            return simbolFixedTile[quizIndex2];
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        poolingObjectList.Add(obj);
    }

    

    public void PlayerJumpTileCreate()
    {
        tileCount++;
        quizTileCount++;
        // Debug.Log(tileCount);

        if(isNormalTile)
            Manager.currentScore += 5;

        if (isFeverEnd)
        {
            isFeverEnd = false;

            for (int i = 0; currentTerrains.Count > i; i++)
            {
                if(standingAcadeTile == currentTerrains[i])
                {
                    // 0번째 타일부터 ~ 밟은 아케이트 타일의 전전 타일까지 삭제
                    for(int j=0; j<i-1; j++)
                    {
                        ReturnObject(currentTerrains[i]);
                        currentTerrains.RemoveAt(0);
                    }
                }
            }
            
        }


        if (isQuizStart)
        {
            if (currentTerrains[0].gameObject.tag.Equals("UFO"))
            {
                waitForUFO++;
                if (waitForUFO == 3)
                {
                    var currentTerrain = currentTerrains[0];
                    ReturnObject(currentTerrain);
                    currentTerrains.RemoveAt(0);
                    waitForUFO = 0;
                    currentTerrains.Add(GetObject(0));
                    GetQuizTerrains();
                }
            }
            else
            {
                waitForBigTile++;
                if (waitForBigTile == 10)
                {
                    var currentTerrain = currentTerrains[0];
                    ReturnObject(currentTerrain);
                    currentTerrains.RemoveAt(0);
                    waitForBigTile = 0;
                    currentTerrains.Add(GetObject(0));
                    GetQuizTerrains();
                }
                if (currentTerrains.Count > maxTerrainCount)
                {
                    var currentTerrain = currentTerrains[0];
                    ReturnObject(currentTerrain);
                    currentTerrains.RemoveAt(0);
                }
            }
            
        }
        else if (isQuizPlaying)
        {
            waiForQuizmode++;

            if (waiForQuizmode == 5)
            {
                waiForQuizmode = 0;
                isQuizPlaying = false;
            }
        }
        else
            SpawnTerrain();
    }


    private void SpawnTerrain()
    {
        // int tileType = Random.Range(0, tileTypeNum);
        
        if (currentTerrains[0].gameObject.tag.Equals("UFO"))
        {
            waitForUFO++;
            if(waitForUFO == 3)
            {
                var currentTerrain = currentTerrains[0];
                ReturnObject(currentTerrain);
                currentTerrains.RemoveAt(0);
                waitForUFO = 0;
                currentTerrains.Add(GetObject(0));
                // SpawnTerrain();
            }
        }
        else
        {
            waitForBigTile++;
            if (waitForBigTile == 10)
            {
                var currentTerrain = currentTerrains[0];
                ReturnObject(currentTerrain);
                currentTerrains.RemoveAt(0);
                waitForBigTile = 0;
                currentTerrains.Add(GetObject(0));
                // SpawnTerrain();
            }
            if (currentTerrains.Count > maxTerrainCount)
            {
                var currentTerrain = currentTerrains[0];
                ReturnObject(currentTerrain);
                currentTerrains.RemoveAt(0);
            }
        }
        
        if ((quizTileCount > 18 && !isQuizPlaying && !isQuizStart) || currentQuizTerrains.Count == 0)
        {
            isQuizStart = true;
        }
    }

    void GetQuizTerrains()
    {
        isQuizStart = false;
        isQuizPlaying = true;

        tileCount++;
        quizTileCount = 0;

        int randomType = Random.Range(0, 2);
        if(randomType == 0)
        {
            GetQuiztype0();
        }
        else
        {
            GetQuiztype1();
        }

        void GetQuiztype0()
        {
            var quizTerrain = GetObject(1);
            
            if (currentQuizTerrains.Count > 1)
            {
                currentQuizTerrains[0].SetActive(false);
                currentQuizTerrains.RemoveAt(0);
            }
            currentQuizTerrains.Add(quizTerrain.gameObject);
        }

        void GetQuiztype1()
        {
            var quizTerrain = GetObject(2);
           
            if (currentQuizTerrains.Count > 1)
            {
                currentQuizTerrains[0].SetActive(false);
                currentQuizTerrains.RemoveAt(0);
            }
            currentQuizTerrains.Add(quizTerrain);
        }
    }

    public void FeverModeTile()
    {
        FeverTile();
        FeverTile();
        FeverTile();
        FeverTile();
        isFeverStart = false;
        isFeverEnd = true;
    }
    
    public void FeverTile()
    {
        int random = UnityEngine.Random.Range(0, poolingObjectList.Count - 3);
        

        // UFO는 나오면 안됨
        while (poolingObjectList[random].gameObject.CompareTag("UFO"))
        {
            random = UnityEngine.Random.Range(0, poolingObjectList.Count - 3);
        }
        var obj = poolingObjectList[random];
        poolingObjectList.RemoveAt(random);

        obj.transform.SetParent(null);
        obj.transform.position = currentPosition;
        obj.SetActive(true);
        currentTerrains.Add(obj);
        Debug.Log("피버타일생성");

        currentPosition.z += tileInterval * 10f;
    }
}
