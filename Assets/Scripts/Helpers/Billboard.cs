using UnityEngine;
using System.Collections;


public class Billboard : MonoBehaviour {
	
	private Transform _mainCameraTransform;
	private Transform _transform;

	void Start () {

		 Check.Null(GetComponent<Renderer>());
		_mainCameraTransform = Camera.main.gameObject.transform;
		_transform = transform;
	}

	void LateUpdate() {
		_transform.LookAt(_mainCameraTransform);
	}

	void OnBecameVisible() {
		enabled = true;
	}

	void OnBecameInvisible() {
		enabled = false;
	}
}
