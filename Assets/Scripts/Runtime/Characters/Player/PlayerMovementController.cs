using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerMovementController : MonoBehaviour
{
    #region References

    public Rigidbody Rigidbody { get; protected set; }

    #endregion

    private PlayerAnimationController _playerAnimationController;

    public float MovementMultiplier;
    public float RotationMultiplier;

    public bool PreventMovement;

    #region Init Variables Rotation

    private Quaternion _currentRot;
    private Vector3 _targetRotAngle;

    #endregion

    protected virtual void Awake()
    {
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _playerAnimationController.SeBuffAnim();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            PreventMovement = true;
            _playerAnimationController.SeLootAnim();
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            _playerAnimationController.SeHitAnim();
        }

        if (InputController.IsInputExist() && !PreventMovement)
        {
            _playerAnimationController.SetMovementAnim(InputController.Joystick.Direction.magnitude);
            ControllerLogic();
        }
    }

    protected void ControllerLogic()
    {
        CharacterMovement();
        CharacterRotation();
    }

    private void CharacterMovement()
    {
        Rigidbody.velocity = new Vector3(InputController.Joystick.Direction.x * MovementMultiplier,
            0,
            InputController.Joystick.Direction.y * MovementMultiplier);
    }


    private void CharacterRotation()
    {
        _currentRot = transform.rotation;
        _targetRotAngle = new Vector3(InputController.Joystick.Direction.x, Rigidbody.velocity.y,
                InputController.Joystick.Direction.y)
            .normalized;
        if (_targetRotAngle == Vector3.zero) _targetRotAngle = new Vector3(0, 0.001f, 0);
        Quaternion lookRotation = Quaternion.LookRotation(_targetRotAngle, Vector3.up);
        lookRotation.x = 0f;
        lookRotation.z = 0f;
        transform.rotation = Quaternion.Lerp(_currentRot, lookRotation,
            Time.fixedDeltaTime * RotationMultiplier);
    }


    public void ResetRigidbody()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
    }
}