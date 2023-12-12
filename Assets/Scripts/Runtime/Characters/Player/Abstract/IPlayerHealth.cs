using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealth : ICharacterHealth
{
    void SetHealthAndDamageBars();
    void SetInitializeHealthBarDefaultValues();
    void SetHealthTextValue(int textValue);
}
