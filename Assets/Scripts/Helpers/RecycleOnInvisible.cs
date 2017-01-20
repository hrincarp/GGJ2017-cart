using UnityEngine;
using System.Collections;

public class RecycleOnInvisible : MonoBehaviour {

	public GameObject _gameObject;
	
	void OnBecameInvisible() {

		_gameObject.Recycle();
	}
}
