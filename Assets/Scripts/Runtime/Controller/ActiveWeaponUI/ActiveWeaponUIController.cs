using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeaponUIController : MonoBehaviour, IActiveWeaponUIController
{
    #region Refences_UI

    [SerializeField] private Image _activeWeaponImage;
    [SerializeField] private TMP_Text _currentAmmoText;
    [SerializeField] private TMP_Text _totalAmmoText;
    #endregion

    [SerializeField]private PlayerAttackController _playerAttackController;
    private Reload _reload;
    
    #region Font Anims

    private Tween _fontAnimTween;
    private float _initFontSize;

    #endregion

    private void Start()
    {
        _playerAttackController = FindObjectOfType<PlayerAttackController>();
        _reload = FindObjectOfType<Reload>(true);
        
        EventManager.Instance.EventController.GetEvent<ReloadEvent>().Data.AddListener(SetActiveReload);
        
        EventManager.Instance.EventController.GetEvent<WeaponChanged>().Data.AddListener(()=>SetAmmoValues());
        EventManager.Instance.EventController.GetEvent<WeaponChanged>().Data.AddListener(ChangeActiveWeaponImage);
        
        EventManager.Instance.EventController.GetEvent<FireEvent>().Data.AddListener(()=>SetAmmoValues());
        
        
    }

    public void SetAmmoValues(bool fontAnim = false)
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
        
        _totalAmmoText.text = _playerAttackController.ActiveWeapon.Magazine.TotalAmmo.ToString();
        _currentAmmoText.text = _playerAttackController.ActiveWeapon.Magazine.CurrentAmmoInMagazine.ToString();
        
        SetTextColor();
    }
    
    public void SetTextColor()
    {
        if (_playerAttackController.ActiveWeapon.Magazine.CurrentAmmoInMagazine <= 5 && _currentAmmoText.color == Color.white)
        {
            _currentAmmoText.DOColor(Color.red, .05f);
        }
        else if (_playerAttackController.ActiveWeapon.Magazine.CurrentAmmoInMagazine > 5 && _currentAmmoText.color == Color.red)
        {
            _currentAmmoText.DOColor(Color.white, .05f);
        }
        
        if (_playerAttackController.ActiveWeapon.Magazine.TotalAmmo == 0 && _totalAmmoText.color == Color.white)
        {
            _totalAmmoText.DOColor(Color.red, .05f);
        }
        else if (_playerAttackController.ActiveWeapon.Magazine.CurrentAmmoInMagazine > 0 && _totalAmmoText.color == Color.red)
        {
            _totalAmmoText.DOColor(Color.white, .05f);
        }
    }

    public void SetActiveReload()
    {
        _reload.SetActiveReload(_playerAttackController.ActiveWeapon.Magazine.ReloadDuration);
        DOVirtual.DelayedCall(_playerAttackController.ActiveWeapon.Magazine.ReloadDuration,()=>SetAmmoValues(true));
    }

    public void ChangeActiveWeaponImage()
    {
        _activeWeaponImage.sprite = _playerAttackController.ActiveWeapon.WeaponData.WeaponImage;
    }
}