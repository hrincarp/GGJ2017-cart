using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int score = 0;

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "gem") {
            score++;
            text.text = score.ToString();
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "gem") {
            score--;
            text.text = score.ToString();
        }
    }
}
