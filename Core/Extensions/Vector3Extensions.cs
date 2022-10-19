using System.Collections.Generic;
using System.Linq;

namespace UnityEngine
{
    public static class Vector3Extensions
    {
        public static Vector3 Sum(this IEnumerable<Vector3> vectors)
        {
            Vector3 sum = Vector3.zero;
            foreach (var vector in vectors)
                sum += vector;
            return sum;
        }

        public static Vector3 Average(this IEnumerable<Vector3> vectors)
        {
            Vector3 average = vectors.Sum();
            average /= vectors.Count();
            return average;
        }
    }
}