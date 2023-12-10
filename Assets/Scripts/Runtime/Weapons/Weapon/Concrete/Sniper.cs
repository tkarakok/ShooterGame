using UnityEngine;

public class Sniper : Weapon, ISniper
{
    private Transform _firePoint;

    private void Awake()
    {
        _firePoint = GetComponentInChildren<FirePoint>().transform;
    }

    public void Attack()
    {
        Ray ray = new Ray(_firePoint.position,
            (GameManager.Instance.CrossHair.position - _firePoint.position).normalized);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue);
        }
    }
}