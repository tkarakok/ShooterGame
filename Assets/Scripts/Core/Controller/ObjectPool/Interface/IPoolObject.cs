using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    public void OnGetPool(bool isActive);
    public void ResetObject();
    public void DestroyObject();
    
}
