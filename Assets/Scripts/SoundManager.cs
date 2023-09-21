using UnityEngine;

namespace Scripts
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField]
        private AudioSource sfxAudioSource;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
            else
                Destroy(Instance);
        }

        public void PlaySFX(AudioClip audioClip, float volume = 1)
        {
            sfxAudioSource.PlayOneShot(audioClip, volume);
        }
    }
}
