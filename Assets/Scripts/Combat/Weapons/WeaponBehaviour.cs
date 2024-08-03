using Animancer;
using Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Combat.Weapons
{
    public class WeaponBehaviour : MonoBehaviour
    {
        [SerializeField] protected bool hasVisual;
        [SerializeField][ShowIf(nameof(hasVisual))] protected GameObject weaponVisual;

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

        public virtual void Attack_Performed()
        {
            Debug.Log("Attack");
        }
    }
}