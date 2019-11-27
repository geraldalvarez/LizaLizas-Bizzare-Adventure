using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public float backgroundSpeed = 1.8f;
    public float midgroundSpeed = 2f;
    public Transform target;
    public Transform start;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public float GetIncrementalBackground()
    {
        return backgroundSpeed;
    }

    public float GetIncrementalMidground()
    {
        return midgroundSpeed;
    }

    public float GetTargetZ()
    {
        return target.position.z;
    }

    public float GetStartZ()
    {
        return start.position.z;
    }
}
