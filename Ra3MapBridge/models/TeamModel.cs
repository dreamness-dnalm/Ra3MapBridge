using MapCoreLibMod.Core.Asset;

namespace Ra3MapBridge.model;

public class TeamModel
{
    private Team _team;
    
    public TeamModel(Team team)
    {
        _team = team;
    }
    
    public string team_name
    {
        get => _team.propertyCollection.getProperty("teamName").data.ToString();
        set => _team.propertyCollection.getProperty("teamName").data = value;
    }
    
    public string belong_to_player_name
    {
        get => _team.propertyCollection.getProperty("teamOwner").data.ToString();
        set => _team.propertyCollection.getProperty("teamOwner").data = value;
    }
    
    public string team_full_name
    {
        get => belong_to_player_name + "/" + team_name;
    }

    public override string ToString()
    {
        return "TeamModel{" +
               "team_name='" + team_name + '\'' +
               ", belong_to_player_name='" + belong_to_player_name + '\'' +
               '}';
    }
}