using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelectionResponse : MonoBehaviour, ISelectionResponse, IObservable
{
    //-------------------IObservable

    private bool onSelect = false;
    private Transform selection;

    private List<IObserver> observers;

    private IObservable _observable;


    void Awake()
    {
        observers = new List<IObserver>();
        //GameObject[] objObserver = GameObject.FindGameObjectsWithTag("Selectable");
        _observable = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //---------------------ISelectionResponse

    void ISelectionResponse.OnDeselect(Transform selection)
    {

        onSelect = false;
    }

    void ISelectionResponse.OnSelect(Transform selection)
    {
        onSelect = true;
        this.selection = selection;
        _observable.Notify();
    }

    //-----------------------

    void IObservable.Add(IObserver observer)
    {
        observers.Add(observer);
    }

    void IObservable.Remove(IObserver observer)
    {
        observers.Remove(observer);
    }

    void IObservable.Notify()
    {
        foreach (IObserver observerList in observers)
        {
            observerList.update();
        }
    }

    bool IObservable.GetOnSelect()
    {
        return onSelect;
    }

    Transform IObservable.GetSelection()
    {
        return selection;
    }
}
