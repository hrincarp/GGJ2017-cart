using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finnish : MonoBehaviour {
    public Text youWinText;

	// Use this for initialization
	void Start () {
        youWinText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider collider) {
        Debug.Log (collider.gameObject.tag);
        if (collider.gameObject.tag == "Player") {
            Debug.Log ("win");
            youWinText.enabled = true;
        }
    }
}
