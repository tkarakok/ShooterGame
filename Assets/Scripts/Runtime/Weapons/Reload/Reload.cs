using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour, IReload
{
    [SerializeField] private Slider _reloadSlider;

    public void SetActiveReload(float reloadDuration)
    {
        gameObject.SetActive(true);
        if (!_reloadSlider)
            _reloadSlider = GetComponentInChildren<Slider>();

        _reloadSlider.value = 0;
        _reloadSlider.maxValue = reloadDuration;
        _reloadSlider.DOValue(_reloadSlider.maxValue, reloadDuration).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
