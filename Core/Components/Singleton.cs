namespace UnityEngine
{
    //https://bitbucket.org/EngiGamesBitbucket/howtomakethatgame/src/master/Canvas%20Manager/Singleton.cs
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        private static bool m_applicationIsQuitting = false;

        public static T Instance
        {
            get
            {
                if (m_applicationIsQuitting) { return null; }

                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject()
                        {
                            name = typeof(T).Name
                        };
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        ///<summary>
        ///When overriding this, be sure to call the base implementation of this method --> base.Awake();
        ///IMPORTANT!!! To use Awake in a derived class you need to do it this way
        ///protected override void Awake()
        ///{
        ///    base.Awake();
        ///    //Your code goes here
        ///}
        ///</summary>
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                //DontDestroyOnLoad(gameObject);
            }
            else if (instance != this as T)
            {
                Destroy(gameObject);
            }
            else
            {
                //DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        private void OnApplicationQuit()
        {
            m_applicationIsQuitting = true;
        }
    }
}