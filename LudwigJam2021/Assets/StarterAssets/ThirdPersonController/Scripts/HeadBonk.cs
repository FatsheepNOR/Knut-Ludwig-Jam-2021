using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class HeadBonk : MonoBehaviour
{

    public Rigidbody rb;
    public ThirdPersonController tpc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
		Debug.Log("COLLISION "+other.relativeVelocity.magnitude);
		if (other.relativeVelocity.magnitude > tpc.ragdollForce){
			tpc.EnterRagdoll();
            rb.AddForceAtPosition(other.relativeVelocity*-.03f,other.GetContact(0).point,ForceMode.Impulse);
		}

	}
}
