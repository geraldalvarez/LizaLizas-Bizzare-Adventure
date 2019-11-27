using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGlare : MonoBehaviour
{
    public TurnHead[] heads;
    private Conversation conversation;

    // Start is called before the first frame update
    void Start()
    {
        conversation = GameObject.Find("ConversationStates").GetComponent<Conversation>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AllHeadTurn(bool f)
    {
        if (f)
        {
            conversation.SetOnConversation(true);

            for (int i = 0; i < heads.Length; i++)
            {
                heads[i].LookAt();
            }
        }
        else
        {
            conversation.SetOnConversation(false);
            for (int i = 0; i < heads.Length; i++)
            {
                heads[i].ResetHead();
            }
        }

    }
}
