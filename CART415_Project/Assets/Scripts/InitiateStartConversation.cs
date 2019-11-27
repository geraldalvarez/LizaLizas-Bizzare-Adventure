using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateStartConversation : MonoBehaviour
{
    public bool initiateConversation = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ConversationSequence>().SetStartConversation(initiateConversation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
