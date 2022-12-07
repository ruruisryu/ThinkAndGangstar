/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Record
{
    public int record;
}

public class BestRecord : MonoBehaviour
{
    public void SaveRecord(int changeValue)
    {

        Record record = new Record();
        int SaveRecord = Load();
        if (SaveRecord < changeValue)
        {
            record.record = changeValue;
            string json = JsonUtility.ToJson(record);
            Debug.Log(json + "최고기록 DB저장");

            string fileName = "BestRecord1";
            string path = Application.dataPath + "/" + fileName + ".Json";
            File.WriteAllText(path, json);
        }
    }

    public int Load()
    {
        string fileName = "BestRecord1";
        string path = Application.dataPath + "/" + fileName + ".Json";
        string json;
        try
        {
            json = File.ReadAllText(path);
        }
        catch {
            return 0;
        }
        
       
        Record record = JsonUtility.FromJson<Record>(json);

        Debug.Log(record.record + "저장된 최고기록");
        return record.record;
    }
}
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Record
{
    public int record;
}

public class BestRecord : MonoBehaviour
{
    public void SaveRecord(int changeValue)
    {

        Record record = new Record();
        int SaveRecord = Load();
        if (SaveRecord < changeValue)
        {
            record.record = changeValue;
            string json = JsonUtility.ToJson(record);
            Debug.Log(json + "최고기록 DB저장");

            string fileName = "BestRecord1";
            string path = Application.persistentDataPath + "/" + fileName + ".Json";
            File.WriteAllText(path, json);
        }
    }

    public int Load()
    {
        string fileName = "BestRecord1";
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


        Record record = JsonUtility.FromJson<Record>(json);

        Debug.Log(record.record + "저장된 최고기록");
        return record.record;
    }
}
