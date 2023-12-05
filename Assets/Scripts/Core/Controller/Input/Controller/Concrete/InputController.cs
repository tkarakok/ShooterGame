using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class InputController : MonoBehaviour, IInputController
{
    public InputType InputType;
    public JoystickType JoystickType;
    public static Joystick Joystick { get; private set; }
    /// <summary>
    /// Current Vector2 of finger/mouse movement 
    /// </summary>
    public static Vector2 DeltaInputVector { get; private set; } = Vector2.zero;

    public bool PreventInput { get; private set; }

    private void Awake()
    {
        Joystick = FindObjectOfType<FixedJoystick>(true);
        
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        if (InputType == InputType.Touch)
        {
            LeanTouch.OnFingerDown += OnFingerDown;
            LeanTouch.OnFingerUpdate += OnFingerUpdate;
            LeanTouch.OnFingerUp += OnFingerUp;
        }
    }

    protected void OnDisable()
    {
        if (InputType == InputType.Touch)
        {
            LeanTouch.OnFingerDown -= OnFingerDown;
            LeanTouch.OnFingerUpdate -= OnFingerUpdate;
            LeanTouch.OnFingerUp -= OnFingerUp;
        }
    }

    #region Touch_Input

    private void OnFingerDown(LeanFinger finger)
    {
        if (PreventInput)
        {
            SetDeltaInputVector(Vector2.zero);
        }
        else
        {
            SetDeltaInputVector(finger.ScaledDelta);
        }
    }

    private void OnFingerUpdate(LeanFinger finger)
    {
        if (PreventInput)
        {
            SetDeltaInputVector(Vector2.zero);
        }
        else
        {
            SetDeltaInputVector(finger.ScaledDelta);
        }
    }

    private void OnFingerUp(LeanFinger finger)
    {
        SetDeltaInputVector(Vector2.zero);
    }

    #endregion

    public void SetDeltaInputVector(Vector2 targetVector)
    {
        DeltaInputVector = targetVector;
    }

    public void SetPreventInput(bool value)
    {
        PreventInput = value;
    }

    public static bool IsInputExist()
    {
        return Input.GetMouseButton(0) || Input.touchCount > 0;
    }
}