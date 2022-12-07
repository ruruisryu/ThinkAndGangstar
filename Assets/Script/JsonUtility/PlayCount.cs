/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PCount
{
    public int count;
}
public class PlayCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SavePlayCount()
    {

        PCount count = new PCount();
        int SaveCount = LoadPlayCount();
        count.count = SaveCount++;

        string json = JsonUtility.ToJson(count);
        Debug.Log(json + "플레이횟수 DB저장");

        string fileName = "PlayCount1";
        string path = Application.dataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }

    public int LoadPlayCount()
    {
        string fileName = "PlayCount1";
        string path = Application.dataPath + "/" + fileName + ".Json";
        string json;
        try
        {
            json = File.ReadAllText(path);
        }
        catch
        {
            return 0;
        }

        PCount count = JsonUtility.FromJson<PCount>(json);

        Debug.Log(count.count + "저장된 잼");
        return count.count;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PCount
{
    public int count;
}
public class PlayCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
     public void SavePlayCount()
    {

        PCount count = new PCount();
        int SaveCount = LoadPlayCount();
        count.count = SaveCount + 1;

        string json = JsonUtility.ToJson(count);
        Debug.Log(json + "플레이횟수 DB저장");

        string fileName = "PlayCount1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }


    public int LoadPlayCount()
    {
        string fileName = "PlayCount1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json;
        try
        {
            json = File.ReadAllText(path);
        }
        catch
        {
            return 0;
        }

        PCount count = JsonUtility.FromJson<PCount>(json);

        Debug.Log(count.count + "저장된 플레이횟수");
        return count.count;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
