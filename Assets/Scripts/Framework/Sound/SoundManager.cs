using Framework.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Sound
{
    public class SoundManager : SceneSingleton<SoundManager>
    {
        private Dictionary<string, AudioClip> audioDictionary = new Dictionary<string, AudioClip>();

        private AudioSource bgmSource;
        private List<AudioSource> seSourceList = new List<AudioSource>();

        public float BGMVolume
        {
            get { return bgmSource.volume; }

            set { bgmSource.volume = value; }
        }

        public float SEVolume
        {
            get { return seSourceList[0].volume; }

            set
            {
                foreach (AudioSource source in seSourceList)
                {
                    source.volume = value;
                }
            }
        }

        public void Awake()
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlayBGM(string path, bool loop = true)
        {
            if (!audioDictionary.ContainsKey(path))
                audioDictionary.Add(path, Resources.Load<AudioClip>(path));

            if (bgmSource.isPlaying)
                bgmSource.Stop();

            PlaySound(bgmSource, path, loop);
        }

        public void PlaySE(string path, bool loop = false)
        {
            if (!audioDictionary.ContainsKey(path))
                audioDictionary.Add(path, Resources.Load<AudioClip>(path));

            foreach(AudioSource source in seSourceList)
            {
                if(!source.isPlaying)
                {
                    PlaySound(source, path, loop);
                }
            }

            seSourceList.Add(gameObject.AddComponent<AudioSource>());
            PlaySound(seSourceList[seSourceList.Count - 1], path, loop);
        }

        private void PlaySound(AudioSource source, string path, bool loop)
        {
            source.clip = audioDictionary[path];
            source.loop = loop;
            source.Play();
        }
    }
}
