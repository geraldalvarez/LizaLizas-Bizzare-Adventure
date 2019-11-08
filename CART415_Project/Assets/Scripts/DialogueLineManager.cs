using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLineManager : MonoBehaviour
{
    public AudioSelector audioSelector;
    public ZoneInteraction zoneInteraction;

    //dialogue lines sequence
    public DialogueSectionSequence dialogueSectionsSequence;


    private void Start()
    {
        audioSelector = GetComponent<AudioSelector>();
        if (audioSelector == null)
        {
            Debug.LogWarning("Audio selector for " + gameObject.name + " is not define.");
        }

        zoneInteraction = GetComponent<ZoneInteraction>();
        if (zoneInteraction == null)
        {
            Debug.LogWarning("Zone Interaction for " + gameObject.name + " is not define.");
        }

        if (dialogueSectionsSequence == null)
        {
            Debug.LogWarning("Dialogue List for " + gameObject.name + " is empty.");
        }
    }

    private void Update()
    {

    }

    public void OnDeselect(Transform selectedTransform) {
        dialogueSectionsSequence.OnDeselect(zoneInteraction, audioSelector);
    }

    public void OnSelect(Transform selectedTransform) {
        dialogueSectionsSequence.OnSelect(zoneInteraction, audioSelector);
    }

    /*
  public AudioSelector audioSelector;
  public ZoneInteraction zoneInteraction;

  //Narrative number order
  public string eventTag = "EnterTag";

  //bool variable determines interactable state.
  public bool interactable = true;

  //list of the chronological dialogue for the NPC
  public string[] dialogueLinesSequence;

  //index of the current dialogue
  private int dialogueLineIndex = 0;

  //flag when the npc is talking
  private bool isTalking = false;


  private void Start()
  {
      audioSelector = GetComponent<AudioSelector>();
      if(audioSelector == null)
      {
          Debug.LogWarning("Audio selector for " + gameObject.name + " is not define.");
      }

      zoneInteraction = GetComponent<ZoneInteraction>();
      if(zoneInteraction == null)
      {
          Debug.LogWarning("Zone Interaction for " + gameObject.name + " is not define.");
      }

      if(dialogueLinesSequence == null)
      {
          Debug.LogWarning("Dialogue List for " + gameObject.name + " is empty.");
      }
  }

  private void Update()
  {

  }


    public void playDialogue()
   {
       if (zoneInteraction.InRange())
       {

           //check if the player is talking
           if (isTalking == false)
           {
               //set isTalking to true
               isTalking = true;

               //check if the npc is interactable
               if (interactable)
               {
                   //check if the dialoguelines is not out of bound
                   //playing the sound from THE NPC'S OWN AUDIOMANAGER
                   audioSelector.PlayAudioClip(dialogueLinesSequence[dialogueLineIndex]);
               }
               else
               {
                   //play the generic response

               }


           }
           else
           {
               //check if the audio is done (done talking)
               if(audioSelector.IsAudioClipPlaying(dialogueLinesSequence[dialogueLineIndex]) == false)
               {
                   //set isTalking to false
                   isTalking = false;


                   //
                   if(dialogueLineIndex < dialogueLinesSequence.Length)
                   {
                       //increment the index
                       dialogueLineIndex++;
                   }
                   else
                   {
                       //check if it reaches the end of the conversation
                       if (dialogueLineIndex >= dialogueLinesSequence.Length)
                       {
                           //loop 
                           dialogueLineIndex = 0;
                       }
                   }
               }
           }


       }
       else
       {
           //
           audioSelector.StopAudioClip(dialogueLinesSequence[dialogueLineIndex]);
       }
   }
   */


}
