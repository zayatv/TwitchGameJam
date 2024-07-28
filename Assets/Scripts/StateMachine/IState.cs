using UnityEngine;

namespace Gameplay.StateMachine
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void HandleInput();
        public void Update();
        public void PhysicsUpdate();
        public void OnAnimationEnterEvent();
        public void OnAnimationExitEvent();
        public void OnAnimationTransitionEvent();
        public void OnTriggerEnter(Collider2D collider);
        public void OnTriggerExit(Collider2D collider);
    }
}