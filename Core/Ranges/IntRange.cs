using System;

namespace UnityEngine
{
    [Serializable]
    public class IntRange
    {
        public int MinLimit;
        public int MaxLimit;

        public int LowerValue;
        public int UpperValue;

        public bool Contains(int value, bool include = true)
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

        public float Clamp(float value)
        {
            return Mathf.Clamp(value, LowerValue, UpperValue);
        }
    }
}