﻿using UnityEngine;
using Framework.Singleton;
using Framework.Tiled;
using System.Collections.Generic;
using Framework.ObjectPool;

namespace Game.StageManager
{
    public class StageData
    {
        private float width;
        private float height;

        public StageData(TiledLayerData layer, float width, float height)
        {
            this.width = width;
            this.height = height;
        }
    }

    public class StageController : SceneSingleton<StageController>
    {
        private string path = "Stage/001_Stage";
        private StageData stage;

        private const float stageDataWidth = 0.5f;
        private const float stageDataHeight = 0.5f;

        [SerializeField]
        private List<string> objectPathList = new List<string>();
        
        private Vector3 stageLeftUp;

        [SerializeField]
        private GameObject currentStage;

        [SerializeField]
        private GameObject nextStage;

        private void Start()
        {
            TiledData tiledData = TiledManager.Instance.LoadTiledJsonData(path);

            TiledLayerData[] layerDataList = tiledData.Layers;
            
            foreach (TiledLayerData layer in layerDataList)
            {
                int Width = layer.Width;
                int Height = layer.Height;

                int x = 0;
                int y = 0;

                foreach (int data in layer.Data)
                {
                    if (objectPathList[data] != "")
                    {
                        GameObject obj = ObjectPoolManager.Instance.GetObject(objectPathList[data]);
                        obj.transform.parent = currentStage.transform;
                        obj.transform.localPosition = stageLeftUp + new Vector3(x * 0.5f, y * 0.5f, 0);
                    }

                    x += 1;
                    if (x == Width)
                    {
                        y -= 1;
                        x = 0;
                    }
                }
            }
        }

        private void CreateStage()
        {
            nextStage = currentStage;


        }
    }
}
