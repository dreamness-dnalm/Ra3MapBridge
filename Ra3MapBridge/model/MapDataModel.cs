using System;
using System.Collections.Generic;
using System.IO;
using MapCoreLib.core;
using MapCoreLib.Core;
using MapCoreLib.Core.Asset;

namespace MapCoreLib.model
{
    public class MapDataModel
    {
        public int MapWidth { get; private set; }
        
        public int MapHeight { get; private set; }
        
        public int BorderWidth { get; private set; }
        
        public int PlayableWidth { get; private set; }
        
        public int PlayableHeight { get; private set; }

        public int Area { get; private set; }
        // 2D array of map height data
        public float[,] HeightData { get; set; }
        
        public List<HeightMapBorder> Borders { get; private set; }
        
        public void Reload(string mapDirPath)
        {
            var ra3Map = MapHelper.OpenRa3Map(mapDirPath);
            var heightMapData = ra3Map.getAsset<HeightMapData>(Ra3MapConst.ASSET_HeightMapData);
            MapWidth = heightMapData.mapWidth;
            MapHeight = heightMapData.mapHeight;
            BorderWidth = heightMapData.borderWidth;
            PlayableWidth = heightMapData.playableWidth;
            PlayableHeight = heightMapData.playableHeight;
            Area = heightMapData.area;

            HeightData = new float[heightMapData.elevations.GetLength(0), heightMapData.elevations.GetLength(1)];
            Array.Copy(heightMapData.elevations, HeightData, heightMapData.elevations.Length);
            
            Borders = new List<HeightMapBorder>();
            foreach (var border in heightMapData.borders)
            {
                Borders.Add(new HeightMapBorder()
                {
                    Corner1X = border.Corner1X,
                    Corner1Y = border.Corner1Y,
                    Corner2X = border.Corner2X,
                    Corner2Y = border.Corner2Y
                });
            }
        }
        
        public void SaveHeightMapData(string mapDirPath)
        {
            var ra3Map = MapHelper.OpenRa3Map(mapDirPath);
            var heightMapData = ra3Map.getAsset<HeightMapData>(Ra3MapConst.ASSET_HeightMapData);

            heightMapData.elevations = HeightData;
            MapHelper.SaveRa3Map(ra3Map, mapDirPath);
        }
    }
}