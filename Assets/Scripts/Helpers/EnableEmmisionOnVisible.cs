using UnityEngine;
using System.Collections;


public class EnableEmmisionOnVisible : MonoBehaviour {

    [SerializeField] ParticleSystem[] _particleSystems;

    private ParticleSystem.EmissionModule[] _emmisionModules;

	void Awake() {
		
		Check.Null(GetComponent<Renderer>());

        _emmisionModules = new ParticleSystem.EmissionModule[_particleSystems.Length];

		for (int i = 0; i < _particleSystems.Length; i++) {
            _emmisionModules[i] = _particleSystems[i].emission;
            _emmisionModules[i].enabled = false;
		}
	}
	
	void OnBecameVisible() {
		
		for (int i = 0; i < _particleSystems.Length; i++) {
            _emmisionModules[i].enabled = true;
		}
	}
	
	void OnBecameInvisible() {
		
		for (int i = 0; i < _particleSystems.Length; i++) {
            _emmisionModules[i].enabled = false;
		}
	}
}
