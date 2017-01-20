using UnityEngine;
using System.Collections;


public class EnableOnVisible : MonoBehaviour {

	public event System.Action<bool> VisibilityChangedEvent;

	public Behaviour[] _components;
	
	void Awake() {
		
		 Check.Null(GetComponent<Renderer>());
		for (int i = 0; i < _components.Length; i++) {
			_components[i].enabled = false;
		}
	}
	
	void OnBecameVisible() {
		
		for (int i = 0; i < _components.Length; i++) {
			_components[i].enabled = true;
		}

		if (VisibilityChangedEvent != null) {
			VisibilityChangedEvent(true);
		}
	}
	
	void OnBecameInvisible() {
		
		for (int i = 0; i < _components.Length; i++) {
			_components[i].enabled = false;
		}

		if (VisibilityChangedEvent != null) {
			VisibilityChangedEvent(false);
		}
	}	
}
