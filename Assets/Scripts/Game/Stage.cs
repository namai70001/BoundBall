using UnityEngine;
using Framework.Singleton;
using Framework.Tiled;
using System.Collections.Generic;
using Framework.ObjectPool;

namespace Game.StageManager 
{
    public class Stage : MonoBehaviour
    { 
        private const float stageDataWidth = 0.5f;
        private const float stageDataHeight = 0.5f;
        
        public void CreateStage(string path)
        {
            TiledData tiledData = TiledController.Instance.LoadTiledJsonData(path);

            TiledLayerData[] layerDataList = tiledData.Layers;

            foreach (TiledLayerData layer in layerDataList)
            {
                int Width = layer.Width;
                int Height = layer.Height;

                int x = 0;
                int y = 0;

                foreach (int data in layer.Data)
                {
                    if (StageController.Instance.ObjectPathList[data] != "")
                    {
                        GameObject obj = ObjectPoolManager.Instance.GetObject(StageController.Instance.ObjectPathList[data]);
                        obj.transform.parent = transform;
                        obj.transform.localPosition = new Vector3(x * 0.5f, y * 0.5f, 0);
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
    }
}
