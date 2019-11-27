using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationStates : MonoBehaviour
{

    ConversationSequence[] conversations;

    // Start is called before the first frame update
    void Start()
    {
        conversations = GameObject.FindObjectsOfType<ConversationSequence>();
    }

    public bool IsOnConversation()
    {
        bool onConversation = false;

        foreach (ConversationSequence cs in conversations)
        {
            if (cs.GetStartConversation())
            {
                onConversation = true;
            }
        }

        return onConversation;
    }
}
