using UnityEngine;
using System.Collections;


public class ShowHideAnimationController : MonoBehaviour {

	public Animator _animator;
	public bool _deactivateSelfAfterDelay;
	public float _deactivationDelay = 1.0f;

	public bool Show {
		set {
			if (_show == value) {
				return;
			}

			// Activate
			gameObject.SetActive(true);

			// Switch animation state
			_animator.SetBool(_showAnimatorParam, value);

			// Deactivate after delay
			System.Func<float, IEnumerator> func = DeactivateSelfAfterDelayCoroutine;
			StopCoroutine(func.Method.Name);
			if (value == false && _deactivateSelfAfterDelay) {
				StartCoroutine(func.Method.Name, _deactivationDelay);
			}

			_show = value;
		}
		get {
			return _show;
		}
	}

	private bool _show;
	private int _showAnimatorParam;

	void Awake() {

		 Check.Null(_animator);
		_showAnimatorParam = Animator.StringToHash("Show");
		_show = _animator.GetBool(_showAnimatorParam);
	}

	private IEnumerator DeactivateSelfAfterDelayCoroutine(float delay) {

		yield return new WaitForSeconds(delay);
		gameObject.SetActive(false);
	}
}
