using MapCoreLib.Core.Util;
using Ra3MapBridge;

namespace TestProject1;

public class WaypointTest
{
    [Test]
    public void DeleteWaypoint()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");
        
        map.RemoveWaypoint("Player_6_Start");
        
        map.Save();
    }

    [Test]
    public void AddWaypoint()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        map.AddWaypoint("test_waypoint", 1500, 1800);
        
        map.Save();
    }
    
    [Test]
    public void RenameWaypoint()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        map.GetWaypoint("test_waypoint").waypoint_name = "Player_6_Start";
        
        map.Save();
    }
    
    [Test]
    public void MoveWaypoint()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        var waypointModel = map.GetWaypoint("Player_6_Start");
        waypointModel.x = 2000;
        waypointModel.y = 20;

        map.Save();
    }
}