using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : CharacterAttackController
{
    public override void Start()
    {
        base.Start();
        EventManager.Instance.EventController.GetEvent<WeaponChanged>().Data.Execute();
    }

    private void Update()
    {
        if (ActiveWeapon != null && Input.GetKeyDown(KeyCode.F) && !NoWeapon)
            Attack(ActiveWeapon);
    }
    
}