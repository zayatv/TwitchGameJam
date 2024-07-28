using Input;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : Actor
    {
        [Header("Dash info")]
        [SerializeField] public float DashTime = 0.2f;
        [SerializeField] public float DefaultDashSpeedAdd = 15f;

        public PlayerStateMachine StateMachine { get; private set; }

        [HideInInspector] public PlayerInput PlayerInput;

        protected override void Awake()
        {
            base.Awake();

            PlayerInput = GetComponent<PlayerInput>();

            StateMachine = new PlayerStateMachine(this);
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            StateMachine.ChangeState(StateMachine.IdleState);
        }

        private void Update()
        {
            StateMachine.HandleInput();
            StateMachine.Update();
        }

        private void FixedUpdate()
        {
            StateMachine.PhysicsUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            StateMachine.OnTriggerEnter(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            StateMachine.OnTriggerExit(collision);
        }

        public void OnMovementStateAnimationEnterEvent()
        {
            StateMachine.OnAnimationEnterEvent();
        }

        public void OnMovementStateAnimationTransitionEvent()
        {
            StateMachine.OnAnimationTransitionEvent();
        }

        public void OnMovementStateAnimationExitEvent()
        {
            StateMachine.OnAnimationExitEvent();
        }

        public void SetFacingDirection(float x, float y)
        {
            FacingDir = new Vector2(x, y);
        }

        public override void FlipController(float x)
        {
            base.FlipController(x);

            if (x == 0 && !facingRight)
                Flip();
        }
    }
}