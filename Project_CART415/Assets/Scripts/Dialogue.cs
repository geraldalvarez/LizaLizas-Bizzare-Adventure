using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string npcName;
    public bool interactable = true;
    public string dialogueNameTag;
    //public int currentIndexDialogue = 0;
    //public string[] dialogueSequence;


    public void playDialogue()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
