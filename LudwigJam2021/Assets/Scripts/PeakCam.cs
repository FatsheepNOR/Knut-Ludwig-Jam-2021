using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PeakCam : MonoBehaviour
{
    public float blendFactor = 0;
    public bool isAtPeak = false;

    public CinemachineMixingCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isAtPeak){
            blendFactor-= 1*Time.deltaTime;
        }

        

        blendFactor = Mathf.Clamp(blendFactor,0f,1f);
        cam.SetWeight(0,blendFactor);
        cam.SetWeight(1,1-blendFactor);
    }

    void OnTriggerStay(Collider other) {
        isAtPeak = true;
        blendFactor+= 1*Time.deltaTime;
    }

    private void OnTriggerExit(Collider other) {
        isAtPeak = false;
    }
}
