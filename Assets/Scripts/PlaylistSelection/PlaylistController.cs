using Music.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Music
{
    public class PlaylistController : MonoBehaviour
    {
        [SerializeField]
        private PlaylistRepository playlistRepository;

        [SerializeField]
        private PlaylistItem playlistItemPrefab;

        [SerializeField]
        private Transform container;

        public void OnEnable()
        {
            playlistRepository.Load();
            foreach (Playlist playlist in playlistRepository.playlists)
            {
                PlaylistItem item = Instantiate<PlaylistItem>(playlistItemPrefab, container);
                item.Init(playlist);
            }
        }
    }
}