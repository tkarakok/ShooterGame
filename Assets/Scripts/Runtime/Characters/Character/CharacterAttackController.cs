
    using System.Collections.Generic;
    using System.Linq;
    using Core.Utilities.Results;
    using UnityEngine;

    public abstract class CharacterAttackController : MonoBehaviour, ICharacterAttack 
    {
        public Weapon ActiveWeapon { get; protected set; }
        public bool NoWeapon;
        
        private List<Weapon> _allWeapons = new List<Weapon>();

        public virtual void Start()
        {
            if (NoWeapon) return;
            GetAllWeapons();
            ActiveWeapon = GetComponentInChildren<Weapon>();
            ActiveWeapon.ChangeActiveneesWeapon(true);
            
        }
        
        public void GetAllWeapons()
        {
            _allWeapons = GetComponentsInChildren<Weapon>(true).ToList();
        }

        public Result ChangeActiveWeapon(Weapon newWeapon)
        {
            ActiveWeapon.gameObject.SetActive(false);
            ActiveWeapon.ChangeActiveneesWeapon(false);
            newWeapon.gameObject.SetActive(true);
            newWeapon.ChangeActiveneesWeapon(true);
            ActiveWeapon = newWeapon;
            EventManager.Instance.EventController.GetEvent<WeaponChanged>().Data.Execute();
            return new SuccessResult("Weapon Changed !");
        }

        public void Attack(IWeapon weapon)
        {
            weapon.Attack();
        }
    }