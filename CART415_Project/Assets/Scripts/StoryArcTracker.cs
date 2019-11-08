using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryArcTracker : MonoBehaviour
{
    //list of all the sequence
    public DialogueSectionSequence[] sequences;
    public GameObject key;

    public void FirstStorySequence()
    {
        if (NumSequenceCompleted("npc") >= 4)
        {
            sequences[10].interactable = true;
            print("Talked to all NPC");
        }

        if (sequences[10].SequenceComplete())
        {
            key.SetActive(true);
        }
    }


   public int NumSequenceCompleted(string type)
    {
        bool f = false;
        int g = 0;

        for (int i = 0; i < sequences.Length; i++)
        {
            if(sequences[i].ObjectType == type)
            {
                f = sequences[i].SequenceComplete();
                if (sequences[i].SequenceComplete())
                {
                    g++;
                }
                
            }
        }

        print("Completed comversation " + g);

        return g;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        FirstStorySequence();
    }
}