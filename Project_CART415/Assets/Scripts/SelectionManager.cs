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
            _selectionResponse.OnDeselect(_selection);
        }

        //ray cast
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        _selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        if (_selection != null)
        {
            _selectionResponse.OnSelect(_selection);
        }
    }
}
