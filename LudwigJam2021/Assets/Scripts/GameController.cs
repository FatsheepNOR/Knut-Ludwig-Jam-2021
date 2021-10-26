using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float timer = 0;

    public bool victory = false;
    public ThirdPersonController player;
    public Text timerText;

    public GameObject winCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!victory){
            timer += Time.deltaTime;
        }
        timerText.text = TimeSpan.FromSeconds(timer).ToString(@"hh\:mm\:ss");
    }

    public void Win(){
        victory = true;
        player.enabled = false;
        winCam.SetActive(true);
    }
}
