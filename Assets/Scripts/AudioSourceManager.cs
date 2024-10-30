using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] private int audioSourceCount;

    private AudioSource[] _audioSourceList;
    private Queue<AudioSource> _audioSourceQueue;

    private void Start()
    {
        CreateAndAssignAudioSources(audioSourceCount);
    }

    private void CreateAndAssignAudioSources(int number)
    {
        for (var i = 0; i < number; i++)
        {
            gameObject.AddComponent<AudioSource>();
        }
        _audioSourceList = GetComponents<AudioSource>();

        foreach (var audioSource in _audioSourceList)
        {
            _audioSourceQueue.Enqueue(audioSource);
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        return _audioSourceQueue?.Dequeue();
    }
}
