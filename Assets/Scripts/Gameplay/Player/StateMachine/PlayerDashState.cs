using Stats;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
    public class PlayerDashState : PlayerState
    {
        private float startTime;
        private StatModifier speedMod;

        public PlayerDashState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //StartAnimation("Dash");

            startTime = Time.time;

            speedMod = new StatModifier(ModifierType.Flat, player.DefaultDashSpeedAdd);

            player.Stats.Speed.AddModifier(speedMod);
        }

        public override void Exit()
        {
            base.Exit();

            //StopAnimation("Dash");

            player.Stats.Speed.RemoveModifier(speedMod);
        }

        public override void Update()
        {
            base.Update();

            if (startTime + player.DashTime > Time.time) return;

            if (movementInput != Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
                return;
            }

            stateMachine.ChangeState(stateMachine.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Move();
        }

        protected override void ReadMovementInput()
        {
        }

        protected override void OnDashStarted(InputAction.CallbackContext context)
        {
        }
    }
}