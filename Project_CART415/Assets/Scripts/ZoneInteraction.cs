using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneInteraction : MonoBehaviour
{
    //radius distance that the player can interact with the npc
    [SerializeField] public float distance = 1f;


    public bool InRange()
    {
        //position of the npc
        Vector3 npc = gameObject.transform.position;

        Vector3 player;
        if (GameObject.Find("VRCamera") == null)
        {
            //get the fallbackobject if not using the vr hardware
            player = GameObject.Find("FallbackObjects").GetComponent<Transform>().position;
        }
        else
        {
            player = GameObject.Find("VRCamera").GetComponent<Transform>().position;
        }

        //distance of the npc from the user
        float distNpcToPlayer = Vector3.Distance(npc, player);

        return distNpcToPlayer <= distance;
    }
}
