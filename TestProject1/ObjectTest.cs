using MapCoreLibMod.Core.Util;
using Ra3MapBridge;

namespace TestProject1;

public class ObjectTest
{
    [Test]
    public void AddObject()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        var objectModel = map.AddObject("SovietMCV", 1000, 1000);
        objectModel.belong_to_team_full_name = "Player_1";
        objectModel.experience_level = 3;
        objectModel.angle = 40;
        objectModel.initial_health = 120;
        objectModel.enabled = false;
        objectModel.indestructible = true;
        objectModel.powered = false;
        objectModel.recruitable_ai = false;
        objectModel.sleeping = false;
        objectModel.stance = "HOLD_FIRE";
        objectModel.object_name = "unit1";
        objectModel.targetable = false;
        objectModel.unsellable = true;

        map.Save();
    }

    [Test]
    public void EditObject()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");
        
        map.GetObjects().Where(o => o.type_name == "SovietMCV").ToList()[0].belong_to_team_full_name = "Player_1/teamPlayer_1";
        
        
        map.Save();
    }

    [Test]
    public void RemoveObject()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        var uniqueIDList = map.GetObjects().Where(o => o.type_name == "SovietMCV").Select(o => o.unique_id).ToList();
        
        foreach (var uniqueID in uniqueIDList)
        {
            map.RemoveObjectOrWaypoint(uniqueID);
        }


        map.Save();
    }


    [Test]
    public void Debug()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        foreach (var o in map.GetObjects())
        {
            Console.WriteLine(o);   
        }
    }
}