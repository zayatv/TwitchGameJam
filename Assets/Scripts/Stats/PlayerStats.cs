using Gameplay.Player;
using TMPro;
using UnityEngine;

namespace Stats
{
    public class PlayerStats : CharacterStats
    {
        [SerializeField] private TextMeshProUGUI healthText;

        private Player player;

        protected override void Start()
        {
            base.Start();

            player = GetComponent<Player>();

            healthText.text = CurrentHealth.ToString();
        }

        protected override void Update()
        {
            base.Update();

            var targetHealthValue = CurrentHealth;

            healthText.text = Mathf.Lerp(float.Parse(healthText.text), targetHealthValue, healthSliderSmoothSpeed * Time.deltaTime).ToString();
        }

        protected override void Die()
        {
            base.Die();
        }
    }
}