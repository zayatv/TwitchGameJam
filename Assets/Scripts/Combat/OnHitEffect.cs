using Combat.Utilities;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(menuName = "Combat/On Hit Effect")]
    public class OnHitEffect : ActionList<OnHitComponent, IOnHitBehavior>
    {

    }
}
