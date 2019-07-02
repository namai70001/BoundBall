using Framework.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.ObjectPool
{
    public class ObjectPoolManager : SceneSingleton<ObjectPoolManager>
    {
        private Dictionary<string,List<GameObject>> poolObjDictionary = new Dictionary<string, List<GameObject>>();

        public void CreatePool(string path, int maxCount = 1)
        {
            List<GameObject> poolObjList = new List<GameObject>();
            poolObjDictionary.Add(path, poolObjList);

            for (int i = 0; i < maxCount; i++)
            {
                GameObject newObj = CreateNewObject(path);
            }
        }

        public GameObject GetObject(string path ,int count = 1)
        {
            if(!poolObjDictionary.ContainsKey(path))
            {
                CreatePool(path, count);
            }

            foreach(GameObject obj in poolObjDictionary[path])
            {
                if(obj.activeSelf == false)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            GameObject newObj = CreateNewObject(path);

            poolObjDictionary[path].Add(newObj);
            newObj.SetActive(true);

            return newObj;
        }

        public void DeleteObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.parent = transform;
        }

        private GameObject CreateNewObject(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject poolObj = Instantiate(prefab,transform);
            poolObj.name = prefab.name + (poolObjDictionary[path].Count + 1);
            poolObj.SetActive(false);

            return poolObj;
        }
    }
}