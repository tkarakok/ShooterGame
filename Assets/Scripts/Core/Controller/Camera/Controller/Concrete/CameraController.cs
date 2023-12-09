using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Core.Utilities.Results;
using UnityEngine;

public class CameraController : MonoBehaviour, ICameraController
{
    #region References
    private Animator _cameraAnimator;
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    #endregion

    private void Awake()
    {
        _cameraAnimator = GetComponentInChildren<Animator>();
    }

    public Result SetActiveCamera(string cameraParam)
    {
        _cameraAnimator.SetTrigger(cameraParam);
        return new SuccessResult();
    }

    public Result RotateCameraWithAim(float value)
    {
        var result = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineComposer>();
        result.m_TrackedObjectOffset.y -= value;
       // result.ShoulderOffset.y = Mathf.Clamp(result.ShoulderOffset.y, .4f, 1.75f);
        return new SuccessResult();
    }
}
