using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Touch;
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize();
        ControllerLogic(movement);
        _playerAnimationController.SetMovementAnim(movement.normalized.magnitude);
        
        #region Anims
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
        

        #endregion
    }

    protected void ControllerLogic(Vector3 movement)
    {
        CharacterMovement(movement);
        CharacterRotation();
    }

    private void CharacterMovement(Vector3 direction)
    {
        // Vector3 movement = transform.TransformDirection(new Vector3(
        //     InputController.Joystick.Direction.x * MovementMultiplier,
        //     0,
        //     InputController.Joystick.Direction.y * MovementMultiplier));
        Rigidbody.velocity =  transform.TransformDirection(
            new Vector3(
                direction.x * MovementMultiplier,
                Rigidbody.velocity.y,
                direction.z * MovementMultiplier
                ));
    }


    private void CharacterRotation()
    {
        // _currentRot = transform.rotation;
        // _targetRotAngle = new Vector3(InputController.DeltaInputVector.x, Rigidbody.velocity.y,
        //         InputController.DeltaInputVector.y)
        //     .normalized;
        // if (_targetRotAngle == Vector3.zero) _targetRotAngle = new Vector3(0, 0.001f, 0);
        // Quaternion lookRotation = Quaternion.LookRotation(_targetRotAngle, Vector3.up);
        // lookRotation.x = 0f;
        // lookRotation.z = 0f;
        // transform.rotation = Quaternion.Lerp(_currentRot, lookRotation,
        //     Time.fixedDeltaTime * RotationMultiplier);
        if (LeanTouch.Fingers.Count == 0) return;
        float rotationY = InputController.DeltaInputVector.x * RotationMultiplier * Time.deltaTime;
        float rotationX = InputController.DeltaInputVector.y * RotationMultiplier * .5f * Time.deltaTime;
        var rotCamAngle = new Vector3(0, rotationX, 0);
        transform.Rotate(0, rotationY, 0);
        CameraManager.Instance.CameraController.RotateCameraWithAim(rotCamAngle);
    }


    public void ResetRigidbody()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
    }
}