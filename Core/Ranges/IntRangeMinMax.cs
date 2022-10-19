using System;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class IntRangeMinMax : Attribute
    {
        public override object TypeId => base.TypeId;

        public IntRangeMinMax(int? minLimit, int? maxLimit)
        {
            MinLimit = minLimit;
            MaxLimit = maxLimit;
        }

        public IntRangeMinMax(int minLimit, int maxLimit)
        {
            MinLimit = minLimit;
            MaxLimit = maxLimit;
        }

        public int? MinLimit;
        public int? MaxLimit;

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