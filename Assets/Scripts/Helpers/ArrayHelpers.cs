using UnityEngine;
using System.Collections;
using System;

public static class ArrayHelpers {

	public static T[] CreateOrEnlargeArray<T>(T[] array, int minimumCapacity) {

		// Create
		if (array == null) {
			return new T[minimumCapacity + 1];
		}
		// Enlarge
		else if (array.Length <= minimumCapacity) {
			T[] newArray = new T[minimumCapacity + 1];
			Array.Copy(array, newArray, array.Length);
			return newArray;
		}

		// Nothing
		return array;
	}
}
