using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaks : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log ("space");
            boxCollider2D.enabled = true;
        } 
        if (Input.GetKeyUp(KeyCode.Space)) {
            boxCollider2D.enabled = false;
        }
	}
}
