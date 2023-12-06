using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDeneme : MonoBehaviour
{
    public Transform crosshair;
    public Transform _startTransform;
    public Vector3 worldPos;

    private void Update()
    {
        Fire();
    }

    void Fire()
    {

        Ray ray = new Ray(_startTransform.position, (crosshair.position - _startTransform.position).normalized);

        // Rayin çarptığı nesneyi tutacak RaycastHit değişkeni
        RaycastHit hit;

        // Rayin bir şeye çarpıp çarpmadığını kontrol et
        if (Physics.Raycast(ray, out hit))
        {
            // Ray çarptı, çarptığı noktadan başlayarak ray çiz
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            // Çarptığı nesnenin adını konsola yazdır
            Debug.Log("Ray çarptı! Çarpılan nesne: " + hit.collider.gameObject.name);
        }
        else
        {
            // Ray çarpmadı, başlangıç noktasından uzak bir mesafeye kadar ray çiz
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
        }
    }
}