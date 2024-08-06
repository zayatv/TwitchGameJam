using MoreMountains.InventoryEngine;
using UnityEngine;

namespace Rework.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeInventoryItemSO", menuName = "Upgrades/UpgradeInventoryItemSO")]
    public class UpgradeInventoryItemSO : InventoryItem
    {
        public UpgradeCardSO upgradeCard;
    }
}