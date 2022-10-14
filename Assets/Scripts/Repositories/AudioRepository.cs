using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Music.Repositories
{
    [CreateAssetMenu(menuName = "Repository/Audio")]
    public class AudioRepository : ScriptableObject
    {
        [SerializeField]
        private string directoryPath;

        public string DataPath
        {
            get
            {
                return Path.Combine(Application.persistentDataPath, directoryPath);
            }
        }

        public string BuildPath(string filename)
        {
            return Path.Combine(DataPath, filename);
        }

        public IEnumerator GetAudioClip(string url, Action<AudioClip> callback, Action onError = null)
        {
            //Todo : support all types
            using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    onError.Invoke();
                }
                else
                {
                    //save to persistant path
                    DownloadHandlerAudioClip downloadHandler = (DownloadHandlerAudioClip)request.downloadHandler;
                    //   File.WriteAllBytes(BuildPath(url.GetHashCode().ToString()), request.downloadHandler.data);
                    callback.Invoke(downloadHandler.audioClip);
                }
            }
        }
    }
}