namespace Stats
{
    public class StatModifier
    {
        public ModifierType ModifierType { get; private set; }
        public float ModifierValue { get; private set; }

        public StatModifier(ModifierType modifierType, float modifierValue)
        {
            ModifierType = modifierType;
            ModifierValue = modifierValue;
        }

        public void AddToModValue(float valueToAdd)
        {
            ModifierValue += valueToAdd;
        }

        public void RemoveFromModValue(float valueToRemove)
        {
            ModifierValue -= valueToRemove;
        }
    }

    public enum ModifierType
    {
        Flat,
        Percentage
    }
}