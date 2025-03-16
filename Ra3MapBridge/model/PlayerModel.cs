using MapCoreLib.Core.Asset;

namespace Ra3MapBridge.model;

public class PlayerModel
{
    private Player _player;
    
    public PlayerModel(Player player)
    {
        _player = player;
    }
    
    public string player_name
    {
        get => _player.assetPropertyCollection.getProperty("playerName").data.ToString();
    }

    // public bool is_human
    // {
    //     get => (bool)_player.assetPropertyCollection.getProperty("isHuman").data;
    // }
    
    public override string ToString()
    {
        return "PlayerModel{" +
               "player_name='" + player_name + '\'' +
               '}';
    }
}