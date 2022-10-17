using TMPro;
using UnityEngine;

public class RichTextStyling : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private TextMeshProUGUI TextMesh
    {
        get
        {
            if (textMesh == null)
            {
                textMesh = GetComponent<TextMeshProUGUI>();
            }
            return textMesh;
        }
    }

    [TextArea]
    [SerializeField]
    private string TextFormat;

    public void Format(params object[] values)
    {
        TextMesh.text = string.Format(TextFormat, values);
    }
}