using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : CharacterHealthController, IPlayerHealth
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _damageBar;
    [SerializeField] private TMP_Text _healthText;

    #region Tweens

    Tween _healthBarTween;
    Tween _damageBarTween;

    #endregion
    public override void Start()
    {
        base.Start();
        SetInitializeHealthBarDefaultValues();
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

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        SetHealthTextValue(CurrentHealth);
        SetHealthAndDamageBars();
    }
}
