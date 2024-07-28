using Animancer;
using UnityEngine;

namespace Gameplay
{
    public class CharacterSprite : MonoBehaviour
    {
        private HybridAnimancerComponent animator;
        private SpriteRenderer spriteRenderer;

        public HybridAnimancerComponent Animator
        {
            get => animator == null ? animator = GetComponent<HybridAnimancerComponent>() : animator;
        }

        public SpriteRenderer SpriteRenderer
        {
            get => spriteRenderer == null ? spriteRenderer = GetComponent<SpriteRenderer>() : spriteRenderer;
        }
    }
}