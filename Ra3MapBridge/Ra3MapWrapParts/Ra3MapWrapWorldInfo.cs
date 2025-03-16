using MapCoreLib.Core;
using MapCoreLib.Core.Asset;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{
    private WorldInfo _worldInfo;
    
    public float CameraGroundMinHeight
    {
        get => (float)_worldInfo.properties.getProperty("cameraGroundMinHeight").data;
        set => _worldInfo.properties.setProperty("cameraGroundMinHeight", value);
    }
    
    public float CameraGroundMaxHeight
    {
        get => (float)_worldInfo.properties.getProperty("cameraGroundMaxHeight").data;
        set => _worldInfo.properties.setProperty("cameraGroundMaxHeight", value);
    }

    public float CameraMinHeight
    {
        get => (float)_worldInfo.properties.getProperty("cameraMinHeight").data;
        set => _worldInfo.properties.setProperty("cameraMinHeight", value);
    }
    
    public float CameraMaxHeight
    {
        get => (float)_worldInfo.properties.getProperty("cameraMaxHeight").data;
        set => _worldInfo.properties.setProperty("cameraMaxHeight", value);
    }
    
    
    // ---- init ----
    private void LoadWorldInfo()
    {
        _worldInfo = ra3Map.getContext().getAsset<WorldInfo>(Ra3MapConst.ASSET_WorldInfo);
    }
}