using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music0;
    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;


    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!gc.paused){
            music0.gameObject.SetActive(true);
            music1.gameObject.SetActive(true);
            music2.gameObject.SetActive(true);
            music3.gameObject.SetActive(true);
        }
        if(gc.player.transform.position.y >= 140) {
            music0.volume -= Time.deltaTime;
            music1.volume -= Time.deltaTime;
            music2.volume -= Time.deltaTime;
            music3.volume -= Time.deltaTime;
        } else if(gc.player.transform.position.y < 10) {
            music0.volume += Time.deltaTime;
            music1.volume -= Time.deltaTime;
            music2.volume -= Time.deltaTime;
            music3.volume -= Time.deltaTime;
        } else if(gc.player.transform.position.y >= 10 && gc.player.transform.position.y < 50) {
            music0.volume -= Time.deltaTime;
            music1.volume += Time.deltaTime;
            music2.volume -= Time.deltaTime;
            music3.volume -= Time.deltaTime;
        } else if(gc.player.transform.position.y >= 50 && gc.player.transform.position.y < 98) {
            music0.volume -= Time.deltaTime;
            music1.volume -= Time.deltaTime;
            music2.volume += Time.deltaTime;
            music3.volume -= Time.deltaTime;
        } else if(gc.player.transform.position.y >= 98 && gc.player.transform.position.y < 140) {
            music0.volume -= Time.deltaTime;
            music1.volume -= Time.deltaTime;
            music2.volume -= Time.deltaTime;
            music3.volume += Time.deltaTime;
        }
    }
}
