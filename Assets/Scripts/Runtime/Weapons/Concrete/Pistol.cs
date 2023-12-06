using System;
using UnityEngine;

public class Pistol : Weapon, IPistol
{
    private Transform _firePoint;

    private void Awake()
    {
        _firePoint = GetComponentInChildren<FirePoint>().transform;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Attack()
    {
        base.Attack();
        Ray ray = new Ray(_firePoint.position, (GameManager.Instance.CrossHair.position - _firePoint.position).normalized);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            if (hit.collider.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(50);
                GameManager.Instance.CrosshairController.SetColor(Color.red);
                Debug.Log("Ray çarptı! Çarpılan nesne: " + hit.collider.gameObject.name);
            }
            
        }
        else
        {
            GameManager.Instance.CrosshairController.SetColor(Color.green);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
        }
    }
}