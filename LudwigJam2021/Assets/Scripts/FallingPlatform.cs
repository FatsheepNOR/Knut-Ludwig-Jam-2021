using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool isTriggered = false;
    public bool hasFallen = false;

    private float fallStamp = 0;


    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Fall", isTriggered);
        if(fallStamp<Time.time){
            isTriggered = false;
        }
    }


    public void TriggerFall(){
        isTriggered = true;
        fallStamp = Time.time + 5;
    }
}
