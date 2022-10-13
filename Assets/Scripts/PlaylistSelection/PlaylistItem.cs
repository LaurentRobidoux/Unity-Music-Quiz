using Music.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Music
{
    public class PlaylistItem : MonoBehaviour
    {
        public Playlist playlist;

        [SerializeField]
        private TextMeshProUGUI titleText;

        public void Init(Playlist playlist)
        {
            this.playlist = playlist;
            titleText.text = playlist.Name;
        }
    }
}