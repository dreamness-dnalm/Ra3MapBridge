using MapCoreLibMod.Core.Util;
using Ra3MapBridge;
using Ra3MapBridge.model;

namespace TestProject1;

public class PlayerTest
{
    [Test]
    public void Debug()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        foreach (PlayerModel p in map.GetPlayers())
        {
            Console.WriteLine(p);   
        }
    }
}