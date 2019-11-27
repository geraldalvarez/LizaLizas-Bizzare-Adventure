using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public bool backgroundLayer = true;
    public float speedStepBack =1.6f;
    public float speedStepMid = 2f;
    private ParallaxController parallaxController;

    // Start is called before the first frame update
    void Start()
    {
        parallaxController = GameObject.Find("ParallaxController").GetComponent<ParallaxController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        float xpos = transform.position.x;
        float ypos = transform.position.y;
        float zpos;
        if (backgroundLayer)
        {
            zpos = transform.position.z + parallaxController.GetIncrementalBackground();
        }
        else
        {
            zpos = transform.position.z + parallaxController.GetIncrementalMidground();
        }

        
        if(transform.position.z < parallaxController.GetTargetZ())
        {
            transform.position = new Vector3(xpos, ypos, zpos);
        }
        else
        {
            transform.position = new Vector3(xpos,ypos, parallaxController.GetStartZ());
        }
    }
}
