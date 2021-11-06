using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float timer = 0;
    public bool paused = true;

    public bool victory = false;
    public ThirdPersonController player;
    public Text timerText;
    public Text timePBText;
    public Text timePBText2;
    public Button continueButton;

    public AudioSource music;

    public GameObject winCam;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public Transform spawnPoint;

    public float timePB = -1;
    bool firstTime = false;

    VolumeChanger volumeChanger;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        volumeChanger = GetComponent<VolumeChanger>();

        

        timePB = PlayerPrefs.GetFloat("tpb");

        firstTime = PlayerPrefs.GetInt("ft")==1?true:false;
        if(firstTime){
            timePB = -1;
            firstTime = true;
            volumeChanger.SetMaster(1);
            volumeChanger.SetSFX(1);
            volumeChanger.SetMusic(0.5f);
            volumeChanger.SetSliders();
        } else {
            volumeChanger.SetMaster(PlayerPrefs.GetFloat("vol"));
            volumeChanger.SetSFX(PlayerPrefs.GetFloat("sfx"));
            volumeChanger.SetMusic(PlayerPrefs.GetFloat("mus"));
            volumeChanger.SetSliders();
        }
        continueButton.interactable = !firstTime;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(!victory && !paused){
            timer += Time.deltaTime;

        } 
        timerText.text = TimeSpan.FromSeconds(timer).ToString(@"hh\:mm\:ss");

        if(timePB > 0){
            timePBText.text = "Personal best time: " + TimeSpan.FromSeconds(timePB).ToString(@"hh\:mm\:ss\.ff");
            timePBText2.text = "Personal best time: " + TimeSpan.FromSeconds(timePB).ToString(@"hh\:mm\:ss\.ff");
        } else {
            timePBText.text = "You have not beaten the game yet";
            timePBText2.text = "You have not beaten the game yet";
        }
        /*
        if(Input.GetKeyDown(KeyCode.M)){
            music.mute = !music.mute;
        }*/

        if(Input.GetButtonDown("Menu")){
            if(paused){
                Unpause();
            } else {
                Pause();
            }
        }

    }

    public void Win(){
        victory = true;
        player.enabled = false;
        winCam.SetActive(true);
        if(timePB <= 0 || timer<timePB){
            timePB = timer;
        }
        SaveGame();
    }

    public void Pause(){
        paused = true;
        Time.timeScale = 0;
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        SaveGame();
    }

    public void Unpause(){
        paused = false;
        Time.timeScale = 1;
        player.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void SaveGame(){
        
        PlayerPrefs.SetFloat("px",player.transform.position.x);
        PlayerPrefs.SetFloat("py",player.transform.position.y);
        PlayerPrefs.SetFloat("pz",player.transform.position.z);

        PlayerPrefs.SetFloat("rx",player.transform.rotation.x);
        PlayerPrefs.SetFloat("ry",player.transform.rotation.y);
        PlayerPrefs.SetFloat("rz",player.transform.rotation.z);
        PlayerPrefs.SetFloat("rw",player.transform.rotation.w);

        PlayerPrefs.SetInt("dj",player.hasDoubleJump?1:0);

        PlayerPrefs.SetFloat("t",timer);
        PlayerPrefs.SetFloat("tpb",timePB);

        PlayerPrefs.SetFloat("vol",volumeChanger.masterVolume);
        PlayerPrefs.SetFloat("sfx",volumeChanger.SFXVolume);
        PlayerPrefs.SetFloat("mus",volumeChanger.musicVolume);
        volumeChanger.SetSliders();

        PlayerPrefs.SetInt("ft",firstTime?1:0);
        
        PlayerPrefs.Save();
    }

    public void loadGame(){

        

        player._controller.enabled = false;
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("px"),PlayerPrefs.GetFloat("py"),PlayerPrefs.GetFloat("pz"));
        player.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("rx"),PlayerPrefs.GetFloat("ry"),PlayerPrefs.GetFloat("rz"),PlayerPrefs.GetFloat("rw"));
        player._controller.enabled = true;
        
        player.hasDoubleJump = PlayerPrefs.GetInt("dj")==1?true:false;

        timer = PlayerPrefs.GetFloat("t");
        timePB = PlayerPrefs.GetFloat("tpb");

        volumeChanger.SetMaster(PlayerPrefs.GetFloat("vol"));
        volumeChanger.SetSFX(PlayerPrefs.GetFloat("sfx"));
        volumeChanger.SetMusic(PlayerPrefs.GetFloat("mus"));
        volumeChanger.SetSliders();
        Unpause();
    }

    public void resetSave(){

        player._controller.enabled = false;
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        player._controller.enabled = true;
        volumeChanger.SetSliders();

        timer = 0;
        victory = false;
        winCam.SetActive(false);
        firstTime = false;

        SaveGame();

        Unpause();

    }

    public void deleteSave(){
        PlayerPrefs.DeleteAll();
        firstTime = true;
        Application.Quit();
    }

    public void QuitGame(){
        SaveGame();
        Application.Quit();
    }

    private void OnApplicationQuit() {
        SaveGame();
    }
}
