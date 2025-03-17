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
}