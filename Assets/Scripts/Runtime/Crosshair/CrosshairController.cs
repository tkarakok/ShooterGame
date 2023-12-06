using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour, ICrosshairController
{
    private Image _crossHair;

    private void Start()
    {
        _crossHair = GetComponent<Image>();
    }

    public void SetColor(Color color)
    {
        if(_crossHair.color == color) return;
        _crossHair.color = color;
    }
}
