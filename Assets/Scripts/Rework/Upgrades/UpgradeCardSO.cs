using UnityEngine;

namespace Rework.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeCardSO", menuName = "Upgrades/UpgradeCardSO")]
    public class UpgradeCardSO : ScriptableObject
    {
        public string upgradeCardName;
        public string upgradeCardShortDescription;
        public string upgradeCardLongDescription;
        public Sprite upgradeCardIcon;
        public int amountNeededToMerge;
        public UpgradeSO currentUpgrade;
        public UpgradeCardSO nextUpgrade;

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