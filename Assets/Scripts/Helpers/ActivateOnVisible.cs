using UnityEngine;
using System.Collections;


public class ActivateOnVisible : MonoBehaviour {

	public GameObject[] _gameObjects;

	void Awake() {

		 Check.Null(GetComponent<Renderer>());
		for (int i = 0; i < _gameObjects.Length; i++) {
			_gameObjects[i].SetActive(false);
		}
	}

	void OnBecameVisible() {

		for (int i = 0; i < _gameObjects.Length; i++) {
			_gameObjects[i].SetActive(true);
		}
	}

	void OnBecameInvisible() {

		for (int i = 0; i < _gameObjects.Length; i++) {
			_gameObjects[i].SetActive(false);
		}
	}


}
