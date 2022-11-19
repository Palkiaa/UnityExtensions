namespace UnityEngine
{
    public static class Vector2Extensions
    {
        #region Set

        public static Vector2 SetX(this Vector2 vector, float x)
        {
            return new Vector3(x, vector.y);
        }

        public static Vector2 SetY(this Vector2 vector, float y)
        {
            return new Vector3(vector.x, y);
        }

        #endregion Set

        public static Vector2 Divide(this Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static Vector2 Multiply(this Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
    }
}