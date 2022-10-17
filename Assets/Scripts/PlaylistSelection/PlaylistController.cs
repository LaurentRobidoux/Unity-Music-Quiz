using Music.Entities;
using Music.Repositories;
using Music.Variable;
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

        [SerializeField]
        private PlaylistVariable playlistVariable;

        public void OnEnable()
        {
            foreach (Playlist playlist in playlistRepository.GetAll())
            {
                PlaylistItem item = Instantiate<PlaylistItem>(playlistItemPrefab, container);
                item.Init(playlist, PlaylistSelected);
            }
        }

        private void PlaylistSelected(Playlist playlist)
        {
            playlistVariable.Value = playlist;
            SceneController.OpenQuiz();
        }
    }
}