using System;
using System.Collections;
using Patterns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField]
        private AudioSource _efxSource;
        [SerializeField]
        private AudioSource _musicSource;
        [SerializeField]
        private float _lowPitchRange = .95f;
        [SerializeField]
        private float _highPitchRange = 1.05f;

        public void PlayMusic(AudioClip clip)
        {
            _musicSource.clip = clip;
            _musicSource.Play();
        }

        private void Start()
        {
            _musicSource.Play();
        }

        public void StopMusic()
        {
            _musicSource.Stop();
        }

        public void PlaySingle(AudioClip clip, float delay = 0)
        {

            StartCoroutine(PlaySingleCoroutine(clip, delay));
        }

        private IEnumerator PlaySingleCoroutine(AudioClip clip,float delay)
        {
            yield return new WaitForSeconds(delay);
            _efxSource.pitch = 1;
            _efxSource.PlayOneShot(clip);
        }

        public void RandomizeSfx (params AudioClip[] clips)
        {
            int randomIndex = Random.Range(0, clips.Length);
            float randomPitch = Random.Range(_lowPitchRange, _highPitchRange);
            _efxSource.pitch = randomPitch;
            _efxSource.clip = clips[randomIndex];
            _efxSource.Play();
        }

    }
}
