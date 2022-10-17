using TMPro;
using UnityEngine;

namespace Music.PlaylistSelection
{
    public class RandomLine : MonoBehaviour
    {
        public string filename;
        public TextMeshProUGUI textMesh;

        private void OnEnable()
        {
            string[] lines = Resources.Load<TextAsset>(filename).text.Split('\n');
            int index = UnityEngine.Random.Range(0, lines.Length);
            textMesh.text = lines[index];
        }
    }
}