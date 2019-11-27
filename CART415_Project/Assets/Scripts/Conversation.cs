using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    private bool onConversation;

    public void SetOnConversation(bool converse)
    {
        onConversation = converse;
    }

    public bool GetOnConversation()
    {
        return onConversation;
    }
}
