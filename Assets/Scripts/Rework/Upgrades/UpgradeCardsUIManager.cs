using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.TopDownEngine.Upgrades
{
    public class UpgradeCardsUIManager : MonoBehaviour
    {
        public static UpgradeCardsUIManager Instance;

        [SerializeField] private UpgradeCardUI cardButton;
        [SerializeField] private Transform container;
        [SerializeField] private Transform cardsParent;

        private void Awake()
        {
            Instance = this;
        }

        public List<UpgradeCardUI> SetUICards(List<UpgradeCardSO> upgradeCards)
        {
            List<UpgradeCardUI> cards = new List<UpgradeCardUI>();
            
            if (upgradeCards.Count == 0) return cards;
            
            OpenCardsMenu();
            
            foreach (var upgradeCard in upgradeCards)
            {
                var card = Instantiate(cardButton, container);

                card.CardIcon.sprite = upgradeCard.upgradeCardIcon;
                card.CardTitle.text = upgradeCard.upgradeCardName;
                card.CardDescription.text = upgradeCard.upgradeCardLongDescription;
                
                cards.Add(card);
                
                card.GetComponent<Button>().onClick.AddListener(CloseCardsMenu);
            }

            return cards;
        }

        private void OpenCardsMenu()
        {
            cardsParent.gameObject.SetActive(true);
        }
        
        private void CloseCardsMenu()
        {
            cardsParent.gameObject.SetActive(false);
        }
    }
}
