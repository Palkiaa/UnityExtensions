namespace UnityEngine
{
    public static class ScreenExtensions
    {
        public static Vector3 ScreenSize => new Vector3(Screen.width, Screen.height, 0);

        public static Vector3 ScreenMiddle => ScreenSize * 0.5f;

        public static Ray CentreRaycast(this Camera camera)
        {
            return camera.ScreenPointToRay(ScreenMiddle);
        }
    }
}