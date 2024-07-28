using Gameplay.StateMachine;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
    public class PlayerState : IState
    {
        protected PlayerStateMachine stateMachine;
        protected Player player;

        protected Vector2 movementInput;

        public PlayerState(PlayerStateMachine playerStateMachine)
        {
            stateMachine = playerStateMachine;
            player = playerStateMachine.Player;
        }

        public virtual void Enter()
        {
            AddInputActionsCallbacks();
        }

        public virtual void Exit()
        {
            RemoveInputActionsCallbacks();
        }

        public virtual void HandleInput()
        {
            ReadMovementInput();
        }

        public virtual void Update()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void OnAnimationEnterEvent()
        {
        }

        public virtual void OnAnimationTransitionEvent()
        {
        }

        public virtual void OnAnimationExitEvent()
        {
        }

        public virtual void OnTriggerEnter(Collider2D collider)
        {
        }

        public virtual void OnTriggerExit(Collider2D collider)
        {
        }

        protected virtual void ReadMovementInput()
        {
            movementInput = player.PlayerInput.PlayerActions.Move.ReadValue<Vector2>();

            if (movementInput != Vector2.zero)
                player.SetFacingDirection(movementInput.x, movementInput.y);
        }

        protected virtual void Move()
        {
            player.SetVelocity(player.FacingDir.x * player.Stats.Speed.GetValue(), player.FacingDir.y * player.Stats.Speed.GetValue());
        }

        protected void StartAnimation(string name)
        {
            player.CurrentAnimator.SetBool(name, true);
        }

        protected void StopAnimation(string name)
        {
            player.CurrentAnimator.SetBool(name, false);
        }

        protected virtual void AddInputActionsCallbacks()
        {
            player.PlayerInput.PlayerActions.Move.performed += OnMovePerformed;
            player.PlayerInput.PlayerActions.Move.canceled += OnMoveCanceled;

            player.PlayerInput.PlayerActions.Dash.started += OnDashStarted;
        }

        protected virtual void RemoveInputActionsCallbacks()
        {
            player.PlayerInput.PlayerActions.Move.performed -= OnMovePerformed;
            player.PlayerInput.PlayerActions.Move.canceled -= OnMoveCanceled;

            player.PlayerInput.PlayerActions.Dash.started -= OnDashStarted;
        }

        protected virtual void OnMoveCanceled(InputAction.CallbackContext context)
        {
        }

        protected virtual void OnMovePerformed(InputAction.CallbackContext context)
        {
        }

        protected virtual void OnDashStarted(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.DashState);
        }
    }
}