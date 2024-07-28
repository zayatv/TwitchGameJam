using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //StartAnimation("Move");
        }

        public override void Exit()
        {
            base.Exit();

            //StopAnimation("Move");
        }

        public override void Update()
        {
            base.Update();

            if (movementInput != Vector2.zero) return;

            stateMachine.ChangeState(stateMachine.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Move();
        }
    }
}