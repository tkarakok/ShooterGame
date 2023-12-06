using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateController))]
public class GameManager : Singleton<GameManager>
{
    private IGameStateController _gameStateController;
    public Transform CrossHair { get; private set; }
    private void Awake()
    {
        _gameStateController = GetComponent<GameStateController>();
        CrossHair = FindObjectOfType<Crosshair>(true).transform;
    }

    private void OnEnable()
    {
        if (EventManager.Instance)
        {
            //EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.AddListener(ChangeGameState);
        }
    }

    private void OnDisable()
    {
        if (EventManager.Instance)
        {
            // EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.RemoveListener(ChangeGameState);
        }
    }

    public void ChangeGameState(GameStates state)
    {
        _gameStateController.SetNewGameState(state);
        EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.Execute(state);
    }
}
