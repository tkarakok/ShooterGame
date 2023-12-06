using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public interface ICameraController : IControllerBase
{
    public Result SetActiveCamera(string cameraParam);
    public Result RotateCameraWithAim(Vector3 rotAngle);
}
