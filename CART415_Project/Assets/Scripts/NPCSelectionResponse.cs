using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSelectionResponse : MonoBehaviour, ISelectionResponse
{

    //reference to all the selectable npc
    ConversationSequence[] conversationSequences;

    private bool onConversation = false;

    void ISelectionResponse.OnDeselect(Transform selection)
    {
        
    }

    void ISelectionResponse.OnSelect(Transform selection)
    {
        for (int i = 0; i < conversationSequences.Length; i++)
        {
            if (conversationSequences[i].transform == selection)
            {
                conversationSequences[i].InitiateConversation();
            }
        }
    }

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //get and set the conversation sequences into the conversationSequences array
        conversationSequences = GameObject.FindObjectsOfType<ConversationSequence>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
