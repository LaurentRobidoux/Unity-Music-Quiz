using Music.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Loaders
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioLoader : MonoBehaviour
    {
        [SerializeField]
        private AudioRepository audioRepository;

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

        public void Load(string url)
        {
            StartCoroutine(audioRepository.GetAudioClip(url, AudioLoaded));
        }

        private void AudioLoaded(AudioClip clip)
        {
            AudioSource.clip = clip;
            AudioSource.Play();
        }
    }
}