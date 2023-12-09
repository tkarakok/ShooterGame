using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponChangeController : MonoBehaviour, IWeaponChangeController
    {
        [SerializeField] private RectTransform _weaponChangePanel;
        
        [Header("Width - Height")]
        [SerializeField] private Vector2 _onClosingValues;
        [SerializeField] private Vector2 _onOpeningValues;
        
        [Header("Anchor Pos")]
        [SerializeField] private Vector3 _onClosingAnchorPos;
        [SerializeField] private Vector3 _onOpeningAnchorPos;

        [Header("Open Arrow - Close Arrow Image")]
        [SerializeField]private GameObject _openArrow; 
        [SerializeField]private GameObject _closeArrow; 
        
        
        private bool _openedWeaponPanel;

        public void WeaponPanelAction()
        {
            if (_openedWeaponPanel)
                CloseWeaponChangePanel();
            else
                OpenWeaponChangePanel();
        }

        public void OpenWeaponChangePanel()
        {
            _openedWeaponPanel = true;
            _openArrow.SetActive(false);
            _closeArrow.SetActive(true);
            _weaponChangePanel.DOSizeDelta(_onOpeningValues, .25f);
            _weaponChangePanel.DOAnchorPos3D(_onOpeningAnchorPos, .25f);
        }

        public void CloseWeaponChangePanel()
        {
            _openArrow.SetActive(true);
            _closeArrow.SetActive(false);
            _openedWeaponPanel = false;
            _weaponChangePanel.DOSizeDelta(_onClosingValues, .25f);
            _weaponChangePanel.DOAnchorPos3D(_onClosingAnchorPos, .25f);
        }
    }