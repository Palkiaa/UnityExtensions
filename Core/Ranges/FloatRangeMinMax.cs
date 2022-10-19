using System;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class FloatRangeMinMax : Attribute
    {
        public override object TypeId => base.TypeId;

        public FloatRangeMinMax(float? minLimit, float? maxLimit)
        {
            MinLimit = minLimit;
            MaxLimit = maxLimit;
        }

        public FloatRangeMinMax(float minLimit, float maxLimit)
        {
            MinLimit = minLimit;
            MaxLimit = maxLimit;
        }

        public float? MinLimit;
        public float? MaxLimit;

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }
    }
}