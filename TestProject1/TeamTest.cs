using MapCoreLibMod.Core.Util;
using Ra3MapBridge;
using Ra3MapBridge.model;

namespace TestProject1;

public class TeamTest
{
    [Test]
    public void Debug()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test15");

        foreach (TeamModel t in map.GetTeams())
        {
            if (t.team_full_name == "Player_1/t1" || t.team_full_name == "Player_1/t2" || t.team_full_name == "Player_1/t3")
            {
                Console.WriteLine("");
            }
            Console.WriteLine(t);
        }
    }
    
    [Test]
    public void AddTeam()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");

        var teamModel = map.AddTeam("team1", "Player_1");
        Console.WriteLine(teamModel);
        
        map.Save();
    }
    
    [Test]
    public void RemoveTeam()
    {
        var map = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "test_4");
        map.RemoveTeam("t2", "Player_1");
        
        map.Save();
    }
}