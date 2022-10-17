using Music.Variable;
using TMPro;
using UnityEngine;

namespace Music.Quiz
{
    public class LabelQuizName : MonoBehaviour
    {
        [SerializeField]
        private PlaylistVariable playlistVariable;

        [SerializeField]
        private TextMeshProUGUI label;

        private void OnEnable()
        {
            label.text = playlistVariable.Value.Name;
        }
    }
}