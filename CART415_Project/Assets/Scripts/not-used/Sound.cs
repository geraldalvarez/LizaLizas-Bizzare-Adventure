using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;

    [Range(0.1f, 3f)]
    public float pitch = 1;

    public bool loop = false;

    public bool playOnAwake = false;

    [Range(0f, 1f)]
    public float spatialBlend;

    public int minDistance = 0;

    public int maxDistance = 2;

    public int rolloffMode = 0;

    //[HideInInspector]
    public AudioSource source;
}
