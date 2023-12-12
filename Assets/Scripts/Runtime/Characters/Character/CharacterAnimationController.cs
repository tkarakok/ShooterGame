using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAnimationController : MonoBehaviour, ICharacterAnim
{
    protected Animator _animator;

    public virtual void Start()
    {
        SetAnimator();
    }

    public void SetAnimator()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Death()
    {
        _animator.SetTrigger("Death");
    }
}
