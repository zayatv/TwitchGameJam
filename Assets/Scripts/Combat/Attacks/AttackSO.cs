using Sirenix.OdinInspector;
using UnityEngine;

namespace Combat.Attacks
{
    [CreateAssetMenu(fileName = "AttackSO", menuName = "Combat/AttackSO")]
    public class AttackSO : ScriptableObject
    {
        public string AttackName;
        [TextArea] public string Description;
        public AttackBehavior Behavior;
        public bool changeAnimator = true;
        [ShowIf(nameof(changeAnimator))]
        public RuntimeAnimatorController animatorController;
    }
}