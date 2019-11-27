using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    public ConversationSequence npcConversation;

    private Transform playerHead;
    private Transform npcHead;

    private Quaternion originalHeadRotation;
    private Quaternion currentHeadRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerHead = GameObject.Find("FollowHead").GetComponent<Transform>();
        npcHead = gameObject.transform;
        originalHeadRotation = npcHead.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (npcConversation.GetStartConversation())
        {
            LookAt();
        }
        else
        {
            //reset
            transform.localRotation = originalHeadRotation;
        }
    }

    private void LookAt()
    {
        Vector3 relativePos = playerHead.position - npcHead.position;
        npcHead.rotation = Quaternion.LookRotation(relativePos);
    }
}
