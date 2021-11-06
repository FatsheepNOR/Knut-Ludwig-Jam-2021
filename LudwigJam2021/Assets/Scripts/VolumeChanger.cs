using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;


public class VolumeChanger : MonoBehaviour
{

    public AudioMixer mixer;

    public float masterVolume = 1;
    public float SFXVolume = 1;
    public float musicVolume = 0.2f;

    public Slider master1;
    public Slider master2;
    public Slider sfx1;
    public Slider sfx2;
    public Slider music1;
    public Slider music2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMaster (float sliderValue){
        masterVolume = sliderValue;
        mixer.SetFloat("MasterVolume",Mathf.Log10(sliderValue)*20);
    }
    public void SetSFX (float sliderValue){
        SFXVolume = sliderValue;
        mixer.SetFloat("SFXVolume",Mathf.Log10(sliderValue)*20);
    }
    public void SetMusic (float sliderValue){
        musicVolume = sliderValue;
        mixer.SetFloat("MusicVolume",Mathf.Log10(sliderValue)*20);
    }

    public void SetSliders(){
        master1.value = masterVolume;
        master2.value = masterVolume;
        sfx1.value = SFXVolume;
        sfx2.value = SFXVolume;
        music1.value = musicVolume;
        music2.value = musicVolume;
    }

}
