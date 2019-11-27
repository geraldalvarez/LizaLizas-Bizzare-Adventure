using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScene : MonoBehaviour
{
    Transform playerHead;
    LevelChanger LevelChanger;

    private void Awake()
    {
        playerHead = GameObject.Find("HeadCollider").transform;
        LevelChanger = GameObject.FindObjectOfType<LevelChanger>();
    }

    // Start is called before the first frame update
    void Start()
    {
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
            LevelChanger.FadeToNextLevel();
        }

    }

}
