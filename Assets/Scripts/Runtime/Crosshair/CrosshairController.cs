using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CrosshairController : MonoBehaviour, ICrosshairController
{
    private Image _crossHair;
    private RectTransform _crosshairRectTransform;

    [SerializeField] private Transform _firePoint;
    private Tween _crosshairTween;
    
    private void Start()
    {
        _crossHair = GetComponent<Image>();
        _crosshairRectTransform = _crossHair.GetComponent<RectTransform>();
        SetCrosshairWave();
    }


    public void SetColor(Color color)
    {
        if(_crossHair.color == color) return;
        _crossHair.color = color;
    }

    public void SetCrosshairAnim()
    {
        _crosshairTween?.Kill();
        _crosshairRectTransform.transform.localScale = Vector3.one;
        _crosshairTween = _crosshairRectTransform.DOScale(Vector3.one * 1.2f, .1f).OnComplete(() =>
        {
            _crosshairRectTransform.DOScale(Vector3.one, .1f).SetLoops(1, LoopType.Yoyo);
        });
    }

    public void SetCrosshairWave()
    {
        var newPos = new Vector3(Mathf.Clamp(Random.Range(-10f,10f),-10f,10f),Mathf.Clamp(Random.Range(-10f,10f),-10f,10f),0 );
        _crossHair.transform.DOLocalMove(newPos, .5f).OnComplete(SetCrosshairWave);
    }
}
