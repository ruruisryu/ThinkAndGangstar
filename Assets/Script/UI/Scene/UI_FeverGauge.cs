using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FeverGauge : MonoBehaviour
{
    [SerializeField] Slider feverGaugeSlider;
    [SerializeField] private ParticleSystem particle;


    void Start()
    {
        particle = GameObject.Find("PlayUI").transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        updateFGValue();
    }

    void updateFGValue()
    {
        feverGaugeSlider.value = Manager.feverGauge;
        if (feverGaugeSlider.value == 100)
            Util.FindChild<Button>(gameObject).interactable = true;
        
    }

    public void FeverBtnClicked()
    {
        // feverScript feverSC = new feverScript();
        GameObject.Find("Character").transform.GetChild(0).gameObject.GetComponent<feverScript>().FeverTime();
        // feverScript feverSC = GameObject.FindGameObjectWithTag("Player").GetComponent<feverScript>();
        //feverSC.FeverTime();
        particle.Play();
    }
}
