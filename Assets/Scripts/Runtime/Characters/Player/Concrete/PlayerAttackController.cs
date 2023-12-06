using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : CharacterAttackController
{
    public IWeapon Weapon { get; private set; }

    private void Start()
    {
        Weapon = GetComponentInChildren<IWeapon>();
    }

    private void Update()
    {
        if (Weapon != null && Input.GetKeyDown(KeyCode.F))
            Attack(Weapon);
    }
    
}