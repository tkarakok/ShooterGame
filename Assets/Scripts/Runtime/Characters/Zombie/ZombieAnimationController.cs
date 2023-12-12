using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationController : CharacterAnimationController, IZombieAnim
{
    public void Death()
    {
        _animator.SetTrigger("Death");
    }
}
