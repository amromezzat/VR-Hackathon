using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    private List<System.Action> listenerFunctions = new List<System.Action>();

    public void Raise()
    {
        for(int i=listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
        for(int i=listenerFunctions.Count - 1; i >= 0; i--)
        {
            listenerFunctions[i]();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RegisterListener(System.Action listenerFunction)
    {
        listenerFunctions.Add(listenerFunction);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void UnregisterListener(System.Action listenerFunction)
    {
        listenerFunctions.Remove(listenerFunction);
    }
}
