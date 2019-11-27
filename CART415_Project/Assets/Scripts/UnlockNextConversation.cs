using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextConversation : MonoBehaviour
{
    ConversationSequence thisConversation;
    public ConversationSequence nextConversation;

    private bool unlock = false;

    // Start is called before the first frame update
    void Start()
    {
        thisConversation = GetComponent<ConversationSequence>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisConversation.GetConversationComplete() && unlock == false)
        {
            nextConversation.isInteractable = true;
            //stoop looping mechanic
            unlock = false;
        }
    }
}
