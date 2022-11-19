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

        #region Set

        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        #endregion Set

        /// <summary>
        /// Rotates the vector.
        /// </summary>
        /// <returns>Returns the rotated vector.</returns>
        /// <param name="vector">Original vector.</param>
        /// <param name="offsetAngle">Angle to offset by in degrees.</param>
        public static Vector3 RotateVector(this Vector3 vector, Vector3 offsetAngle)
        {
            return Quaternion.Euler(offsetAngle) * vector;
        }

        public static Vector3 Divide(this Vector3 a, Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }

        public static Vector3 Multiply(this Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
    }
}