using UnityEngine;
using System.Collections;
using System;

public static class Check {
	
    public static void Null(UnityEngine.Object obj) {

        #if (UNITY_EDITOR)
        if (obj == null) {
            Debug.LogError("Object should not be null.");
        }
        #endif
    }

	public static void Array(UnityEngine.Object[] objs, int expectedCount, bool minimum = false) {
		
        #if (UNITY_EDITOR)
		if (expectedCount > 0 && ((!minimum && objs.Length != expectedCount) || (minimum && objs.Length < expectedCount))) {
			Debug.LogError("Array is not as long as expected.");
			return;
		}
		
		for (int i = 0; i < objs.Length; i++) {
			
			if (objs[i] == null) {
				Debug.LogError("Element in this array should not be null.");
				return;
			}
		}
        #endif
	}

	public static void LayerMask(LayerMask layerMask) {

        #if (UNITY_EDITOR)
		if (layerMask.value == 0) {
			Debug.LogError("Layer mask should not be empty.");
		}
        #endif
	}
	
	public static void Zero(int num) {

        #if (UNITY_EDITOR)
		if (num == 0) {
			Debug.LogError("This variable should not be 0.");
		}
        #endif
	}
	
	public static void String(string s) {

        #if (UNITY_EDITOR)
		if (s == null || s == "") {
			Debug.LogError("This string should not be null or empty");
		}
        #endif
	}
}

public static class ExtensionMethods {
	
	public static bool ContainsLayer(this LayerMask layerMask, int layer) {
		
		return (layerMask.value & (1 << layer)) != 0;
	}

	public static Color SaturatedColor(this Color color, float saturation) {

		float h, s, v;

		RGBToHSV(color, out h, out s, out v);
		s = saturation;
		return HSVToRGB(h, s, v);
	}

	public static Color ColorWithAlpha(this Color color, float alpha) {

		color.a = alpha;
		return color;
	}

	public static Color ColorWithValue(this Color color, float value) {
		
		float h, s, v;

		RGBToHSV(color, out h, out s, out v);
		v = value;
		return HSVToRGB(h, s, v);
	}

	public static void RGBToHSV(Color c, out float h, out float s, out float v) {
			
		float r = c.r;
		float g = c.g;
		float b = c.b;
		
		float min, max, delta;
		min = Mathf.Min(Mathf.Min(r, g), b);
		max = Mathf.Max(Mathf.Max(r, g), b);
		v = max;
		delta = max - min;
		
		if (max != 0.0f)
			s = delta / max;
		else {
			// r = g = b = 0		// s = 0, v is undefined
			v = 0;
			s = 0;
			h = 0;
			return;
		}
		if (r == max) {
			h = ( g - b ) / delta;		// between yellow & magenta
		}
		else if (g == max) {
			h = 2 + ( b - r ) / delta;	// between cyan & yellow
		}
		else {
			h = 4 + ( r - g ) / delta;	// between magenta & cyan
		}
		h *= 60;				// degrees
		if (h < 0) {
			h += 360;
		}
	}

	public static Color HSVToRGB(float h, float s, float v) {
		
		while (h < 0) { h += 360; };
		while (h >= 360) { h -= 360; };
		
		float hf = h / 60.0f;
		int i = Mathf.FloorToInt(hf);
		float f = hf - i;
		float pv = v * (1 - s);
		float qv = v * (1 - s * f);
		float tv = v * (1 - s * (1 - f));
		
		switch(i) {
			
		case 0: return new Color(v, tv, pv);
		case 1: return new Color(qv, v, pv);
		case 2: return new Color(pv, v, tv);
		case 3: return new Color(pv, qv, v);
		case 4: return new Color(tv, pv, v);
		case 5: return new Color(v, pv, qv);
		case 6: return new Color(v, tv, pv);
		case -1: return new Color(v, pv, qv);
		default: return new Color(v, v, v);
			
		}
	}

	public static Coroutine StartUniqueCoroutine(this MonoBehaviour m, System.Func<IEnumerator> func) {

		m.StopCoroutine(func.Method.Name);
		return m.StartCoroutine(func.Method.Name);
	}
	
	public static Coroutine StartUniqueCoroutine<T>(this MonoBehaviour m, System.Func<T, IEnumerator> func, T value) {

		m.StopCoroutine(func.Method.Name);
		return m.StartCoroutine(func.Method.Name, value);
	}

	public static void StopUniqueCoroutine(this MonoBehaviour m, System.Func<IEnumerator> func) {
		
		m.StopCoroutine(func.Method.Name);
	}

	public static void StopUniqueCoroutine<T>(this MonoBehaviour m, System.Func<T, IEnumerator> func) {
		
		m.StopCoroutine(func.Method.Name);
	}
}

public static class EssentialHelpers {

    public static double CurrentTimeStamp {
        get {
            return DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}