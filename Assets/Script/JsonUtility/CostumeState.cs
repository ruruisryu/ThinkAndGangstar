using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Costume
{
    public string costume;
}
public class CostumeState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SaveCostume(string CurrentValue)
    {

        Costume costume = new Costume();
        costume.costume = CurrentValue;

        string json = JsonUtility.ToJson(costume);
        Debug.Log(json + "현재 코스튬 string DB저장");

        string fileName = "Costume1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }

    public string LoadCostume()
    {
        string fileName = "Costume1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json;
        try
        {
            json = File.ReadAllText(path);
        }
        catch
        {
            return "";
        }
        Costume costume = JsonUtility.FromJson<Costume>(json);

        Debug.Log(costume.costume + "저장된 코스튬");
        return costume.costume;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
