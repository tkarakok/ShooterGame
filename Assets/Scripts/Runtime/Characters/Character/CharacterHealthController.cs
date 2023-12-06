using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterHealthController : MonoBehaviour, ICharacterHealth
{
    private Character _character;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    
    public virtual void Start()
    {
        _character = GetComponent<Character>();
        SetCharacterHealthValues(_character);
    }

    public void SetCharacterHealthValues(Character character)
    {
        MaxHealth = _character.MaxHealth;
        CurrentHealth = MaxHealth;
    }
}
