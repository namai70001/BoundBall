﻿using UnityEngine;
using Framework.Singleton;
using Framework.Tiled;
using System.Collections.Generic;
using Framework.ObjectPool;
using Framework.RectangularList;

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

        [SerializeField]
        private List<ValueList<string>> objectPathRectangularList;

        [SerializeField]
        private Vector3 stageLeftUp;

        private int layerCnt;

        private void Start()
        {
            TiledData tiledData = TiledManager.Instance.LoadTiledJsonData(path);

            TiledLayerData[] layerDataList = tiledData.Layers;

            layerCnt = 0;
            foreach (TiledLayerData layer in layerDataList)
            {
                int Width = layer.Width;
                int Height = layer.Height;

                int x = 0;
                int y = 0;

                foreach (int data in layer.Data)
                {
                    if (objectPathRectangularList[layerCnt].List[data] != "")
                    {
                        GameObject obj = ObjectPoolManager.Instance.GetObject(objectPathRectangularList[layerCnt].List[data]);
                        obj.transform.position = stageLeftUp + new Vector3(x, y, 0);
                    }

                    x += 1;
                    if (x == Width)
                    {
                        y += 1;
                        x = 0;
                    }
                }

                layerCnt += 1;
            }
        }
    }
}
