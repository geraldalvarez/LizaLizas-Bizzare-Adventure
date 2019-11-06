using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    //interface
    private ISelectionResponse _selectionResponse;

    //target selection of the glaze mechanic
    private Transform _selection;

    private void Awake()
    {
        //get the component of the Interface //the component is manually added
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        //check if not null
        if(_selection != null)
        {
            //set OnDeselect
            _selectionResponse.OnDeselect(_selection);
        }

        //ray cast
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        //clear the selection
        _selection = null;


        //check the raycast hit
        if (Physics.Raycast(ray, out var hit))
        {
            //set the raycast hit's transform
            var selection = hit.transform;

            //check if the 
            if (selection.CompareTag(selectableTag))
            {
                //set the selection
                _selection = selection;
            }
        }

        //if not null
        if (_selection != null)
        {
            //set OnSelect
            _selectionResponse.OnSelect(_selection);
        }
    }
}
