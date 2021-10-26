using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSpin : MonoBehaviour
{
    public bool PB = false;
    public bool face = true;
    public bool locked = false;
    public Transform target;

    private float PBHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!locked){
        if(PB){
            if(target.transform.position.y > PBHeight){
                transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
                PBHeight = transform.position.y;
            }

        } else {
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);

            if(transform.position.y > PBHeight){
                PBHeight = transform.position.y;
            }
        }
        }

        if(face){
            transform.LookAt(target);
            Vector3 eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }
    }
}
