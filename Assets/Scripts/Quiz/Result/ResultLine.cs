using Music.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Music.Quiz.Result
{
    public class ResultLine : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent isValid;

        [SerializeField]
        private UnityEvent isInvalid;

        [SerializeField]
        private RichTextStyling title;

        public void Init(Choice choice, bool valid)
        {
            title.Format(choice.Title, choice.Artist);
            if (valid)
            {
                isValid.Invoke();
            }
            else
            {
                isInvalid.Invoke();
            }
        }
    }
}