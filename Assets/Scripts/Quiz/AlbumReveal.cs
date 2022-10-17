using Music.Entities;
using Music.Repositories;
using UnityEngine;
using UnityEngine.UI;

namespace Music.Quiz
{
    public class AlbumReveal : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        public Sprite defaultSprite;

        public Sprite errorSprite;

        [SerializeField]
        private ImageRepository imageRepository;

        private Image image;

        public Image Image
        {
            get
            {
                if (image == null)
                {
                    image = GetComponent<Image>();
                }
                return image;
            }
        }

        private Sprite loadedSprite;

        public void MidRotation()
        {
            if (loadedSprite == null)
            {
                Image.sprite = errorSprite;
            }
            else
            {
                Image.sprite = loadedSprite;
            }
        }

        public void RotationEnded()
        {
            animator.enabled = false;
        }

        public void Hide()
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = Vector3.one;
            Image.sprite = defaultSprite;
        }

        public void Show()
        {
            animator.enabled = true;
        }

        public void Preload(Song song)
        {
            Unload();

            StartCoroutine(imageRepository.GetSprite(song, LoadCallback));
        }

        public void Unload()
        {
            if (loadedSprite != null)
            {
                imageRepository.Unload(loadedSprite);
                loadedSprite = null;
            }
        }

        private void LoadCallback(Sprite sprite)
        {
            loadedSprite = sprite;
        }
    }
}