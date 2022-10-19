namespace UnityEngine
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        public Object Target;

        private void Awake()
        {
            DontDestroyOnLoad(Target != null ? Target : gameObject);
        }
    }
}