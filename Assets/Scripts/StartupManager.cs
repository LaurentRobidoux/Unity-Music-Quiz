using Music.Repositories;
using UnityEngine;
using UnityEngine.Events;

namespace Music
{
    public class StartupManager : MonoBehaviour
    {
        [SerializeField]
        private PlaylistRepository playlistRepository;

        [SerializeField]
        private UnityEvent onError;

        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            StartCoroutine(playlistRepository.Init(() => { SceneController.OpenMainMenu(); }, onError.Invoke));
        }
    }
}