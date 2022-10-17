using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneController : ScriptableObject
{
    public static void OpenQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public static void OpenMainMenu()
    {
        SceneManager.LoadScene("Hub");
    }
}