using UnityEngine;
using System.Collections;

public class TweenPosition : MonoBehaviour {

	public bool _unscaledTime;
	public bool _localPosition;
	public float _duration = 1.0f;
	public AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);

	public Vector3 TargetPos {
		set {
			if (TargetPos == value) {
				return;
			}
			_targetPos = value;
			AnimateToNewPos(_targetPos);
		}
		get {
			return _targetPos;
		}
	}
	
	private Transform _transform;
	private Vector3 _targetPos;

	void Awake() {
		_transform = transform;
	
	}

	private void AnimateToNewPos(Vector3 pos) {
		this.StartUniqueCoroutine(AnimateToNewPosCoroutine, pos);
	}

	private IEnumerator AnimateToNewPosCoroutine(Vector3 pos) {

		Vector3 startPos = _localPosition ? _transform.localPosition : _transform.position;
		float elapsedTime = 0.0f;

		while (elapsedTime < _duration) {

			if (_localPosition) {
				_transform.localPosition = Vector3.Lerp(startPos, _targetPos, _animationCurve.Evaluate(elapsedTime / _duration));
			}
			else {
				_transform.position = Vector3.Lerp(startPos, _targetPos, _animationCurve.Evaluate(elapsedTime / _duration));
			}

			elapsedTime += _unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		if (_localPosition) {
			_transform.localPosition = _targetPos;
		}
		else {
			_transform.position = _targetPos;
		}
	}
}
