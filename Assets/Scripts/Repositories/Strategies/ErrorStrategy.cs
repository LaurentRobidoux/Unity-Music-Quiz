using System;
using System.Collections;
using UnityEngine;
using Music.Entities;

namespace Music.Repositories.Strategies
{
    [CreateAssetMenu(menuName = "Repository/Strategy/Error")]
    public class ErrorStrategy : BaseStrategy
    {
        [SerializeField]
        private BaseStrategy backup;

        public override IEnumerator GetAudioClip(AudioRepository repository, Song song, Action<AudioClip> callback, Action onError = null)
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorPrefs.GetBool("No Internet"))
            {
                yield return new WaitForSeconds(0.1f);
                onError?.Invoke();
            }
            else
            {
#endif
                yield return backup.GetAudioClip(repository, song, callback, onError);
#if UNITY_EDITOR
            }
#endif
        }

        public override IEnumerator GetFile(PlaylistRepository repository, Action<string> callback, Action onError)
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorPrefs.GetBool("No Internet"))
            {
                yield return new WaitForSeconds(0.1f);
                onError?.Invoke();
            }
            else
            {
#endif
                yield return backup.GetFile(repository, callback, onError);
#if UNITY_EDITOR
            }
#endif
        }

        public override IEnumerator GetSprite(ImageRepository repository, Song song, Action<Sprite> callback, Action onError = null)
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorPrefs.GetBool("No Internet"))
            {
                yield return new WaitForSeconds(0.1f);
                onError?.Invoke();
            }
            else
            {
#endif
                yield return backup.GetSprite(repository, song, callback, onError);
#if UNITY_EDITOR
            }
#endif
        }
    }
}