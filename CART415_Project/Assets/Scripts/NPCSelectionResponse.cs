using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSelectionResponse : MonoBehaviour, ISelectionResponse
{
    ConversationStates conversationStates;

    void ISelectionResponse.OnDeselect(Transform selection)
    {
        
    }

    void ISelectionResponse.OnSelect(Transform selection)
    {
        //if (conversationStates.IsOnConversation() == false)
        //{
            //selection.GetComponent<ConversationSequence>().InitiateConversation();
        //}

        selection.GetComponent<ConversationSequence>().InitiateConversation();        
    }

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        conversationStates = GameObject.Find("ConversationStates").GetComponent<ConversationStates>();
    }
}
