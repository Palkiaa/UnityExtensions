namespace UnityEngine
{
    public static class ColorExtensions
    {
        #region Set

        public static Color SetR(this Color color, float red)
        {
            return new Color(red, color.g, color.b, color.a);
        }

        public static Color SetG(this Color color, float green)
        {
            return new Color(color.r, green, color.b, color.a);
        }

        public static Color SetB(this Color color, float blue)
        {
            return new Color(color.r, color.g, blue, color.a);
        }

        public static Color SetA(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        #endregion Set
    }
}