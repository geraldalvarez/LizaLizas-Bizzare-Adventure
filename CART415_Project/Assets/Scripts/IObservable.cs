using UnityEngine;

internal interface IObservable 
{
    void Add(IObserver observer);
    void Remove(IObserver observer);
    void Notify();
    Transform GetSelection();
    bool GetOnSelect();
}
