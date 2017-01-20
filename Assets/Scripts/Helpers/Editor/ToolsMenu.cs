using UnityEngine;
using System.Collections;
using UnityEditor;

public class ToolsMenu : MonoBehaviour {

    [MenuItem ("Tools/Reset Player Prefs")]
    static void ResetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }
}