namespace Gameplay.Player
{
    using StateMachine;

    public class PlayerStateMachine : StateMachine
    {
        public Player Player { get; }

        public PlayerIdleState IdleState { get; }
        public PlayerMoveState MoveState { get; }
        public PlayerDashState DashState { get; }

        public PlayerStateMachine(Player player)
        {
            Player = player;

            IdleState = new PlayerIdleState(this);
            MoveState = new PlayerMoveState(this);
            DashState = new PlayerDashState(this);
        }
    }
}