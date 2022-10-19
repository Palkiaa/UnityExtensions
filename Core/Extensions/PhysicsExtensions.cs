namespace UnityEngine
{
    public static class PhysicsExtensions
    {
        public static Vector3 CalculateForce(this Rigidbody rigidbody, Vector3 force, ForceMode forceMode)
        {
            return CalculateForce(force, rigidbody.mass, forceMode);
        }

        public static Vector3 CalculateForce(Vector3 force, float mass, ForceMode forceMode)
        {
            switch (forceMode)
            {
                case ForceMode.Force:
                    return force * mass * Time.fixedDeltaTime;

                case ForceMode.Acceleration:
                    return force * Time.fixedDeltaTime;

                case ForceMode.Impulse:
                    return force * mass;

                case ForceMode.VelocityChange:
                    return force;
            }
            return Vector3.zero;
        }
    }
}