using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(3, 10)]
    [SerializeField] private int audioSourceCount;
    
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private Sound[] musics;
    [SerializeField] private Sound[] soundEffects;

    [SerializeField] private GameObject tempAudioObject;

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
        
        CreateAndAssignAudioSources(audioSourceCount);
        DontDestroyOnLoad(gameObject);
    }

    private void CreateAndAssignAudioSources(int number)
    {
        for (var i = 0; i < number; i++)
        {
            gameObject.AddComponent<AudioSource>();
        }

        audioSources = GetComponents<AudioSource>();
    }
    public void PlayMusic(string musicName, int audioSourceIndex)
    {
        var music = Array.Find(musics, sound => sound.name == musicName);

        audioSources[audioSourceIndex].clip = music.audioClip;
        audioSources[audioSourceIndex].Play();
    }
    public void PlaySoundFX(string soundEffectName, int audioSourceIndex)
    {
        var sound = Array.Find(musics, sound => sound.name == soundEffectName);

        audioSources[audioSourceIndex].clip = sound.audioClip;
        audioSources[audioSourceIndex].Play();
    }

    // This method creates temp gameObject then destroys it.
    public void PlaySoundEffectOnPoint(string soundEffectName, Transform objectTransform)
    {
        var sound = Array.Find(musics, sound => sound.name == soundEffectName);

        var tempGameObject = Instantiate(tempAudioObject);
        tempGameObject.transform.position = objectTransform.position;
        
        var tempAudioSource = tempGameObject.GetComponent<AudioSource>();
        tempAudioSource.clip = sound.audioClip;
        // I can set other AudioSource properties from here
        
        tempAudioSource.Play();
        Destroy(tempGameObject, sound.audioClip.length);
    }
}
