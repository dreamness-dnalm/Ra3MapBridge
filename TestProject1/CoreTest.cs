using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Util;

namespace TestProject1;

public class CoreTest
{
    [Test]
    public static void t01()
    {
        var ra3Map = new Ra3Map(Path.Combine(PathUtil.RA3MapFolder, "in_map_02", "in_map_02.map"));
        ra3Map.parse();
        ra3Map.save(PathUtil.RA3MapFolder, "out_map_12");
    }

    [Test]
    public static void t02()
    {
        var m = Ra3MapBridge.Ra3MapWrap.Open(PathUtil.RA3MapFolder, "NewMap01");

        foreach (var o in m.GetObjects())
        {
            Console.WriteLine(o.ToString());
        }

        // for (int x = 0; x < m.MapWidth; x++)
        // {
        //     for (int y = 0; y < m.MapHeight; y++)
        //     {
        //         if (m.GetTerrainHeight(x, y) < 210)
        //         {
        //             m.SetTerrainHeight(x, y, 210);
        //         }
        //     }
        // }
        //
        // m.SaveAs(PathUtil.RA3MapFolder, "out_map_15");
    }
}