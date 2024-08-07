using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace MoreMountains.TopDownEngine.Upgrades
{
    public class UpgradeCardManager : MonoBehaviour
    {
        public static UpgradeCardManager Instance;
        
        [field: Header("Upgrade Cards")]
        [field: SerializeField] public List<UpgradeCardSO> AvailableUpgrades { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public List<UpgradeCardSO> GetRandomUpgradeCards(int amount)
        {
            List<UpgradeCardSO> availableUpgradeCards = AvailableUpgrades;
            List<UpgradeCardSO> upgrades = new List<UpgradeCardSO>();

            amount = amount > availableUpgradeCards.Count ? availableUpgradeCards.Count : amount;

            for (int i = 0; i < amount; i++)
            {
                UpgradeCardSO card = GetRandomUpgradeCard(availableUpgradeCards);
                availableUpgradeCards.Remove(card);
                upgrades.Add(card);
            }

            return upgrades;
        }

        public UpgradeCardSO GetRandomUpgradeCard(List<UpgradeCardSO> cards)
        {
            int max = cards.Count - 1;
            Random r = new Random();
            int index = r.Next(0, max);

            return cards[index];
        }
    }
}