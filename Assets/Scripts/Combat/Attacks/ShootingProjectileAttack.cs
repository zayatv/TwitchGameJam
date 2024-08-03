using UnityEngine;

namespace Combat.Attacks
{
    public class ShootingProjectileAttack : AttackBehavior
    {
        [SerializeField] protected Projectile projectilePrefab;
        [SerializeField] protected AttackMotion attack;
        [SerializeField] protected float attackCooldown = 0.3f;

        private float lastAttackEndTime;

        public override void AttackPerformed()
        {
            base.AttackPerformed();

            if (Time.time < lastAttackEndTime + attackCooldown) return;

            lastAttackEndTime = Time.time;

            actor.CurrentAnimator.Play(attack.animation);
            Instantiate(attack.particleEffect, actor.transform);

            var projectile = Instantiate(projectilePrefab);
            projectile.Shoot(actor.AimDirection);
        }
    }
}