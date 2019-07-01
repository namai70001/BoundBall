using UnityEngine;

namespace Framework.Singleton
{
    public class SceneSingleton<T> : MonoBehaviour where T : new()
    {
        private static T instance;
        public T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();

                return instance;
            }
        }
    }
}
