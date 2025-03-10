using System;
using System.IO;
using MapCoreLib.Core;
using MapCoreLib.Core.Asset;
using MapCoreLib.Core.Util;

namespace MapCoreLib.core
{
    public static class MapHelper
    {
        
        public static Ra3Map OpenRa3Map(string mapDirPath)
        {
            var mapName = Path.GetFileName(mapDirPath);
            var ra3Map = new Ra3Map(Path.Combine(mapDirPath, mapName + ".map"));
            ra3Map.parse();
            return ra3Map;
        }
        
        public static void SaveRa3Map(Ra3Map ra3Map, string mapName, string outputDir)
        {
            ra3Map.save(outputDir, mapName);
        }
        

        public static void SaveRa3Map(Ra3Map ra3Map)
        {
            var mapPath = ra3Map.mapPath;
            var mapName = Path.GetFileNameWithoutExtension(mapPath);
            var outputDir = Path.GetDirectoryName(Path.GetDirectoryName(mapPath));
            SaveRa3Map(ra3Map, mapName, outputDir);
        }

        public static void SaveRa3Map(Ra3Map ra3Map, string mapDirPath)
        {
            var mapName = Path.GetFileName(mapDirPath);
            var outputDir = Path.GetDirectoryName(mapDirPath);
            SaveRa3Map(ra3Map, mapName, outputDir);
        }

        public static String GetRa3MapPath()
        {
            return PathUtil.RA3MapFolder;
        }
        
        public static String GetRa3MapPathFromMapDirPath(string mapDirPath)
        {
            var mapName = Path.GetFileName(mapDirPath);
            return Path.Combine(mapDirPath, mapName + ".map");
        } 
        

        
        // public static void a()
        // {
        //     
        //
        //
        //     var ra3Map = OpenRa3Map("C:\\Users\\mmmmm\\AppData\\Roaming\\Red Alert 3\\Maps\\test_tga9");
        //
        //     var heightMapData = ra3Map.getAsset<HeightMapData>(Ra3MapConst.ASSET_HeightMapData);
        //     
        //     
        // }
        
        
    }
}