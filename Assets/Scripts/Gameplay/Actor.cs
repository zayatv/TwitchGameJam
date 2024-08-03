using Animancer;
using System;
using UnityEngine;
using Stats;

namespace Gameplay
{
    public class Actor : MonoBehaviour
    {
        [SerializeField] protected RuntimeAnimatorController defaultController;

        public Rigidbody2D Rigidbody { get; private set; }
        public CapsuleCollider2D Collider { get; private set; }
        public CharacterStats Stats { get; private set; }
        public CharacterSprite CurrentCharacter { get; private set; }
        public HybridAnimancerComponent CurrentAnimator { get; private set; }
        public RuntimeAnimatorController CurrentController { get; private set; }

        public Vector2 FacingDir { get; protected set; } = new Vector2(1, 0);
        protected bool facingRight = true;

        public Vector2 AimDirection { get; protected set; } = new Vector2(1, 0);

        public Action OnFlipped;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Collider = GetComponent<CapsuleCollider2D>();
            Stats = GetComponent<CharacterStats>();

            var startingCharacter = GetComponentInChildren<CharacterSprite>();

            if (startingCharacter != null ) 
                UpdateCharacter(startingCharacter, false);
        }

        public void ResetVelocity()
        {
            Rigidbody.linearVelocity = Vector2.zero;
        }

        public void SetVelocity(float xVelocity, float yVelocity)
        {
            Rigidbody.linearVelocity = new Vector2(xVelocity, yVelocity);
            FlipController(xVelocity);
        }

        public virtual void Flip()
        {
            facingRight = !facingRight;

            transform.Rotate(0, 180, 0);

            OnFlipped?.Invoke();
        }

        public virtual void FlipController(float x)
        {
            if (x > 0 && !facingRight)
                Flip();
            else if (x < 0 && facingRight)
                Flip();
        }

        public virtual void UpdateCharacter(CharacterSprite character, bool isPrefab = true)
        {
            if (CurrentCharacter != null)
                Destroy(CurrentCharacter.gameObject);

            CurrentCharacter = isPrefab ? Instantiate(character) : character;
            CurrentCharacter.transform.SetParent(transform);
            CurrentCharacter.transform.localPosition = Vector2.zero;
            CurrentCharacter.transform.localRotation = Quaternion.identity;

            CurrentAnimator = CurrentCharacter.Animator;

            UpdateAnimatorController(CurrentController);
        }

        public virtual void UpdateAnimatorController(RuntimeAnimatorController controller)
        {
            if (controller == null)
                CurrentController = defaultController;
            else
                CurrentController = controller;

            CurrentAnimator.runtimeAnimatorController = CurrentController;
            CurrentAnimator.Controller = CurrentController;
            CurrentAnimator.PlayController();
        }
    }
}