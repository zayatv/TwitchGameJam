using UnityEngine;

namespace Rework.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeCardSO", menuName = "Upgrades/UpgradeCardSO")]
    public class UpgradeCardSO : ScriptableObject
    {
        public string upgradeCardName;
        public string upgradeCardDescription;
        public Sprite upgradeCardIcon;
        public int amountNeededToMerge;
        
    }
}