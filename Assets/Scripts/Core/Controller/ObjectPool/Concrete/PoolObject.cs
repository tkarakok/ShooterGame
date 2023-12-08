using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour, IPoolObject
{
    public bool IsAvailable { get; set; } = true;

    public void OnGetPool(bool isActive)
    {
        gameObject.SetActive(isActive);
        IsAvailable = false;
    }

    public void ResetObject()
    {
        IsAvailable = true;
        gameObject.SetActive(false);
        transform.position = Vector3.zero;
    }

    public void DestroyObject()
    {
        DestroyObject(gameObject);
    }
}
