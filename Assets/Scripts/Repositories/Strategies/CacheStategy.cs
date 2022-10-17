using Music.Entities;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Music.Repositories.Strategies
{
    [CreateAssetMenu(menuName = "Repository/Strategy/Cache")]
    public class CacheStategy : BaseStrategy
    {
        [SerializeField]
        private BaseStrategy backup;

        public override IEnumerator GetSprite(ImageRepository repository, Song song, Action<Sprite> callback, Action onError = null)
        {
            string filepath = repository.persistantDirectory.BuildPath(song.Id + ".jpg");
            if (File.Exists(filepath))
            {
                using (UnityWebRequest request = UnityWebRequestTexture.GetTexture("File://" + filepath))
                {
                    yield return request.SendWebRequest();
                    if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                    {
                        onError.Invoke();
                    }
                    else
                    {
                        Texture2D texture = DownloadHandlerTexture.GetContent(request);

                        Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100F, 0, SpriteMeshType.FullRect);
                        sprite.hideFlags = HideFlags.HideAndDontSave;
                        callback.Invoke(sprite);
                    }
                }
            }
            else
            {
                yield return backup.GetSprite(repository, song, callback, onError);
            }
        }

        public override IEnumerator GetAudioClip(AudioRepository repository, Song song, Action<AudioClip> callback, Action onError = null)
        {
            string filepath = repository.persistantDirectory.BuildPath(song.Id + ".wav");
            if (File.Exists(filepath))
            {
                using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("File://" + filepath, AudioType.WAV))
                {
                    yield return request.SendWebRequest();
                    if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                    {
                        onError.Invoke();
                    }
                    else
                    {
                        AudioClip audioClip = DownloadHandlerAudioClip.GetContent(request);
                        audioClip.hideFlags = HideFlags.HideAndDontSave;
                        callback.Invoke(audioClip);
                    }
                }
            }
            else
            {
                yield return backup.GetAudioClip(repository, song, callback, onError);
            }
        }

        public override IEnumerator GetFile(PlaylistRepository repository, Action<string> callback, Action onError)
        {
            string filepath = Path.Combine(Application.persistentDataPath, repository.filename);
            if (File.Exists(filepath))
            {
                using (UnityWebRequest request = UnityWebRequest.Get("File://" + filepath))
                {
                    yield return request.SendWebRequest();
                    if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                    {
                        onError?.Invoke();
                    }
                    else
                    {
                        callback.Invoke(request.downloadHandler.text);
                    }
                }
            }
            else
            {
                yield return backup.GetFile(repository, callback, onError);
            }
        }
    }
}