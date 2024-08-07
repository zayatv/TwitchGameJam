using MoreMountains.InventoryEngine;
using UnityEngine;

namespace MoreMountains.TopDownEngine.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeInventoryItemSO", menuName = "Upgrades/UpgradeInventoryItemSO")]
    public class UpgradeInventoryItemSO : InventoryItem
    {
        [Header("Upgrade Card")]
        public UpgradeCardSO upgradeCard;

        private Character _character;

        public override bool Equip(string playerID)
        {
            _character = LevelManager.Instance.Players[0];
            
            AddStats();
            AddInventoryItem();
            
            return true;
        }

        public override bool UnEquip(string playerID)
        {
            _character = LevelManager.Instance.Players[0];
            
            RemoveStats();
            RemoveInventoryItem();
            
            return true;
        }
        
        // HELP PLEASE

        private void AddStats()
        {
            ChangeHealth(upgradeCard.currentUpgrade.HealthAmount);
            ChangeDefense(upgradeCard.currentUpgrade.DefenseAmount);
            ChangeAttack(upgradeCard.currentUpgrade.AttackAmount);
            ChangeSpeed(upgradeCard.currentUpgrade.SpeedAmount);
        }

        private void RemoveStats()
        {
            ChangeHealth(-upgradeCard.currentUpgrade.HealthAmount);
            ChangeDefense(-upgradeCard.currentUpgrade.DefenseAmount);
            ChangeAttack(-upgradeCard.currentUpgrade.AttackAmount);
            ChangeSpeed(-upgradeCard.currentUpgrade.SpeedAmount);
        }

        private void ChangeHealth(int amount)
        {
            if (!upgradeCard.currentUpgrade.Health) return;

            if (!_character.TryGetComponent(out Health health)) return;

            health.MaximumHealth += amount;
        }

        private void ChangeDefense(float amount)
        {
            if (!upgradeCard.currentUpgrade.Defense) return;
            
            if (!_character.TryGetComponent(out Health health)) return;

            var defense = health.TargetDamageResistanceProcessor.DamageResistanceList[0];

            defense.DamageMultiplier -= amount;
        }

        private void ChangeAttack(float amount)
        {
            if (!upgradeCard.currentUpgrade.Attack) return;
            
            if (!_character.TryGetComponent(out Health health)) return;

            var attack = health.TargetDamageResistanceProcessor.DamageResistanceList[1];

            attack.DamageMultiplier += amount;
        }

        private void ChangeSpeed(float amount)
        {
            if (!upgradeCard.currentUpgrade.Speed) return;
            
            if (!_character.TryGetComponent(out CharacterMovement movement)) return;

            movement.MovementSpeed += amount;
        }

        private void AddInventoryItem()
        {
            if (!upgradeCard.currentUpgrade.Item) return;

            Inventory inv = upgradeCard.currentUpgrade.InventoryItem.TargetInventory(_character.PlayerID);

            //if ()

            inv.AddItem(upgradeCard.currentUpgrade.InventoryItem, upgradeCard.currentUpgrade.InventoryItem.Quantity);
        }

        private void RemoveInventoryItem()
        {
            if (!upgradeCard.currentUpgrade.Item) return;

            Inventory inv = upgradeCard.currentUpgrade.InventoryItem.TargetInventory(_character.PlayerID);

            inv.RemoveItemByID(upgradeCard.currentUpgrade.InventoryItem.ItemID, upgradeCard.currentUpgrade.InventoryItem.Quantity);
        }
    }
}