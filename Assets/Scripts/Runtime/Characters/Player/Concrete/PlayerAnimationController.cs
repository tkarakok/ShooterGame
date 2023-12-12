using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : CharacterAnimationController, IPlayerAnim
{
    public void SetMovementAnim(float animFloat)
    {
        _animator.SetFloat("Movement", animFloat);
    }
    
}
