using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSelection : MonoBehaviour, ISelectionResponse
{
 
    //[SerializeField] public float gazeDuration = 5f;


    public void OnDeselect(Transform selection)
    {
        selection.parent.GetComponent<DialogueLineManager>().OnDeselect(selection);//script is attached to parent
    }

    public void OnSelect(Transform selection)
    {
        selection.parent.GetComponent<DialogueLineManager>().OnSelect(selection);//script is attached to parent
    }


}
