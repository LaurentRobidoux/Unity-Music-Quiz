using Music.Loaders;
using Music.Entities;
using Music.Variable;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Music.Quiz
{
    public class QuestionController : MonoBehaviour
    {
        public ChoiceItem[] choiceItems;
        private Question question;

        [SerializeField]
        private PlaylistVariable playlistVariable;

        private int currentIndex = 0;
        public Animator animator;
        public SongLoader audioloader;
        public AlbumReveal albumReveal;

        [SerializeField]
        private Button nextButton;

        [SerializeField]
        private UnityEvent lastQuestionDone;

        [SerializeField]
        private UnityEvent onInit;

        public Playlist Playlist
        {
            get => playlistVariable.Value;
        }

        public void Restart()
        {
            currentIndex = 0;
            animator.enabled = true;
            results.Clear();
        }

        public Dictionary<Choice, bool> results = new Dictionary<Choice, bool>();

        private void OnEnable()
        {
            Init(playlistVariable.Value.Questions[0]);
            LoadAudio();
        }

        public void LoadAudio()
        {
            audioloader.Load(Playlist.Questions[currentIndex].Song);
        }

        public void Init(Question question)
        {
            onInit.Invoke();
            this.question = question;
            for (int index = 0; index < question.Choices.Length; index++)
            {
                choiceItems[index].Init(question.Choices[index]);
            }
            albumReveal.Preload(question.Song);
        }

        public void OutsideOfScreen()
        {
            if (currentIndex > question.Choices.Length)
            {
                lastQuestionDone.Invoke();
            }
            else
            {
                Init(Playlist.Questions[currentIndex]);

                albumReveal.Hide();
                foreach (ChoiceItem item in choiceItems)
                {
                    item.Restore();
                }
            }
        }

        public void AnimationEnded()
        {
            animator.enabled = false;
            if (currentIndex <= question.Choices.Length)
            {
                LoadAudio();
            }
        }

        public void Next()
        {
            currentIndex++;
            animator.enabled = true;
            audioloader.Stop();
            nextButton.interactable = false;
        }

        public void ChoiceSelected(ChoiceItem choiceItem)
        {
            //validate answer
            nextButton.interactable = true;
            Choice answer = this.question.Choices[this.question.AnswerIndex];
            results.Add(answer, choiceItem.choice == answer);
            if (choiceItem.choice == answer)
            {
                choiceItem.MarkCorrect();
            }
            else
            {
                choiceItem.MarkIncorrect();
            }
            foreach (ChoiceItem item in choiceItems)
            {
                if (item == choiceItem)
                {
                    continue;
                }
                if (item.choice == answer)
                {
                    item.MarkCorrect();
                }
                else
                {
                    item.Disable();
                }
            }

            albumReveal.Show();
        }
    }
}