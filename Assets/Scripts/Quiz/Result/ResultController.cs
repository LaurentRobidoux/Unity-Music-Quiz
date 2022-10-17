using Music.Utils;
using Music.Entities;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Music.Quiz.Result
{
    public class ResultController : MonoBehaviour
    {
        [SerializeField]
        private QuestionController questionController;

        [SerializeField]
        private ResultLine prefab;

        [SerializeField]
        private Transform container;

        private ItemPool<ResultLine> resultPool = new ItemPool<ResultLine>();

        [SerializeField]
        private TextMeshProUGUI score;

        [SerializeField]
        private TextMeshProUGUI total;

        private void OnEnable()
        {
            score.text = questionController.results.Values.Where(t => t).Count().ToString();
            total.text = questionController.results.Count.ToString();
            int index = 0;
            foreach (Choice item in questionController.results.Keys)
            {
                resultPool.Get(prefab, index, container).Init(item, questionController.results[item]);
                index++;
            }
        }
    }
}