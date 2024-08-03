using Animancer;
using Gameplay;
using UnityEngine;

namespace Combat.Attacks
{
    public class AttackBehavior : MonoBehaviour
    {
        protected Actor actor;

        protected HybridAnimancerComponent Animator => actor.CurrentAnimator;

        protected virtual void Start()
        {
            actor = GetComponentInParent<Actor>();
        }

        protected virtual void OnDestroy()
        {

        }

        protected virtual void Update()
        {

        }

        public virtual void OnEquip()
        {
            Debug.Log(GetType().Name);
        }

        public virtual void AttackPerformed()
        {
        }
    }
}