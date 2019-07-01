using UnityEngine;

namespace Framework.Singleton
{
    public class SceneSingleton<T> : MonoBehaviour where T : MonoBehaviour, new()
    {
        private static T instance;
        public T Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).ToString());
                    instance = obj.AddComponent<T>();
                }                    

                return instance;
            }
        }
    }
}
