using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EventController))]
public class EventManager : Singleton<EventManager>
{
    [SerializeField]private EventController _eventController;
    public EventController EventController => _eventController;

    private void Awake()
    {
        _eventController = GetComponent<EventController>();
    }
}
