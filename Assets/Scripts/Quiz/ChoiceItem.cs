using Music.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Quiz
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

        public void Init(Choice choice)
        {
            this.choice = choice;
            textMesh.text = string.Format(template, choice.Title, choice.Artist);
        }

        public void OnClick()
        {
            questionController.ChoiceSelected(this);
        }
    }
}