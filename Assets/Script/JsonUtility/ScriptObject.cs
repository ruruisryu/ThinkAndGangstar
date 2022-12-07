using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class sObject
{
    public bool sobject1;
    public bool sobject2;
    public bool sobject3;
}

public class ScriptObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SaveSObjectCount(bool a, bool b, bool c)
    {

        sObject o = new sObject();

        o.sobject1 = a;
        o.sobject2 = b;
        o.sobject3 = c;

        string json = JsonUtility.ToJson(o);
        Debug.Log(json + "bool DB저장");

        string fileName = "sObject1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }


    public sObject LoadObjectCount()
    {
        string fileName = "sObject1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json;
        sObject o1 = new sObject();
        try
        {
            json = File.ReadAllText(path);
        }
        catch
        {
            o1.sobject1 = true;
            o1.sobject2 = false;
            o1.sobject3 = false;
            return o1;
        }

        sObject o = JsonUtility.FromJson<sObject>(json);

        Debug.Log(o + "저장된 bool");
        return o;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

