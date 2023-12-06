
    using UnityEngine;

    public abstract class CharacterAttackController : MonoBehaviour, ICharacterAttack 
    {
        public void Attack(IWeapon weapon)
        {
            weapon.Attack();
        }
    }