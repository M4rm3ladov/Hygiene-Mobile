using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 5)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;
    public bool loop;
    public bool playOnAwake;
    [HideInInspector]
    public AudioSource source;
}
