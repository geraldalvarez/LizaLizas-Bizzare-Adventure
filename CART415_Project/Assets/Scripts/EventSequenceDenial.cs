using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EventSequenceDenial : MonoBehaviour
{
    //array of selective conversationSequences that dictates 
    //the sequential event for the story to progress.
    public ConversationSequence[] conversations;

    private void Awake()
    {     
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    bool IsConversationsCompleted()
    {
        bool complete = true;

        //loop and check if all is completed
        foreach (ConversationSequence cs in conversations)
        {
            if (cs.GetConversationComplete() == false)
            {
                complete = false;
                break;
            }
        }

        return complete;
    }

    //sudo code
    /*
     * 
     * -check if the starting-monologues is done
     * -check if the npc-door is done.
     * -check if the npc-alter is done.
     * 
     */
}
