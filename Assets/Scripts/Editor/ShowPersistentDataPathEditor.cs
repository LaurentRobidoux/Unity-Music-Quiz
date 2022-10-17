using UnityEditor;
using UnityEngine;

public class ShowPersistentDataPathEditor : Editor
{
    [MenuItem("Tools/Reveal PersistentDatapath in Explorer")]
    public static void ShowPersistentDataPath()
    {
        string path = Application.persistentDataPath + "/";
        Application.OpenURL(string.Format("file://{0}", path));
        Debug.Log("PersistentDataPath located in: " + path);
    }
}