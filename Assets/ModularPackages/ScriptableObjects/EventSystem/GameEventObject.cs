using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "ScriptableObjects/GameEvent")]
public class GameEventObject : ScriptableObject
{
    private List<GameEventListener> eventListeners = new List<GameEventListener>();

    public void Raise()
    {
        for(int i = eventListeners.Count - 1; i >= 0; i-- )
            eventListeners[i].OnEventRaised();
    }
    public void RegisterListener(GameEventListener _listener)
    {
        if(!eventListeners.Contains(_listener))
            eventListeners.Add(_listener);
        
    }
    public void UnregisterListener(GameEventListener _listener)
    {
        if(eventListeners.Contains(_listener))
            eventListeners.Remove(_listener);        
    }
}
