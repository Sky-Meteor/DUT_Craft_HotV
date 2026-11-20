using UnityEngine;

namespace Core
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<T>();
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
                _instance = (T)this;
            else
                Destroy(gameObject);
            
            SafeAwake();
        }
        
        protected virtual void SafeAwake()
        {
            
        }
    }
}