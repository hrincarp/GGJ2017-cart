using UnityEngine;
using System.Collections;

public class InstantiatePrefab : MonoBehaviour {

	public GameObject _prefab;

	void Awake() {

		GameObject go = (GameObject)Instantiate(_prefab);
		Transform newObjectTransform = go.transform;
		Transform thisTransform = transform;
		newObjectTransform.parent = thisTransform.parent;
		newObjectTransform.localPosition = thisTransform.localPosition;
		newObjectTransform.localRotation = thisTransform.localRotation;
		newObjectTransform.localScale = thisTransform.localScale;
	}
}
