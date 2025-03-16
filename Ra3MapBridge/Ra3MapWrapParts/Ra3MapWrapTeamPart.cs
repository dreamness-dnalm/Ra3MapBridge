using MapCoreLib.Core;
using MapCoreLib.Core.Asset;
using Ra3MapBridge.model;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{
    private Teams _teams { get; set; }
    
    
    public List<TeamModel> GetTeams()
    {
        return _teams.teamList.Select(t => new TeamModel(t)).ToList();
    }
    
    public TeamModel AddTeam(string teamName, string belongToPlayerName)
    {
        var team = _teams.addTeam(ra3Map.getContext(), teamName, belongToPlayerName);
        return new TeamModel(team);
    }
    
    public bool RemoveTeam(string teamName)
    {
        return _teams.removeTeam(ra3Map.getContext(), teamName);
    }
    
    
    // ---- init ----
    
    private void LoadTeams()
    {
        _teams = ra3Map.getContext().getAsset<Teams>(Ra3MapConst.ASSET_Teams);
    }
}