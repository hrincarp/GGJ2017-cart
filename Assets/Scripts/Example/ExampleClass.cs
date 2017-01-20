using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions; // Add this to use assertions.

public class ExampleClass : MonoBehaviour {

	// Class, Struct, Enum ... names start with capital letter.
	// Methods - start with capital letter.
	// Private member variables start with _
	// Public member variables and properties start with lowercase letter.
	// Access modifiers should be used before all elements except when using [SerializeField].

	// Use [SerializeField] for private member variables which can be set by unity editor.
	[SerializeField] Transform _otherObjectTransform;

	// Public member variable. Not used very often.
	public string publicString;

	// Enum
	public enum MyEnum {
		Value1,
		Value2,
	}

	// Property 
	public MyEnum otherParam {
		get { return _otherParam; }
		set { _otherParam = value; }
	}

	// Variable used with property.
	private MyEnum _otherParam;

	// Cache singletons
	private ExampleSingleton _singleton;
	
	// Mark all unity callback methods as private.
	private void Awake() {

		// Check all objects which should exist in awake (are set in editor) with assertion.
		Assert.IsNotNull(_otherObjectTransform);
	}

	private void Start() {

		// Cache singleton (no need to use assertion here, singletons are checked in their implementation)
		_singleton = ExampleSingleton.Instance;

		// Register for events.
		// Don't use Lambdas if the event is called often. It creates garbage.
		_singleton.SomethingDidHappenEvent += HandleSomethingDidHappenEvent;

		// Coroutine example
	}

	// Don't use empty updates
	private void Update() {

		// OTHER TIPS
		// Don't use foreach
	}

	// Called when object is being destroyed.
	private void OnDestroy() {

		// Unregister from event.
		if (_singleton != null) {
			_singleton.SomethingDidHappenEvent -= HandleSomethingDidHappenEvent;
		}
	}

	private void HandleSomethingDidHappenEvent(string arg1, int arg2) {
	}

	private IEnumerator CoroutineExample(int param) {

		// Always cache yield instructions.
		YieldInstruction yieldInstruction = new WaitForSeconds(1.0f);

		int counter = 0;
		while (counter < param) {
			counter++;
			yield return yieldInstruction;
		}
	}
}