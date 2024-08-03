using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Combat.Weapons
{
    public class WeaponInput : MonoBehaviour
    {
        private Actor actor;
        private Input.PlayerInput playerInput;
        private WeaponBehaviour weaponBehaviour;

        private void Start()
        {
            actor = GetComponentInParent<Actor>();
            weaponBehaviour = GetComponent<WeaponBehaviour>();
            playerInput = actor.GetComponent<Input.PlayerInput>();

            playerInput.PlayerActions.Attack.performed += AttackInput_Performed;
        }

        private void OnDestroy()
        {
            playerInput.PlayerActions.Attack.performed -= AttackInput_Performed;
        }

        private void AttackInput_Performed(InputAction.CallbackContext context)
        {
            weaponBehaviour.Attack_Performed();
        }
    }
}