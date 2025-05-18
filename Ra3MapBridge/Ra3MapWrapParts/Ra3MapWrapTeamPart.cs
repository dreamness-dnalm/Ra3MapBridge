using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Asset;
using Ra3MapBridge.model;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{
    private Teams _teams { get; set; }
    
    
    public List<TeamModel> GetTeams()
    {
        return _teams.teamList.Select(t => new TeamModel(t, ra3Map.getContext())).ToList();
    }
    
    public TeamModel AddTeam(string teamName, string belongToPlayerName)
    {
        var team = _teams.addTeam(ra3Map.getContext(), teamName, belongToPlayerName);
        return new TeamModel(team, ra3Map.getContext());
    }
    
    public bool RemoveTeam(string teamName, string belongToPlayerName)
    {
        return _teams.removeTeam(ra3Map.getContext(), teamName, belongToPlayerName);
    }
    
    
    // ---- init ----
    
    private void LoadTeams()
    {
        _teams = ra3Map.getContext().getAsset<Teams>(Ra3MapConst.ASSET_Teams);
    }
}