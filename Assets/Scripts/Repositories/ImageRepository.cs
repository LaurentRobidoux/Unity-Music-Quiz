using Music.Entities;
using Music.Repositories.Strategies;
using System;
using System.Collections;
using UnityEngine;

namespace Music.Repositories
{
    [CreateAssetMenu(menuName = "Repository/Image")]
    public class ImageRepository : ScriptableObject
    {
        [SerializeField]
        internal PersistantDirectory persistantDirectory;

        [SerializeField]
        private BaseStrategy strategy;

        public IEnumerator GetSprite(Song song, Action<Sprite> callback, Action onError = null)
        {
            yield return strategy.GetSprite(this, song, callback, onError);
        }

        public void Unload(Sprite sprite)
        {
            strategy.Unload(sprite);
        }
    }
}