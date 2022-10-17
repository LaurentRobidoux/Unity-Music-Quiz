using Music.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Music.Quiz
{
    public class ChoiceItem : MonoBehaviour
    {
        [SerializeField]
        private QuestionController questionController;

        [SerializeField]
        private TextMeshProUGUI textMesh;

        [TextArea]
        [SerializeField]
        private string template;

        public Choice choice;

        [SerializeField]
        private Color goodColor;

        [SerializeField]
        private Color incorrectColor;

        [SerializeField]
        private Color disabledColor;

        [SerializeField]
        private Color normalColor;

        [SerializeField]
        private Button button;

        public void Init(Choice choice)
        {
            this.choice = choice;
            textMesh.text = string.Format(template, choice.Title, choice.Artist);
        }

        public void OnClick()
        {
            questionController.ChoiceSelected(this);
        }

        public void Restore()
        {
            this.button.transition = Selectable.Transition.ColorTint;
            this.button.image.color = normalColor;
            this.button.interactable = true;
        }

        public void Disable()
        {
            this.button.image.color = disabledColor;
            DisableInteraction();
        }

        public void DisableInteraction()
        {
            this.button.transition = Selectable.Transition.None;
            this.button.interactable = false;
        }

        public void MarkCorrect()
        {
            this.button.image.color = goodColor;
            DisableInteraction();
        }

        public void MarkIncorrect()
        {
            this.button.image.color = incorrectColor;
            DisableInteraction();
        }
    }
}