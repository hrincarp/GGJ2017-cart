using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System;

// Use this singleton pattern for singletons which are created by unity scene.
public class ExampleSingleton : Singleton<ExampleSingleton> {

	// Declare event like this. Use Event at the end.
	public event Action<string, int> SomethingDidHappenEvent; // Use comments to inform about what the parameters are.

	private void Start() {
		
		if (SomethingDidHappenEvent != null) {
			SomethingDidHappenEvent("ASDF", 1);
		}
	}
}