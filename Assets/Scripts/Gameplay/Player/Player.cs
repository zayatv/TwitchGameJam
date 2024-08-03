using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
    public class Player : Actor
    {
        [Header("Dash info")]
        [SerializeField] public float DashTime = 0.2f;
        [SerializeField] public float DefaultDashSpeedAdd = 15f;

        public PlayerStateMachine StateMachine { get; private set; }

        [HideInInspector] public Input.PlayerInput PlayerInput;

        protected override void Awake()
        {
            base.Awake();

            PlayerInput = GetComponent<Input.PlayerInput>();

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

            AimDirection = transform.position + GetMouseDirectionNormalized();
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

        private Vector3 GetMouseDirectionNormalized()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0f;

            return (mousePos - transform.position).normalized;
        }
    }
}