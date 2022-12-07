using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SoundValue
{
    public float musicVolume;

}
public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveSoundValue(float changeValue)
    {

        SoundValue sound= new SoundValue();
       
        sound.musicVolume = changeValue;

        string json = JsonUtility.ToJson(sound);
        Debug.Log(json + "º¼·ýÅ©±â DBÀúÀå");

        string fileName = "Sound1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }

    public float LoadSoundValue()
    {
        string fileName = "Sound1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json;
        try
        {
            json = File.ReadAllText(path);
        }
        catch
        {
            return 0.0f;
        }
        SoundValue sound = JsonUtility.FromJson<SoundValue>(json);

        Debug.Log(sound.musicVolume + "ÀúÀåµÈ º¼·ýÅ©±â");
        return sound.musicVolume;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
