using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound Database")]
public class SoundsDatabase : ScriptableObject
{
    [SerializeField] public AudioClip[] _sounds;

    public AudioClip GetSound(int id) 
    {
        return _sounds[id];
    }
}
