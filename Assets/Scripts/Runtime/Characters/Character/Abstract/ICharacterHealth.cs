using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterHealth
{
    void SetCharacterHealthValues(Character character);
    void SetHealthAndDamageBars();
    void SetInitializeHealthBarDefaultValues();
    void SetHealthTextValue(int textValue);
}
