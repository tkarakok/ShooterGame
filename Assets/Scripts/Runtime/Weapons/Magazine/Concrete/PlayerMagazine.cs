using System;
using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerMagazine : Magazine, IPlayerMagazine
{
    #region Refences_UI
    [SerializeField] private TMP_Text _currentAmmoText;
    [SerializeField] private TMP_Text _totalAmmoText;
    [SerializeField] private GameObject _reloadPanel;
    #endregion

    private Reload _reload;
    
    #region Font Anims

    private Tween _fontAnimTween;
    private float _initFontSize;

    #endregion

    private void Start()
    {
        _reload = FindObjectOfType<Reload>(true);
    }

    public void SetUiValues(bool fontAnim = false)
    {
        if (fontAnim)
        {
            if (_initFontSize == 0)
                _initFontSize = _currentAmmoText.fontSize;
            
            _currentAmmoText.fontSize = _initFontSize;
            _fontAnimTween?.Kill();
            _fontAnimTween = _currentAmmoText.DOFontSize(_initFontSize + 4.5f, .1f).OnComplete(() =>
            {
                _currentAmmoText.DOFontSize(_initFontSize, .1f);
            });
        }
        
        _totalAmmoText.text = TotalAmmo.ToString();
        _currentAmmoText.text = CurrentAmmoInMagazine.ToString();
        SetTextColor();
    }

    public void SetTextColor()
    {
        if (CurrentAmmoInMagazine <= 5 && _currentAmmoText.color == Color.white)
        {
            _currentAmmoText.DOColor(Color.red, .05f);
        }
        else if (CurrentAmmoInMagazine > 5 && _currentAmmoText.color == Color.red)
        {
            _currentAmmoText.DOColor(Color.white, .05f);
        }
        
        if (TotalAmmo == 0 && _totalAmmoText.color == Color.white)
        {
            _totalAmmoText.DOColor(Color.red, .05f);
        }
        else if (CurrentAmmoInMagazine > 0 && _totalAmmoText.color == Color.red)
        {
            _totalAmmoText.DOColor(Color.white, .05f);
        }
    }

    public override void Reload()
    {
        base.Reload();
        _reload.SetActiveReload(ReloadDuration);
        DOVirtual.DelayedCall(ReloadDuration,()=>SetUiValues(true));
    }

    public override void SetMagazineDatas(MagazineData _magazineData)
    {
        base.SetMagazineDatas(_magazineData);
        SetUiValues();
    }

    public override void DecreaseCurrentAmmoInMagazine()
    {
        base.DecreaseCurrentAmmoInMagazine();
        SetUiValues(true);
    }
}
