using MapCoreLib.Core.Util;
using Ra3MapBridge;

namespace TestProject1;

public class HeightTest
{
    [Test]
    public void Debug()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        Console.WriteLine("width: " + map.MapWidth);
        Console.WriteLine("height: " + map.MapHeight);
        Console.WriteLine("playable width: " + map.MapPlayableWidth);
        Console.WriteLine("playable height: " + map.MapPlayableHeight);
        Console.WriteLine("border width: " + map.MapBorderWidth);
    }

    [Test]
    public void SetHeight()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");
        for(int x = 100; x < 200; x++)
        {
            for(int y = 100; y < 200; y++)
            {
                map.SetTerrainHeight(x, y, 300);
                Console.WriteLine("height: " + map.GetTerrainHeight(x, y));
            }
        }
        map.UpdatePassabilityMap();
        map.Save();
    }
}