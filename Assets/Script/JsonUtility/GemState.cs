using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Gem
{
    public int gem;
}
public class GemState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SaveGem(int changeValue)
    {
        
        Gem gemState = new Gem();
        int SaveGem = Load();
        gemState.gem = SaveGem + changeValue;
        
        string json = JsonUtility.ToJson(gemState);
        Debug.Log(json + "¿Î DB¿˙¿Â");
        
        string fileName = "Gem1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }

    public int Load()
    {
        string fileName = "Gem1";
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
        Gem gemState = JsonUtility.FromJson<Gem>(json);

        Debug.Log(gemState.gem + "¿˙¿Âµ» ¿Î");
        return gemState.gem;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
