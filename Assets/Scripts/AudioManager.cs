using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager Instance;
        
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private Sound[] musics;
    [SerializeField] private Sound[] soundEffects;
    private void Start()
    {
        
    }

    private void PlayMusic(string musicName)
    {
        var music = Array.Find(musics, sound => sound.name == musicName);

        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    private void PlayMusicOnPoint(string musicName, Transform objectTransform)
    {
        var music = Array.Find(musics, sound => sound.name == musicName);
        
        
    }
}
