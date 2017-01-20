using UnityEngine;
using System.Collections;

public class RandomAnimationStartTime : MonoBehaviour {

	[SerializeField] Animator _animator;
	[SerializeField] string _stateName = "Idle";

	void Start() {

		Check.Null(_animator);

		_animator.Play(_stateName, 0, Random.Range(0.0f, 1.0f));
	}
}
