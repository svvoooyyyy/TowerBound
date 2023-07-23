using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSoundPlayer : MonoBehaviour
{
    [SerializeField] private SoundsDatabase _data;
    [SerializeField] private int[] ids;
    [SerializeField] private float _defaultVolume = 0.5f;
    [SerializeField] private float _offset = 0f;
    private AudioSource _currentAudioSource;

    public void PlayRandomFromIds() 
    {
        _currentAudioSource = gameObject.AddComponent<AudioSource>();
        _currentAudioSource.clip = _data._sounds[ids[Random.Range(0, ids.Length)]];
        _currentAudioSource.volume = _defaultVolume;
        _currentAudioSource.Play();
    }

    public void Play(int id)
    {
        _currentAudioSource = gameObject.AddComponent<AudioSource>();
        _currentAudioSource.clip = _data._sounds[id];
        _currentAudioSource.volume = _defaultVolume;
        _currentAudioSource.time = _offset;
        _currentAudioSource.Play();
    }
}
