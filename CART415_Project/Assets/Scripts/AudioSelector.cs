using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelector : MonoBehaviour
{

    public AudioSource[] audioList;

    // Start is called before the first frame update
    void Start()
    {
        if(audioList == null)
        {
            Debug.LogWarning("AudioList must be creater than 1.");
        }

        foreach (AudioSource audio in audioList)
        {
           // print("name is " + audio.clip.name);
        }
       
    }

    public void PlayAudioClip(string name)
    {

        int indexClip = GetAudioClipIndex(name);

        if (indexClip != -1)
        {
            audioList[indexClip].Play();
        }
        else
        {
            Debug.LogWarning("Audioclip name :" + name + " does not exit!");
        }

    }

    public void StopAudioClip(string name)
    {
        int indexClip = GetAudioClipIndex(name);

        if(indexClip != -1)
        {
            audioList[indexClip].Stop();
        }
        else
        {
            Debug.LogWarning("Audioclip name :" + name + " does not exit!");
        }
    }

    public bool IsAudioClipPlaying(string name)
    {
        int indexClip = GetAudioClipIndex(name);
        bool playing = false;

        if (indexClip != -1)
        {
            playing  = audioList[indexClip].isPlaying;
        }
        else
        {
            Debug.LogWarning("Audioclip name :" + name + " does not exit!");
        }

        return playing;
    }

    private int GetAudioClipIndex(string name)
    {
        int index = -1;

        for (int i = 0; i < audioList.Length; i++)
        {
            if (audioList[i].clip.name == name)
            {
                index = i;
                break;
            }
        }

        return index;
    }
}
