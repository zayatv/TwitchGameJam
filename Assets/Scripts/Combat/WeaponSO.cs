using Combat.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Combat/WeaponSO")]
    public class WeaponSO : ScriptableObject
    {
        public string weaponName;
        [TextArea]
        public string description;
        public WeaponBehaviour prefab;
        public bool changeAnimator = true;
        [ShowIf(nameof(changeAnimator))]
        public RuntimeAnimatorController animatorController;
    }
}