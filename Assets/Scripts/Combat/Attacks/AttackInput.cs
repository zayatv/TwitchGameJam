using Gameplay;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Combat.Attacks
{
    public class AttackInput : MonoBehaviour
    {
        private Input.PlayerInput playerInput;
        private AttackHolder attackHolder;

        private void Start()
        {
            playerInput = GetComponent<Input.PlayerInput>();
            attackHolder = GetComponent<AttackHolder>();

            playerInput.PlayerActions.Attack.performed += AttackInput_Performed;
            playerInput.PlayerActions.AttackSwap.performed += CycleAttacks;
        }

        private void OnDestroy()
        {
            playerInput.PlayerActions.Attack.performed -= AttackInput_Performed;
            playerInput.PlayerActions.AttackSwap.performed -= CycleAttacks;
        }

        private void AttackInput_Performed(InputAction.CallbackContext context)
        {
            attackHolder.CurrentAttackBehavior.AttackPerformed();
        }

        private void CycleAttacks(InputAction.CallbackContext context)
        {
            if (attackHolder.SecondaryAttack == null) return;

            AttackSO newAttack = attackHolder.CurrentAttack == attackHolder.PrimaryAttack ? attackHolder.SecondaryAttack : attackHolder.PrimaryAttack;

            attackHolder.EquipAttack(newAttack);
        }
    }
}