using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Util;
using Ra3MapBridge;
using Ra3MapBridge.model;

namespace TestProject1;

public class IOTest
{
    [Test]
    public void NewMap1()
    {
        var map = Ra3MapWrap.NewMap(PathUtil.RA3MapFolder, "test_1", 200, 300, 20, 2, "Transition_Yucatan01");
        
        map.Save();
    }
    
    [Test]
    public void NewMap2()
    {
        var map = Ra3MapWrap.NewMap(PathUtil.RA3MapFolder, "test_4", 300, 400, 20, 6);
        
        map.Save();
    }

    [Test]
    public void DebugMap()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");
        
        Console.WriteLine(map);
        
        // map.AddWaypoint("Player_4_Start", 150, 100, 0);

        foreach (WaypointModel waypointModel in map.GetWaypoints())
        {
            Console.WriteLine(waypointModel);
        }
        // map.Save();
    }
}