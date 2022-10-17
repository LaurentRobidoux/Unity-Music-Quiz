using UnityEngine;

namespace Music.Animations
{
    public class ContinusScale : MonoBehaviour
    {
        [SerializeField] private AnimationCurve curve = default;
        [SerializeField] private float speedMultiplier = 1.0f;
        [SerializeField] private Vector3 finalScale = default;
        private Vector3 startScale;
        private float graphValue;

        private void Awake()
        {
            startScale = transform.localScale;
        }

        private void Update()
        {
            graphValue = curve.Evaluate(Time.time * speedMultiplier);
            transform.localScale = new Vector3(finalScale.x * startScale.x, finalScale.y * startScale.y, startScale.z * startScale.z) * graphValue;
        }
    }
}