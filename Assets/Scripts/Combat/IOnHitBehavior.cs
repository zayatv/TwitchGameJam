using Combat.Utilities;

namespace Combat
{
    public interface IOnHitBehavior : IActionListBehavior
    {
        void OnHit(HitData hitData);
    }
}
