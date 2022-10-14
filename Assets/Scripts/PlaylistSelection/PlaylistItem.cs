using Music.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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