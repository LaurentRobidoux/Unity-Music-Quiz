using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Music.Entities;
using Music.Repositories.Strategies;
using System;

namespace Music.Repositories
{
    [CreateAssetMenu]
    public class PlaylistRepository : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        internal string filename;

        [SerializeField]
        internal string url;

        private List<Playlist> playlists = null;

        [SerializeField]
        private BaseStrategy strategy;

        public IEnumerator Init(Action callback, Action onError = null)
        {
            yield return strategy.GetFile(this, (text) =>
            {
                Debug.Log("Serialize");
                playlists = JsonConvert.DeserializeObject<List<Playlist>>(text);
                callback.Invoke();
            }, onError);
        }

        public List<Playlist> GetAll()
        {
            return playlists;
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            playlists = null;
        }
    }
}