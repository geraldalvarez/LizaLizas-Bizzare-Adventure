using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTransitionScene : MonoBehaviour
{
    Transform playerHead;

    // Start is called before the first frame update
    void Start()
    {
        playerHead = GameObject.Find("HeadCollider").transform;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform == playerHead)
        {
            //load next scene
            print("Next scene");
        }

    }

}
