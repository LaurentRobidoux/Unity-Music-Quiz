using Music.Entities;
using Music.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        [SerializeField]
        private PlaylistVariable playlistVariable;

        public void OnEnable()
        {
            playlistRepository.Load();
            foreach (Playlist playlist in playlistRepository.playlists)
            {
                PlaylistItem item = Instantiate<PlaylistItem>(playlistItemPrefab, container);
                item.Init(playlist, PlaylistSelected);
            }
        }

        private void PlaylistSelected(Playlist playlist)
        {
            playlistVariable.Value = playlist;
            SceneManager.LoadScene("Quiz");
        }
    }
}