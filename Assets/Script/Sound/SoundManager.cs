using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        float savedSoundValue = GameObject.Find("JsonUtility").GetComponent<Sound>().LoadSoundValue();

        if (savedSoundValue == null || savedSoundValue > 1 || savedSoundValue < 0)
        {
            GameObject.Find("JsonUtility").GetComponent<Sound>().SaveSoundValue(0.5f);
            Load();

        }
        else
        {
            Load();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = GameObject.Find("JsonUtility").GetComponent<Sound>().LoadSoundValue();
    }

    private void Save()
    {
        GameObject.Find("JsonUtility").GetComponent<Sound>().SaveSoundValue(volumeSlider.value);
    }
}
