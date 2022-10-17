using Music.Entities;
using System;
using TMPro;
using UnityEngine;

namespace Music
{
    public class PlaylistItem : MonoBehaviour
    {
        public Playlist playlist;

        [SerializeField]
        private TextMeshProUGUI titleText;

        private Action<Playlist> callback;

        public void Init(Playlist playlist, Action<Playlist> onClick)
        {
            this.playlist = playlist;
            titleText.text = playlist.Name;
            this.callback = onClick;
        }

        public void OnClick()
        {
            callback.Invoke(playlist);
        }
    }
}