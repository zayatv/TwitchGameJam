using Combat.Attacks;
using Gameplay;
using UnityEngine;

namespace Combat
{
    public class AttackHolder : MonoBehaviour
    {
        [field: SerializeField] public AttackSO PrimaryAttack { get; private set; }

        private Actor actor;

        public AttackSO CurrentAttack { get; private set; }
        public AttackBehavior CurrentAttackBehavior { get; private set; }

        [field: SerializeField] public AttackSO SecondaryAttack { get; private set; }

        private void Start()
        {
            actor = GetComponent<Actor>();

            if (PrimaryAttack != null)
                EquipAttack(PrimaryAttack);
        }

        public void EquipAttack(AttackSO attack)
        {
            if (CurrentAttack != null)
                UnequipCurrentAttack();

            CurrentAttack = attack;

            CurrentAttackBehavior = Instantiate(attack.Behavior, actor.CurrentCharacter.AttackHolder);

            if (CurrentAttack.changeAnimator)
            {
                if (CurrentAttack.animatorController != actor.CurrentController)
                {
                    actor.UpdateAnimatorController(CurrentAttack.animatorController);
                }
            }

            CurrentAttackBehavior.OnEquip();
        }

        public void UnequipCurrentAttack()
        {
            if (CurrentAttack == null)
                return;

            if (CurrentAttack.changeAnimator)
                actor.UpdateAnimatorController(null);

            CurrentAttack = null;
            Destroy(CurrentAttackBehavior.gameObject);
        }
    }
}