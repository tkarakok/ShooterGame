using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMagazine : IMagazine
{
    void SetUiValues(bool fontAnim = false);
    void SetTextColor();
}
