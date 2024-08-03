namespace Combat.OnHitEffects
{
    using Stats;

    public class Damage : OnHitComponent
    {
        public override IOnHitBehavior GetBehavior()
        {
            return new DamageBehavior(this);
        }
    }

    public class DamageBehavior : OnHitBehavior<Damage>
    {
        public DamageBehavior(Damage data) : base(data)
        {
        }

        public override void OnHit(HitData hitData)
        {
            var attackerStats = hitData.Attacker.GetComponent<CharacterStats>();
            var targetStats = hitData.Target.GetComponent<CharacterStats>();

            attackerStats.Damage(targetStats);
        }
    }
}