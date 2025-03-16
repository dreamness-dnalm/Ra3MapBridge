using MapCoreLib.Core;
using MapCoreLib.Core.Asset;

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

    private int MapPlayableWidth
    {
        get => _heightMapData.playableWidth;
    }

    private int MapPlayableHeight
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
    
    public float SetHeight(int x, int y, float height)
    {
        return HeightData[x, y] = height;
    }
    
    public float GetHeight(int x, int y)
    {
        return HeightData[x, y];
    }

    // ---- init ----
    
    private void LoadHeightMapData()
    {
        _heightMapData= ra3Map.getContext().getAsset<HeightMapData>(Ra3MapConst.ASSET_HeightMapData);
    }
}