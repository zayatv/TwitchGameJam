using UnityEngine;

namespace Combat.OnHitEffects
{
    public class LogToConsole : OnHitComponent
    {
        public bool time;
        public bool strength = true;

        public override IOnHitBehavior GetBehavior()
        {
            return new LogToConsoleBehavior(this);
        }
    }

    public class LogToConsoleBehavior : OnHitBehavior<LogToConsole>
    {
        public LogToConsoleBehavior(LogToConsole data) : base(data)
        {
        }

        public override void OnHit(HitData hitData)
        {
            var message = hitData.Attacker.name + " attacked " + hitData.Target.name;

            if (data.time)
                message += "\nTime: " + hitData.HitTime;

            if (data.strength)
                message += "\nStrength: " + hitData.HitStrength;

            Debug.Log(message);
        }
    }
}
