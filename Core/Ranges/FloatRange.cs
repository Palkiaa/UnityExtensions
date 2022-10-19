using System;

namespace UnityEngine
{
    [Serializable]
    public class FloatRange
    {
        public float MinLimit;
        public float MaxLimit;

        public float LowerValue;
        public float UpperValue;

        public bool Contains(float value, bool include = true)
        {
            if (include)
            {
                return LowerValue <= value && value <= UpperValue;
            }
            else
            {
                return LowerValue < value && value < UpperValue;
            }
        }

        public bool Contains(float value, float padding, bool include = true)
        {
            if (include)
            {
                return LowerValue - padding <= value && value <= UpperValue + padding;
            }
            else
            {
                return LowerValue - padding < value && value < UpperValue + padding;
            }
        }

        public float Clamp(float value)
        {
            return Mathf.Clamp(value, LowerValue, UpperValue);
        }
    }
}