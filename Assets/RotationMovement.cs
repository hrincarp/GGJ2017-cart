using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown (KeyCode.RightArrow)) {
            Rigidbody rigidbody = GetComponent<Rigidbody> ();
            rigidbody.AddTorque (new Vector3 (0f, 0f, -100f));
            Debug.Log ("test");
        }
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            Rigidbody rigidbody = GetComponent<Rigidbody> ();
            rigidbody.AddTorque (new Vector3 (0f, 0f, 100f));
            Debug.Log ("test");
        }
	}
    void FixedUpdate() { 
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        //Set non essential angles to 0.
        eulerRotation.x = 0;
        eulerRotation.y = 0;

        //Reset the transform rotation.
        transform.rotation = Quaternion.Euler(eulerRotation);

        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }
}
