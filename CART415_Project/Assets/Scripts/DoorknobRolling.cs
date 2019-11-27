using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorknobRolling : MonoBehaviour
{
    //next event
    public GameObject transitionScene;
    public ConversationSequence alterConversation;
    public Transform startPoint;
    public Transform targetPoint;

    private bool animatingDrop = false;
    private bool animatingRoll = false;
    private bool animationFinish = false;
    private float dropTime = .5f;
    private float rollTime = 8f;


    void Awake()
    {
        //disable
        transitionScene.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //animate the doorknob when alter is done talking
        DoorknobAnimation();

    }

    void DoorknobAnimation()
    {
       
        if (alterConversation.GetConversationComplete())
        {
            animatingDrop = true;
            if (animatingDrop == true)
            {
                Vector3 start = transform.position;
                //drop the doorknob
                StartCoroutine(GoDoorknobDrop(dropTime, 1, start, startPoint.position));
            }

            if(animatingRoll == true)
            {
                Vector3 start = transform.position;
                StartCoroutine(GoDoorknobRoll(rollTime, 1, start, targetPoint.position));
            }

            if (animationFinish)
            {
                transitionScene.SetActive(true);
            }
        }
    }

    private IEnumerator GoDoorknobDrop(float time, float speed, Vector3 startPos, Vector3 targetPos)
    {
        float i = 0f;
        float rate = (1f / time) * speed;

        while (i < 1f)
        {

            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, targetPos, i);

            if (i >= 1f)
            {
                animatingRoll = true;
                animatingDrop = false;
            }

            yield return null;
        }
    }

    private IEnumerator GoDoorknobRoll(float time, float speed, Vector3 startPos, Vector3 targetPos)
    {
        float i = 0f;
        float rate = (1f / time) * speed;

        while (i < 1f)
        {

            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, targetPos, i);

            if (i >= 1f)
            {
                animatingRoll = false;
                animationFinish = true;
            }

            yield return null;
        }
    }
}
