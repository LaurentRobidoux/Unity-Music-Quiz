using Music.Entities;
using Music.Repositories;
using UnityEngine;
using UnityEngine.Events;

namespace Music.Loaders
{
    [RequireComponent(typeof(AudioSource))]
    public class SongLoader : MonoBehaviour
    {
        [SerializeField]
        private AudioRepository audioRepository;

        [SerializeField]
        private UnityEvent onError;

        private AudioSource audioSource;

        public AudioSource AudioSource
        {
            get
            {
                if (audioSource == null)
                {
                    audioSource = GetComponent<AudioSource>();
                }
                return audioSource;
            }
        }

        public void Load(Song song)
        {
            if (AudioSource.clip != null)
            {
                Unload();
            }
            StartCoroutine(audioRepository.GetAudioClip(song, AudioLoaded, OnError));
        }

        public void Unload()
        {
            audioRepository.Unload(audioSource.clip);
        }

        private void OnError()
        {
            onError.Invoke();
        }

        public void Stop()
        {
            audioSource.Stop();
        }

        private void AudioLoaded(AudioClip clip)
        {
            AudioSource.clip = clip;
            AudioSource.Play();
        }
    }
}