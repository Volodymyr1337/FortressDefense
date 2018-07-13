using UnityEditor;
using UnityEngine;

public class Admin : MonoBehaviour
{

    [MenuItem("Fortress/Clear Prefs", priority = 1)]
    private static void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Prefs removed.");
    }
}