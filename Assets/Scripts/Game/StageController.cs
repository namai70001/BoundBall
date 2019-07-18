﻿using UnityEngine;
using Framework.Singleton;
using System.Collections.Generic;
using Framework.ObjectPool;

namespace Game.StageManager
{
    public class StageController : SceneSingleton<StageController>
    {
        [SerializeField]
        public string[] pathList;

        [SerializeField]
        private List<string> objectPathList = new List<string>();
        public List<string> ObjectPathList { get { return objectPathList; } }

        private const float StageWidth = -2.25f;
        private const float StageHeight = 10;

        [SerializeField]
        private Stage Stage1;

        [SerializeField]
        private Stage Stage2;

        private Random random = new Random();

        private void Start()
        {
            Stage1.CreateStage(pathList[0]);
            Stage2.CreateStage(pathList[1]);
        }

        public void NextStage()
        {
            Stage newStage;
            if (Stage1.gameObject.transform.position.y < Stage2.gameObject.transform.position.y)
            {
                newStage = Stage1;
            }
            else
            {
                newStage = Stage2;
            }

            newStage.transform.position += new Vector3(0, StageHeight * 2, 0);
            foreach(Transform chiletransform in newStage.transform)
            {
                ObjectPoolManager.Instance.DeleteObject(chiletransform.gameObject);
            }
            newStage.CreateStage(pathList[Random.Range(0,objectPathList.Count-1)]);
        }
    }
}
