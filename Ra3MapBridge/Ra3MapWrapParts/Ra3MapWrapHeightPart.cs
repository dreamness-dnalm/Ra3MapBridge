using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Asset;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{

    private HeightMapData _heightMapData;
    
    // ---------  basic map info  ---------

    public int MapWidth
    {
        get => _heightMapData.mapWidth;
    }

    public int MapHeight
    {
        get => _heightMapData.mapHeight;
    }

    public int MapBorderWidth
    {
        get => _heightMapData.borderWidth;
    }

    public int MapPlayableWidth
    {
        get => _heightMapData.playableWidth;
    }

    public int MapPlayableHeight
    {
        get => _heightMapData.playableHeight;
    }

    private int Area
    {
        get => _heightMapData.area;
    }
    
    private float[,] HeightData
    {
        get => _heightMapData.elevations;
    }

    private List<HeightMapBorder> Borders
    {
        get => _heightMapData.borders;
    }
    
    // ----------- height --------------
    
    public float SetTerrainHeight(int x, int y, float height)
    {
        return HeightData[x, y] = height;
    }
    
    public float GetTerrainHeight(int x, int y)
    {
        return HeightData[x, y];
    }
    
    // -------- border --------------
    public List<HeightMapBorder> GetBorders()
    {
        return Borders;
    }
    
    public void SetBorder(HeightMapBorder border, int x1, int y1, int x2, int y2)
    {
        border.Corner1X = x1;
        border.Corner1Y = y1;
        border.Corner2X = x2;
        border.Corner2Y = y2;
    }
    
    public void AddBorder(int x1, int y1, int x2, int y2)
    {
        var b = HeightMapBorder.newInstance(x1, y1, x2, y2);
        Borders.Add(b);
    }

    public void RemoveBorder(HeightMapBorder border)
    {
        Borders.Remove(border);
    }

    // ---- init ----
    
    private void LoadHeightMapData()
    {
        _heightMapData= ra3Map.getContext().getAsset<HeightMapData>(Ra3MapConst.ASSET_HeightMapData);
    }
}