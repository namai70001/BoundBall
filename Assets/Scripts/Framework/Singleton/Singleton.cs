﻿using UnityEngine;

namespace Framework.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}
