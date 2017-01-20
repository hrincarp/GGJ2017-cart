using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
public class VisibilityChecker : MonoBehaviour {

    public event System.Action OnBecameVisibleEvent;
    public event System.Action OnBecameInvisibleEvent;

    void OnBecameVisible() {

        if (OnBecameVisibleEvent != null) {
            OnBecameVisibleEvent();
        }
    }

    void OnBecameInvisible() {
        
        if (OnBecameInvisibleEvent != null) {
            OnBecameInvisibleEvent();
        }
    }
}
