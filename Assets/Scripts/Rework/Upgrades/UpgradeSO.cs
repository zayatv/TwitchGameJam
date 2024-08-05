using MoreMountains.InventoryEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Rework.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeSO", menuName = "Upgrades/UpgradeSO")]
    public class UpgradeSO : ScriptableObject
    {
        [Header("Health")]
        public bool Health;
        [ShowIf(nameof(Health))] public bool MaxHealth;
        [ShowIf(nameof(Health))] public int HealthAmount;

        [Header("Defense")]
        public bool Defense;
        [ShowIf(nameof(Defense))] public float DefenseAmount;

        [Header("Attack")]
        public bool Attack;
        [ShowIf(nameof(Attack))] public float AttackAmount;

        [Header("Speed")]
        public bool Speed;
        [ShowIf(nameof(Speed))] public float SpeedAmount;

        [Header("Item")]
        public bool Item;
        [ShowIf(nameof(Item))] public InventoryItem InventoryItem;

        public void Equip()
        {
            AddStats();
            AddInventoryItem();
        }

        public void UnEquip()
        {
            RemoveStats();
            RemoveInventoryItem();
        }

        private void AddStats()
        {
            ChangeHealth(HealthAmount);
            ChangeDefense(DefenseAmount);
            ChangeAttack(AttackAmount);
            ChangeSpeed(SpeedAmount);
        }

        private void RemoveStats()
        {
            ChangeHealth(-HealthAmount);
            ChangeDefense(-DefenseAmount);
            ChangeAttack(-AttackAmount);
            ChangeSpeed(-SpeedAmount);
        }

        private void ChangeHealth(int amount)
        {
            if (!Health) return;
        }

        private void ChangeDefense(float amount)
        {
            if (!Defense) return;
        }

        private void ChangeAttack(float amount)
        {
            if (!Attack) return;
        }

        private void ChangeSpeed(float amount)
        {
            if (!Speed) return;
        }

        private void AddInventoryItem()
        {
            if (!Item) return;
        }

        private void RemoveInventoryItem()
        {
            if (!Item) return;
        }
    }
}