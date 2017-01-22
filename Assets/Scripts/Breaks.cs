using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaks : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Collider collider = GetComponent<Collider>();
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log (collider.material.staticFriction);
            collider.material.staticFriction = Mathf.Lerp(collider.material.staticFriction, 100, 0.01f * Time.deltaTime);

            collider.material = collider.material;
            //collider.enabled = true;
        } else {
        //if (Input.GetKeyUp(KeyCode.Space)) {
            collider.material.staticFriction = Mathf.Lerp(collider.material.staticFriction, 0, 0.1f * Time.deltaTime);
            //collider.enabled = false;
            collider.material = collider.material;
        }
	}
}
