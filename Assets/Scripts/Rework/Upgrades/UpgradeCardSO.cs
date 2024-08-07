using UnityEngine;

namespace MoreMountains.TopDownEngine.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeCardSO", menuName = "Upgrades/UpgradeCardSO")]
    public class UpgradeCardSO : ScriptableObject
    {
        public string upgradeCardName;
        [TextArea]
        public string upgradeCardShortDescription;
        [TextArea]
        public string upgradeCardLongDescription;
        public Sprite upgradeCardIcon;
        public int amountNeededToMerge;
        public UpgradeSO currentUpgrade;
        public UpgradeCardSO nextUpgrade;
        public UpgradeInventoryItemSO upgradeInventoryItem;

        public void Equip()
        {
            currentUpgrade.Equip();
        }
        
        public void UnEquip()
        {
            currentUpgrade.UnEquip();
        }
    }
}