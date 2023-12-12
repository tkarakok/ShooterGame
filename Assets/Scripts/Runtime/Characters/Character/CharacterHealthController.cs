using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public abstract class CharacterHealthController : MonoBehaviour, ICharacterHealth, IDamagable
{
    private Character _character;
    
   

    #region Character_Fields

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public bool IsDead { get; set; }

    #endregion
   

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

   

    public virtual void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0) return;
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
       
        if (CurrentHealth <= 0)
        {
            IsDead = true;
            CurrentHealth = 0;
            GetComponent<ICharacterAnim>().Death();
        }
        
    }
}