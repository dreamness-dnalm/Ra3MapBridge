using MapCoreLib.Core;

namespace MapCoreLibMod;

public class Class1
{
    public static void Main()
    {
        var mapDirPath = "C:\\Users\\mmmmm\\AppData\\Roaming\\Red Alert 3\\Maps\\官方地图_卡巴纳_CabanaRepublic";
        var mapName = Path.GetFileName(mapDirPath);
        var ra3Map = new Ra3Map(Path.Combine(mapDirPath, mapName + ".map"));
        ra3Map.parse();
    }
}