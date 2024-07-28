using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //StartAnimation("Idle");

            player.ResetVelocity();
        }

        public override void Exit()
        {
            base.Exit();

            //StopAnimation("Idle");
        }

        public override void Update()
        {
            base.Update();

            if (movementInput == Vector2.zero) return;

            stateMachine.ChangeState(stateMachine.MoveState);
        }
    }
}