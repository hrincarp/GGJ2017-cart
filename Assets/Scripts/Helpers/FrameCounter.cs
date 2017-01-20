using UnityEngine;
using System.Collections;

public class FrameCounter : MonoBehaviour {

    private int _numberOfFrames;

	void Update() {
        _numberOfFrames++;
	}

    void OnDestroy() {
        Debug.Log("NUMBER OF FRAMES: " + _numberOfFrames);
    }
}
