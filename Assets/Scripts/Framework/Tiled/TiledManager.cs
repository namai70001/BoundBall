﻿using System;
using UnityEngine;
using Framework.Singleton;

namespace Framework.Tiled
{
    [Serializable]
    public sealed class TiledLayerData
    {
        [SerializeField] private int[] data = null;
        [SerializeField] private int height = 0;
        [SerializeField] private string name = string.Empty;
        [SerializeField] private int opacity = 0;
        [SerializeField] private string type = string.Empty;
        [SerializeField] private bool visible = false;
        [SerializeField] private int width = 0;
        [SerializeField] private int x = 0;
        [SerializeField] private int y = 0;

        public int[] Data { get { return data; } }
        public int Height { get { return height; } }
        public string Name { get { return name; } }
        public int Opacity { get { return opacity; } }
        public string Type { get { return type; } }
        public bool Visible { get { return visible; } }
        public int Width { get { return width; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }

    }

    [Serializable]
    public sealed class TiledSetsData
    {
        [SerializeField] private int firstgid = 0;
        [SerializeField] private string source = string.Empty;

        public int FirstGId { get { return firstgid; } }
        public string Source { get { return source; } }
    }

    public sealed class TiledData
    {
        [SerializeField] private int height = 0;
        [SerializeField] private bool infinite = false;
        [SerializeField] private TiledLayerData[] layers = null;
        [SerializeField] private int nextobjectid = 0;
        [SerializeField] private string orientation = string.Empty;
        [SerializeField] private string renderorder = string.Empty;
        [SerializeField] private string tiledversion = string.Empty;
        [SerializeField] private int tileheight = 0;
        [SerializeField] private TiledSetsData[] tilesets = null;
        [SerializeField] private int tilewidth = 0;
        [SerializeField] private string type = string.Empty;
        [SerializeField] private int version = 0;
        [SerializeField] private int width = 0;

        public int Height { get { return height; } }
        public bool Infinite { get { return infinite; } }
        public TiledLayerData[] Layers { get { return layers; } }
        public int NextObjectId { get { return nextobjectid; } }
        public string Orientation { get { return orientation; } }
        public string RenderOrder { get { return renderorder; } }
        public string TiledVersion { get { return tiledversion; } }
        public int TileHeight { get { return tileheight; } }
        public TiledSetsData[] Tilesets { get { return tilesets; } }
        public int TileWidth { get { return tilewidth; } }
        public string Type { get { return type; } }
        public int Version { get { return version; } }
        public int Width { get { return width; } }
    }

    public class TiledManager : Singleton<TiledManager>
    {
        public TiledData LoadTiledJsonData(string path)
        {
            TextAsset json = Resources.Load<TextAsset>(path);
            return JsonUtility.FromJson<TiledData>(json.text);
        }
    }
}