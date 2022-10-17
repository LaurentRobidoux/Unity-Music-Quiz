using Music.Entities;
using System;
using System.Collections;
using UnityEngine;

namespace Music.Repositories.Strategies
{
    [CreateAssetMenu(menuName = "Repository/Strategy/Resource")]
    public class ResourceStrategy : BaseStrategy
    {
        [SerializeField]
        private BaseStrategy backup;

        public override IEnumerator GetAudioClip(AudioRepository repository, Song song, Action<AudioClip> callback, Action onError = null)
        {
            ResourceRequest resourceRequest = Resources.LoadAsync<AudioClip>(repository.persistantDirectory.folderName + "/" + song.Id);
            yield return resourceRequest;
            if (resourceRequest.asset == null)
            {
                if (backup == null)
                {
                    onError?.Invoke();
                }
                else
                {
                    yield return backup.GetAudioClip(repository, song, callback, onError);
                }
            }
            else
            {
                callback.Invoke((AudioClip)resourceRequest.asset);
            }
        }

        public override void Unload(AudioClip clip)
        {
            if (clip.hideFlags != HideFlags.HideAndDontSave)
            {
                Resources.UnloadAsset(clip);
            }
            else
            {
                backup.Unload(clip);
            }
        }

        public override void Unload(Sprite sprite)
        {
            if (sprite.hideFlags != HideFlags.HideAndDontSave)
            {
                Resources.UnloadAsset(sprite);
            }
            else
            {
                backup.Unload(sprite);
            }
        }

        public override IEnumerator GetSprite(ImageRepository repository, Song song, Action<Sprite> callback, Action onError = null)
        {
            ResourceRequest resourceRequest = Resources.LoadAsync<Sprite>(repository.persistantDirectory.folderName + "/" + song.Id);
            yield return resourceRequest;
            if (resourceRequest.asset == null)
            {
                if (backup == null)
                {
                    onError?.Invoke();
                }
                else
                {
                    yield return backup.GetSprite(repository, song, callback, onError);
                }
            }
            else
            {
                callback.Invoke((Sprite)resourceRequest.asset);
            }
        }

        public override IEnumerator GetFile(PlaylistRepository repository, Action<string> callback, Action onError)
        {
            ResourceRequest resourceRequest = Resources.LoadAsync<TextAsset>(repository.filename);
            yield return resourceRequest;
            if (resourceRequest.asset == null)
            {
                if (backup == null)
                {
                    onError?.Invoke();
                }
                else
                {
                    yield return backup.GetFile(repository, callback, onError);
                }
            }
            else
            {
                TextAsset textAsset = resourceRequest.asset as TextAsset;
                callback.Invoke(textAsset.text);
            }
        }
    }
}