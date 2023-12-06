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
    
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _damageBar;
    [SerializeField] private TMP_Text _healthText;

    #region Tweens

    Tween _healthBarTween;
    Tween _damageBarTween;

    #endregion

    #region Character_Fields

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    #endregion
   

    public virtual void Start()
    {
        _character = GetComponent<Character>();
        SetCharacterHealthValues(_character);
        SetInitializeHealthBarDefaultValues();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(UnityEngine.Random.Range(5,20));
        }
    }

    public void SetCharacterHealthValues(Character character)
    {
        MaxHealth = _character.MaxHealth;
        CurrentHealth = MaxHealth;
    }

    public void SetHealthAndDamageBars()
    {
        _healthBarTween?.Kill();
        _damageBarTween?.Kill();
        
        _healthBarTween = _healthBar.DOValue(CurrentHealth, .1f).SetEase(Ease.Flash);
        _damageBarTween = _damageBar.DOValue(CurrentHealth, .25f).SetEase(Ease.Flash);
    }

    public void SetInitializeHealthBarDefaultValues()
    {
        _healthBar.maxValue = MaxHealth;
        _damageBar.maxValue = MaxHealth;

        _healthBar.value = MaxHealth;
        _damageBar.value = MaxHealth;
    }

    public void SetHealthTextValue(int textValue)
    {
        _healthText.text = textValue.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0) return;
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
       
        SetHealthTextValue(CurrentHealth);
        SetHealthAndDamageBars();
        
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            // dead 
        }
        
    }
}