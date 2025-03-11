using System.Xml.Linq;
using MapCoreLib.Core;
using MapCoreLib.Core.Asset;
using MapCoreLib.Util;

namespace Ra3MapBridge;

public class Ra3MapWrap
{
    private Ra3Map ra3Map;
    
    // ---------  basic map info  ---------
    
    public int Width { get; private set; }
    
    public int Height { get; private set; }
    
    private int BorderWidth { get; set; }
    
    private int PlayableWidth { get; set; }
    
    private int PlayableHeight { get; set; }
    
    private int Area { get; set; }
    
    private float[,] HeightData { get; set; }
    
    private List<HeightMapBorder> Borders { get; set; }
    
    // ----------- height --------------
    
    public float SetHeight(int x, int y, float height)
    {
        return HeightData[x, y] = height;
    }
    
    public float GetHeight(int x, int y)
    {
        return HeightData[x, y];
    }
    
    // ----------- texture ------------------
    
    private BlendTileData blendTileData { get; set; }
    
    private Dictionary<string, int> textureIndexDict = new Dictionary<string, int>();
    
    public void SetTileTexture(int x, int y, string texture)
    {
        if (!textureIndexDict.ContainsKey(texture))
        {
            blendTileData.addTexture(ra3Map.getContext(), texture);
            textureIndexDict.Add(texture, blendTileData.textures.Count - 1);
        }
        blendTileData.tiles[x, y] = blendTileData.GetTile(x, y, textureIndexDict[texture]);
    }
    
    public string GetTileTexture(int x, int y)
    {
        return blendTileData.textures[blendTileData.tiles[x, y]].name;
    }
    
    // ---------- passability ----------------
    
    public void SetPassability(int x, int y, string passability)
    {
        blendTileData.passability[x, y] = Enum.Parse<Passability>(passability, true);
    }
    
    public string GetPassability(int x, int y)
    {
        return blendTileData.passability[x, y].ToString();
    }
    
    public void UpdatePassabilityMap()
    {
        blendTileData.UpdatePassabilityMap(ra3Map.getContext());
    }
    
    // ---------- objects ----------------
    private ObjectsList objectsList { get; set; }

    public List<MapObject> GetObjects()
    {
        return objectsList.mapObjects.Where(o => o.typeName != "*Waypoints/Waypoint").ToList();
    }

    public void AddObject(string typeName, float x, float y, float z, float angle, string objName = "")
    {
        objectsList.AddObject(ra3Map.getContext(), typeName, new Vec3D(x, y, z), angle, objName);
    }
    
    // --------- waypoint -----------
    
    public List<MapObject> GetWaypoints()
    {
        return objectsList.mapObjects.Where(o => o.typeName == "*Waypoints/Waypoint").ToList();
    }
    
    public void AddWaypoint(float x, float y, float z, string waypointName)
    {
        objectsList.AddWaypoint(ra3Map.getContext(), waypointName, new Vec3D(x, y, z));
    }
    
    private Ra3MapWrap(Ra3Map ra3Map)
    {
        this.ra3Map = ra3Map;

        var heightMapData = ra3Map.getAsset<HeightMapData>(Ra3MapConst.ASSET_HeightMapData);
        Width = heightMapData.mapWidth;
        Height = heightMapData.mapHeight;
        BorderWidth = heightMapData.borderWidth;
        PlayableWidth = heightMapData.playableWidth;
        PlayableHeight = heightMapData.playableHeight;
        Area = heightMapData.area;
        HeightData = heightMapData.elevations;
        Borders = heightMapData.borders;
        
        blendTileData = ra3Map.getAsset<BlendTileData>(Ra3MapConst.ASSET_BlendTileData);
        
        for(int i = 0; i < blendTileData.textures.Count; i++)
        {
            textureIndexDict.Add(blendTileData.textures[i].name, i);
        }
        
        objectsList = ra3Map.getAsset<ObjectsList>(Ra3MapConst.ASSET_ObjectsList);
    }

    public static Ra3MapWrap NewMap(string outputPath, string mapName, int width, int height, int border,
        string defaultTexture = "Dirt_Yucatan03")
    {
        var mapFilePath = Path.Combine(outputPath, mapName, mapName + ".map");
        
        var newMapConfig = new NewMapConfig()
        {
            mapPath = mapFilePath,
            width = width,
            height = height,
            border = border,
            defaultTexture = defaultTexture
        };
        return new Ra3MapWrap(Ra3Map.newMap(newMapConfig));
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