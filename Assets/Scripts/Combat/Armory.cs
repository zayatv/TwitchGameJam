using Combat.Weapons;
using Gameplay;
using Gameplay.Player;
using UnityEngine;

namespace Combat
{
    public class Armory : MonoBehaviour
    {
        [SerializeField] private WeaponSO startingWeapon;

        private Actor actor;

        public WeaponSO CurrentWeapon { get; private set; }
        public WeaponBehaviour CurrentWeaponBehaviour { get; private set; }

        private void Start()
        {
            actor = GetComponent<Player>();

            if (startingWeapon != null)
                EquipWeapon(startingWeapon);
        }

        public void EquipWeapon(WeaponSO weapon)
        {
            if (CurrentWeapon != null)
                UnequipCurrentWeapon();

            CurrentWeapon = weapon;

            CurrentWeaponBehaviour = Instantiate(weapon.prefab, actor.CurrentCharacter.AttackHolder);

            if (CurrentWeapon.changeAnimator)
            {
                if (CurrentWeapon.animatorController != actor.CurrentController)
                {
                    actor.UpdateAnimatorController(CurrentWeapon.animatorController);
                }
            }
        }

        public void UnequipCurrentWeapon()
        {
            if (CurrentWeapon == null)
                return;

            if (CurrentWeapon.changeAnimator)
                actor.UpdateAnimatorController(null);

            CurrentWeapon = null;
            Destroy(CurrentWeaponBehaviour.gameObject);
        }
    }
}