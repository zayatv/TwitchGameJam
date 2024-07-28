using System.Collections.Generic;

namespace Stats
{
    public class Stat
    {
        public List<StatModifier> Modifiers;

        private float baseValue;

        public Stat(float baseValue)
        {
            SetDefaultValue(baseValue);
            Modifiers = new List<StatModifier>();
        }

        public float GetValue()
        {
            float finalValue = baseValue;

            finalValue += GetFlatModifiersValue();

            finalValue *= GetPercentageModifiersValue() / 100 + 1;

            return finalValue;
        }

        public void SetDefaultValue(float value)
        {
            baseValue = value;
        }

        public void AddModifier(StatModifier modifier)
        {
            Modifiers.Add(modifier);
        }

        public void RemoveModifier(StatModifier modifier)
        {
            Modifiers.Remove(modifier);
        }

        protected float GetFlatModifiersValue()
        {
            float modValue = 0;

            foreach (StatModifier modifier in Modifiers)
            {
                if (modifier.ModifierType == ModifierType.Percentage) continue;
                modValue += modifier.ModifierValue;
            }

            return modValue;
        }

        protected float GetPercentageModifiersValue()
        {
            float modValue = 0;

            foreach (StatModifier modifier in Modifiers)
            {
                if (modifier.ModifierType == ModifierType.Flat) continue;
                modValue += modifier.ModifierValue;
            }

            return modValue;
        }
    }
}