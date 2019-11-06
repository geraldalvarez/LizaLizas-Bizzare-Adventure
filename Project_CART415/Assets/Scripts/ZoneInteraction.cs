using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneInteraction : MonoBehaviour
{
    public Transform playerHead;
    public Transform npcHead;
    public float interactionDistance = 1;
    public bool enableLook = true;


    private Quaternion originalHeadRotation;
    private Quaternion currentHeadRotation;
    private bool look;

    // Start is called before the first frame update
    void Start()
    {
        if (npcHead != null)
        {
            originalHeadRotation = npcHead.transform.rotation;
            currentHeadRotation = npcHead.transform.rotation;
        }
        else
        {
            Debug.LogWarning(gameObject.name + "'s HeadTransform is missing!");
        }

        if (playerHead == null)
        {
            Debug.LogWarning(gameObject.name + "'s playerHead is missing!");
        }
    }

    //verify if the player is within the npc's interaction zone
    public bool InRange()
    {
        bool inrange = Vector3.Distance(npcHead.position, playerHead.position) <= interactionDistance;

        LookAt(inrange);

        //distance of the npc from the user
        return inrange;
    }

    public void LookAt(bool look)
    {
        if (enableLook)
        {
            if (look)
            {

                LookAt();

            }
            else
            {
                //reset
                transform.localRotation = originalHeadRotation;

            }
        }

    }

    private void LookAt()
    {
        Vector3 relativePos = playerHead.position - npcHead.position;
        npcHead.rotation = Quaternion.LookRotation(relativePos);
    }

    /*NOT USED
     public IEnumerator AnimateResetHead(float speed, float duration)
{

    float i = 0f;
    float rate = (1f / duration) * speed;

    while (i < 1f)
    {
        i += Time.deltaTime * rate;
        npcHead.localRotation = Quaternion.Lerp(currentHeadRotation, originalHeadRotation, i);


        yield return null;
    }
}

private IEnumerator AnimateLookAt(float speed, float duration)
{
    float i = 0f;
    float rate = (1f / duration) * speed;

    Vector3 relativePos = playerHead.position - npcHead.position;
    Quaternion targetEnd = Quaternion.LookRotation(relativePos);

    while (i < 1f)
    {
        i += Time.deltaTime * rate;
        npcHead.localRotation = Quaternion.Lerp(currentHeadRotation, targetEnd, i);

        if(i >= 1f)
        {
            currentHeadRotation = npcHead.rotation;
        }

        yield return null;
    }
}

*/
}
