using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidgroundMover : MonoBehaviour
{
    public bool isRotation = false;
    public float speedStep = 0.2f;
    public Transform startPosition;
    public  Transform endPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float inc = speedStep * Time.deltaTime;

        //check the mode
        if(isRotation == true){
       
            //rotate
            transform.Rotate(0, inc, 0, Space.Self);
        }
        else
        {
            //translate
            transform.Translate(Vector3.forward * inc);


            //check if the object is at the endposition
            if (transform.position.z >= endPosition.position.z)
            {
                //reset the obejct at the starting position
                transform.position = new Vector3(transform.position.x, transform.position.y, startPosition.position.z);
            }

        }
    }
}
