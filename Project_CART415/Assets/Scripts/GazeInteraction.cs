using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteraction : MonoBehaviour, ISelectionResponse
{
 
    [SerializeField] public float gazeDuration = 5f;


    public void OnDeselect(Transform selection)
    {
        print("On-Deselect");
    }

    public void OnSelect(Transform selection)
    {

        bool inRange ;
        if (selection.GetComponent<ZoneInteraction>() == null)
        {
            inRange = selection.parent.GetComponent<ZoneInteraction>().InRange();
        }
        else
        {
            //get the npc's component directly
            inRange = selection.GetComponent<ZoneInteraction>().InRange();
        }

        bool interactable;
        string soundName;

        if(selection.GetComponent<Dialogue>() == null)
        {
            interactable = selection.parent.GetComponent<Dialogue>().interactable;
            soundName = selection.parent.GetComponent<Dialogue>().dialogueNameTag;
        }
        else
        {
            interactable = selection.GetComponent<Dialogue>().interactable;
            soundName = selection.GetComponent<Dialogue>().dialogueNameTag;
        }

        //check if in the zone of interaction
        if (inRange) { 
        
            //prevent duplicate or lock the interact
            if (interactable)
            {
                //FindObjectOfType<AudioManager>().Play(soundName);
                selection.parent.GetComponent<Dialogue>().playDialogue();

                //set the interactable to false
                if (selection.GetComponent<Dialogue>() == null)
                {
                   selection.parent.GetComponent<Dialogue>().interactable = false;
                  
                }
                else
                {
                  selection.GetComponent<Dialogue>().interactable = false;

                }
            }

        }

        print("On-Select");
    }


}
