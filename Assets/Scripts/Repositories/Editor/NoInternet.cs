using UnityEditor;

namespace Music.Repositories.Editor
{
    [InitializeOnLoad]
    public static class NoInternet
    {
        [MenuItem("Tools/No Internet", priority = -100)]
        private static void ToggleAction()
        {
            bool value = EditorPrefs.GetBool("No Internet", false);
            EditorPrefs.SetBool("No Internet", !value);
            Menu.SetChecked("Tools/No Internet", !value);
        }
    }
}