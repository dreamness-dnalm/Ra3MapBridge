using System.Xml.Linq;
using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Asset;
using MapCoreLibMod.Util;
using Ra3MapBridge.model;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{
    private Ra3Map ra3Map;
    
    private Ra3MapWrap(Ra3Map ra3Map)
    {
        this.ra3Map = ra3Map;
        this.ra3Map.parse();

        LoadHeightMapData();
        LoadBlendTileData();
        LoadObjectsList();
        LoadWorldInfo();
        // LoadPlayers();
        LoadTeams();
        
    }

    public static Ra3MapWrap NewMap(string outputPath, string mapName, int playableWidth, int playableHeight, int border,
        int initPlayerStartWaypointCnt = 2,
        string defaultTexture = "Dirt_Yucatan03")
    {
        
        var mapFilePath = Path.Combine(outputPath, mapName, mapName + ".map");

        if (File.Exists(mapFilePath))
        {
            throw new Exception("Map already exists");
        }
        
        var newMapConfig = new NewMapConfig()
        {
            mapPath = mapFilePath,
            width = playableWidth,
            height = playableHeight,
            border = border,
            defaultTexture = defaultTexture
        };
        var newMap = Ra3Map.newMap(newMapConfig);
        
        Random random = new Random();

        for (int i = 1; i <= initPlayerStartWaypointCnt; i++)
        {
            var objectsList = newMap.getContext().getAsset<ObjectsList>(Ra3MapConst.ASSET_ObjectsList);
           objectsList.AddPlayerStartWaypoint(newMap.getContext(), i, 
                new Vec3D(
                    random.NextDouble() * playableWidth * 10f,   
                    random.NextDouble() * playableHeight * 10f ,
                        0f));
           
        }
        
        newMap.save(newMap.mapPath);
        return Open(outputPath, mapName);
    }


    public static Ra3MapWrap Open(string parentPath, string mapName)
    {
        return new Ra3MapWrap(new Ra3Map(Path.Combine(parentPath, mapName, mapName + ".map")));
    }

    public void Save()
    {
        ra3Map.save(ra3Map.mapPath);
    }

    public void SaveAs(string outputPath, string mapName)
    {
        ra3Map.save(outputPath, mapName);
    }
}