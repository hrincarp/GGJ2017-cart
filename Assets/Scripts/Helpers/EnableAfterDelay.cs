using UnityEngine;
using System.Collections;

public class EnableAfterDelay : MonoBehaviour {

	[SerializeField] MonoBehaviour _component;

	private IEnumerator Start() {
		yield return new WaitForEndOfFrame();
		_component.enabled = true;
	}
}
