using MapCoreLib.Core.Util;
using Ra3MapBridge;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {
        // var m = Ra3MapWrap.NewMap(PathUtil.RA3MapFolder, "test_py_2", 150, 200, 10);
        // var ra3map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_py_2");
        // Console.Write(ra3map.Height);
        // Console.Write(ra3map.Width);
        // Console.WriteLine(ra3map.GetPassability(20, 20));
        // m.Save();
    // var m = Ra3MapWrap.NewMap()
        // var m = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_py_1");
        // foreach (var mo in m.GetWaypoints())
        // {
        //     // Console.WriteLine(mo.assetPropertyCollection.propertyMap);
        //     // mo.typeName = "SovietAntiStructureVehicle";
        // }
        
        // m.AddWaypoint(150, 150, 0, "Player_3_Start");
        
        // var m = Ra3MapWrap.NewMap(PathUtil.RA3MapFolder, "test_py_4", 400, 500, 10);
        var m = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "py_6");

        // foreach (var w in m.GetWaypoints())
        // {
        //     Console.WriteLine(w);
        // }
        
        //
        foreach (var t in m.GetTeams())
        {
            
        }
        
        // m.Save();

        
    }
}