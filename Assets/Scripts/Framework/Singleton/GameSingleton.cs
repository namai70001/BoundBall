using System;
using UnityEngine;

namespace Framework.Singleton
{
    public class GameSingleton<T> : MonoBehaviour where T : MonoBehaviour, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance != null) return instance;

                Type type = typeof(T);
                instance = (T)FindObjectOfType(type);

                if (instance != null) return instance;

                GameObject obj = new GameObject(type.Name);
                instance = obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
                return instance;
            }
        }
    }
}

