using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEventObject eventObject;
    public UnityEvent response;

    private void OnEnable() => eventObject.RegisterListener(this);
    private void OnDisable() => eventObject.UnregisterListener(this);
    public void OnEventRaised() => response.Invoke();



}
