using Music.Entities;
using Music.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Quiz
{
    public class QuestionController : MonoBehaviour
    {
        public ChoiceItem[] choiceItems;
        private Question question;

        [SerializeField]
        private PlaylistVariable playlistVariable;

        private int currentIndex = 0;

        public Playlist Playlist
        {
            get => playlistVariable.Value;
        }

        private void OnEnable()
        {
            Init(Playlist.Questions[0]);
        }

        public void Init(Question question)
        {
            this.question = question;
            for (int index = 0; index < question.Choices.Length; index++)
            {
                choiceItems[index].Init(question.Choices[index]);
            }
        }

        public void ChoiceSelected(ChoiceItem choiceItem)
        {
            //validate answer
        }
    }
}