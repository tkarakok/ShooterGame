using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour, ICrosshairController
{
    private Image _crossHair;
    private RectTransform _crosshairRectTransform;
    
    [SerializeField] private Transform _firePoint;
    private void Start()
    {
        _crossHair = GetComponent<Image>();
        _crosshairRectTransform = _crossHair.GetComponent<RectTransform>();
    }

    private void Update()
    {
        // var objectPosition = Camera.main.WorldToScreenPoint(_firePoint.position + _firePoint.transform.forward * 10);
        // var move = objectPosition - _crosshairRectTransform.position;
        // _crosshairRectTransform.position += move;
    }

    public void SetColor(Color color)
    {
        if(_crossHair.color == color) return;
        _crossHair.color = color;
    }
}
