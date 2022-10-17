using Music.Entities;
using Music.Repositories.Strategies;
using System;
using System.Collections;
using UnityEngine;

namespace Music.Repositories
{
    [CreateAssetMenu(menuName = "Repository/Audio")]
    public class AudioRepository : ScriptableObject
    {
        [SerializeField]
        private BaseStrategy strategy;

        [SerializeField]
        internal PersistantDirectory persistantDirectory;

        public IEnumerator GetAudioClip(Song song, Action<AudioClip> callback, Action onError = null)
        {
            yield return strategy.GetAudioClip(this, song, callback, onError);
        }

        public void Unload(AudioClip clip)
        {
            strategy.Unload(clip);
        }
    }
}