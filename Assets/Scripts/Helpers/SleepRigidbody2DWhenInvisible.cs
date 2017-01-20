using UnityEngine;
using System.Collections;


public class SleepRigidbody2DWhenInvisible : MonoBehaviour {

	public Rigidbody2D _rigidbody2D;

	void Awake() {

		 Check.Null(GetComponent<Renderer>());
	}
		
	void OnBecameInvisible() {
		
		_rigidbody2D.Sleep();
	}		
}
