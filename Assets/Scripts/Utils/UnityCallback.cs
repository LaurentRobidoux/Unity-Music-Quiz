using UnityEngine;
using UnityEngine.Events;

namespace Music.Utils
{
    public class UnityCallback : MonoBehaviour
    {
        public UnityEvent onEnable;

        private void OnEnable()
        {
            onEnable.Invoke();
        }

        public UnityEvent onDisable;

        private void OnDisable()
        {
            onDisable.Invoke();
        }
    }
}