using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSectionSequence : MonoBehaviour
{
    //Name tag for this section sequence
    public string SectionNameTag = "EnterTag";

    //Type of object the script is attached
    public string ObjectType = "EnterType";

    //chronological by manual input via inspector
    public string[] linesSequence;

    //name of the generic line
    //public string genericLine;

    private int lineIndex = 0;

    //flag when the npc is talking
    private bool isTalking = false;

    //bool variable determines interactable state.
    public bool interactable = true;

    // Start is called before the first frame update
    void Start()
    {
        if (linesSequence == null)
        {
            Debug.LogWarning("Lines Sequence for " + gameObject.name + " is empty.");
        }

        /*
        if(genericLine == null)
        {
            Debug.LogWarning("Generic Line for " + gameObject.name + " is empty.");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //OnDeselect function
    public void OnDeselect(ZoneInteraction zoneInteraction, AudioSelector audioSelector)
    {

    }

    //OnSelect function plays audio and other mechanics of the game
    public void OnSelect(ZoneInteraction zoneInteraction, AudioSelector audioSelector)
    {
        if (interactable)
        {
            if (zoneInteraction.InRange())
            {

                //check if the player is talking
                if (isTalking == false)
                {
                    //set isTalking to true
                    isTalking = true;

                    //check array bound
                    if (lineIndex < linesSequence.Length)
                    {
                        //check if the dialoguelines is not out of bound
                        //playing the sound from THE NPC'S OWN AUDIOMANAGER
                        audioSelector.PlayAudioClip(linesSequence[lineIndex]);

              
                    }
                }
                else
                {
                    //check array bound
                    if (lineIndex < linesSequence.Length)
                    {
                        //check if the audio is done (done talking)
                        if (audioSelector.IsAudioClipPlaying(linesSequence[lineIndex]) == false)
                        {
                             //set isTalking to false
                           isTalking = false;

                            //increment the index
                            lineIndex++;
                            //print("Line Index is " + lineIndex);

                        }
                    }
                }


            }
            else
            {
                if (lineIndex < linesSequence.Length)
                {
                    audioSelector.StopAudioClip(linesSequence[lineIndex]);
                }

            }
        }
        else//interactable
        {
            //play the generic dialogue
        }
     
    }


    public bool SequenceComplete()
    {
        return lineIndex >= linesSequence.Length;
    }
}
