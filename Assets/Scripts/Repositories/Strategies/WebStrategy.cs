using Music.Entities;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Music.Repositories.Strategies
{
    [CreateAssetMenu(menuName = "Repository/Strategy/Web")]
    public class WebStrategy : BaseStrategy
    {
        [SerializeField]
        private bool enableCache;

        public override IEnumerator GetAudioClip(AudioRepository repository, Song song, Action<AudioClip> callback, Action onError = null)
        {
            using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(song.Sample, AudioType.WAV))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    onError.Invoke();
                }
                else
                {
                    //We handle cache here because if we do it in cache strategy, we have to convert the media back into bytes
                    if (enableCache)
                    {
                        repository.persistantDirectory.CreateDirectory();
                        File.WriteAllBytes(repository.persistantDirectory.BuildPath(song.Id + ".wav"), request.downloadHandler.data);
                    }

                    AudioClip audioClip = DownloadHandlerAudioClip.GetContent(request);
                    audioClip.hideFlags = HideFlags.HideAndDontSave;
                    callback.Invoke(audioClip);
                }
            }
        }

        public override IEnumerator GetFile(PlaylistRepository repository, Action<string> callback, Action onError)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(repository.url))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    onError.Invoke();
                }
                else
                {
                    if (enableCache)
                    {
                        File.WriteAllText(Path.Combine(Application.persistentDataPath, repository.filename), request.downloadHandler.text);
                    }

                    callback.Invoke(request.downloadHandler.text);
                }
            }
        }

        public override IEnumerator GetSprite(ImageRepository repository, Song song, Action<Sprite> callback, Action onError = null)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(song.Picture))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    onError.Invoke();
                }
                else
                {
                    if (enableCache)
                    {
                        repository.persistantDirectory.CreateDirectory();
                        File.WriteAllBytes(repository.persistantDirectory.BuildPath(song.Id + ".jpg"), request.downloadHandler.data);
                    }

                    Texture2D texture = DownloadHandlerTexture.GetContent(request);

                    Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100F, 0, SpriteMeshType.FullRect);
                    sprite.hideFlags = HideFlags.HideAndDontSave;
                    callback.Invoke(sprite);
                }
            }
        }
    }
}