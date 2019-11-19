using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound 
{
    [Header("Dialogue Name")]
    public string name;

    [Header("Input The AudioClip")]
    public AudioClip clip;

    [Header("Volume of Audio")]
    [Range(0f, 1f)]
    public float volume = 1;

    [Header("Pitch of Audio")]
    [Range(0.1f, 3f)]
    public float pitch = 1;

    [Header("Loop the Audio")]
    public bool loop = false;

    [Header("Play Audio On Awake")]
    public bool playOnAwake = false;

    [Header("2D or 3D")]
    [Range(0f, 1f)]
    public float spatialBlend;

    [Header("Min Distance of 3D Audio")]
    public float minDistance = 0;

    [Header("Max Distance of 3D Audio")]
    public float maxDistance = 2;

    [Header("Type of Rolloff Mode")]
    public int rolloffMode = 1;

    //[HideInInspector]
    public AudioSource source;
}
