using UnityEngine;
using UnityEngine.UI;

namespace Stats
{
    public class CharacterStats : MonoBehaviour
    {
        [Header("Offensive Stats")]
        public Stat Attack;
        public Stat AttackSpeed;
        public Stat CriticalHit;

        [Header("Defensive Stats")]
        public Stat Defense;
        public Stat Health;

        [Header("Utility Stats")]
        public Stat Luck;
        public Stat Speed;

        [HideInInspector] public bool IsImmune;

        [HideInInspector] public float ShieldHealth;

        [HideInInspector] public float CurrentHealth;

        protected bool isDead;
        protected bool isHitCritical;

        [Header("Base Data")]
        [SerializeField] private CharacterStatDataSO characterStatData;

        [Header("UI")]
        [SerializeField] private Slider healthSlider;
        [SerializeField] protected float healthSliderSmoothSpeed = 20f;

        protected virtual void Start()
        {
            SetStatsBaseData();

            CurrentHealth = Health.GetValue();

            healthSlider.value = CurrentHealth / Health.GetValue();
        }

        protected virtual void Update()
        {
            var targetHealthValue = CurrentHealth / Health.GetValue();

            healthSlider.value = Mathf.Lerp(healthSlider.value, targetHealthValue, healthSliderSmoothSpeed * Time.deltaTime);
        }

        public virtual void Damage(CharacterStats targetStats)
        {
            if (targetStats.IsImmune) return;

            float totalDamage = Attack.GetValue();

            if (IsCriticalHit())
            {
                totalDamage = CalculateCriticalDamage(totalDamage);
                targetStats.isHitCritical = true;
            }
            else
            {
                targetStats.isHitCritical = false;
            }

            totalDamage = GetTargetArmor(targetStats, totalDamage);

            if (totalDamage < 1) totalDamage = 1;

            targetStats.TakeDamage(totalDamage);
        }

        public virtual void TakeDamage(float damage)
        {
            damage = GetShield(damage);

            DecreaseHealth(damage);

            if (CurrentHealth < 0 && !isDead) Die();
        }

        protected virtual void DecreaseHealth(float amount)
        {
            CurrentHealth -= amount;
        }

        protected virtual void Die() => isDead = true;

        private bool IsCriticalHit()
        {
            float totalCriticalChance = CriticalHit.GetValue() > 75 ? 75 : CriticalHit.GetValue();

            if (Random.Range(0, 100) <= totalCriticalChance)
            {
                return true;
            }

            return false;
        }

        private float CalculateCriticalDamage(float damage)
        {
            if (CriticalHit.GetValue() - 75 <= 0) return 110f;

            float critDamage = 110 + (CriticalHit.GetValue() - 75);

            return damage * (critDamage / 100);
        }

        private float GetShield(float damage)
        {
            float totalDamage = damage;

            damage -= ShieldHealth;

            if (damage < 0) damage = 0;

            float shieldReduction = totalDamage - damage > ShieldHealth ? ShieldHealth : totalDamage - damage;

            ShieldHealth -= shieldReduction;

            return damage;
        }

        private float GetTargetArmor(CharacterStats targetStats, float totalDamage)
        {
            if (targetStats.Defense.GetValue() > 0)
            {
                float damageModifier = Mathf.Exp(-targetStats.Defense.GetValue() * 0.01f);

                if (damageModifier > 1) damageModifier = 1;

                totalDamage *= damageModifier;
            }

            return totalDamage;
        }

        public void RecoverHealth(float amount)
        {
            CurrentHealth += amount;

            if (CurrentHealth > Health.GetValue())
            {
                CurrentHealth = Health.GetValue();
            }
        }

        private void SetStatsBaseData()
        {
            Attack = new Stat(characterStatData.BaseAttack);
            AttackSpeed = new Stat(characterStatData.BaseAttackSpeed);
            CriticalHit = new Stat(characterStatData.BaseCriticalHit);

            Defense = new Stat(characterStatData.BaseDefense);
            Health = new Stat(characterStatData.BaseHealth);

            Luck = new Stat(characterStatData.BaseLuck);
            Speed = new Stat(characterStatData.BaseSpeed);
        }
    }
}