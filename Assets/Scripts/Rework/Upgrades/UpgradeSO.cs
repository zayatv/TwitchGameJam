using MoreMountains.InventoryEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MoreMountains.TopDownEngine.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeSO", menuName = "Upgrades/UpgradeSO")]
    public class UpgradeSO : ScriptableObject
    {
        [Header("Health")]
        public bool Health;
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

        private Character _character;
        
        public void Equip()
        {
            _character = LevelManager.Instance.Players[0];
            
            AddStats();
            AddInventoryItem();
        }

        public void UnEquip()
        {
            _character = LevelManager.Instance.Players[0];
            
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

            if (!_character.TryGetComponent(out Health health)) return;

            health.MaximumHealth += amount;
        }

        private void ChangeDefense(float amount)
        {
            if (!Defense) return;
            
            if (!_character.TryGetComponent(out Health health)) return;

            var defense = health.TargetDamageResistanceProcessor.DamageResistanceList[0];

            defense.DamageMultiplier -= amount;
        }

        private void ChangeAttack(float amount)
        {
            if (!Attack) return;
            
            if (!_character.TryGetComponent(out Health health)) return;

            var attack = health.TargetDamageResistanceProcessor.DamageResistanceList[1];

            attack.DamageMultiplier += amount;
        }

        private void ChangeSpeed(float amount)
        {
            if (!Speed) return;
            
            if (!_character.TryGetComponent(out CharacterMovement movement)) return;

            movement.MovementSpeed += amount;
        }

        private void AddInventoryItem()
        {
            if (!Item) return;

            Inventory inv = InventoryItem.TargetInventory(_character.PlayerID);

            //if ()

            inv.AddItem(InventoryItem, InventoryItem.Quantity);
        }

        private void RemoveInventoryItem()
        {
            if (!Item) return;

            InventoryItem.TargetInventory(_character.PlayerID).RemoveItemByID(InventoryItem.ItemID, InventoryItem.Quantity);
        }
    }
}