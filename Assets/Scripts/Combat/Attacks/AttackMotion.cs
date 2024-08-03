using Animancer;
using System;
using UnityEngine;

namespace Combat.Attacks
{
    [Serializable]
    public class AttackMotion
    {
        public ClipTransition animation;
        public OnHitEffect onHitEffect;
        public Transform particleEffect;
    }
}