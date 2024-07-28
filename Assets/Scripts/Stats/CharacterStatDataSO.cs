using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(fileName = "CharacterStatDataSO", menuName = "Character/Stats/CharacterStatDataSO")]
    public class CharacterStatDataSO : ScriptableObject
    {
        [Header("Offensive Stats")]
        public float BaseAttack;
        public float BaseAttackSpeed;
        public float BaseCriticalHit;

        [Header("Defensive Stats")]
        public float BaseDefense;
        public float BaseHealth;

        [Header("Utility Stats")]
        public float BaseLuck;
        public float BaseSpeed;
    }
}