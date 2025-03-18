using MapCoreLibMod.Core.Util;
using Ra3MapBridge;

namespace TestProject1;

public class TileTest
{
    [Test]
    public void ListTiles()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        // for (int x = 0; x < 100; x++)
        // {
        //     for (int y = 0; y < 200; y++)
        //     {
        //         map.SetTileTexture(x, y, "Sand_Cannes08");
        //         
        //         Console.WriteLine(map.GetTileTexture(x, y));
        //     }
        // }
        
        for(int x = 100; x < 220; x++)
        {
            for(int y = 100; y < 220; y++)
            {
                map.SetTileTexture(x, y, "Sand_Hawaii03");
                
                Console.WriteLine(map.GetTileTexture(x, y));
            }
        }
        
        map.Save();
    }
}