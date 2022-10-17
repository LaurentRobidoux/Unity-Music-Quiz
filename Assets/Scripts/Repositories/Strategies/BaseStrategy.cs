using Music.Entities;
using System;
using System.Collections;
using UnityEngine;

namespace Music.Repositories.Strategies
{
    /// <summary>
    /// Doing it this way allows the implementation of new features (and removal) easily without creating a masive
    /// block of code
    /// </summary>
    public abstract class BaseStrategy : ScriptableObject
    {
        public virtual void Unload(AudioClip clip)
        {
            if (clip.hideFlags == HideFlags.HideAndDontSave)
            {
                Destroy(clip);
            }
        }

        public virtual void Unload(Sprite sprite)
        {
            if (sprite.hideFlags == HideFlags.HideAndDontSave)
            {
                Destroy(sprite.texture);
                Destroy(sprite);
            }
        }

        public abstract IEnumerator GetFile(PlaylistRepository repository, Action<string> callback, Action onError);

        public abstract IEnumerator GetSprite(ImageRepository repository, Song song, Action<Sprite> callback, Action onError = null);

        public abstract IEnumerator GetAudioClip(AudioRepository audioRepository, Song song, Action<AudioClip> callback, Action onError = null);
    }
}