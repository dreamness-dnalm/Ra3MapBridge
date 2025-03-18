using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Asset;
using Ra3MapBridge.model;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{
    private SidesList _sidesList { get; set; }

    private void LoadPlayers()
    {
        _sidesList = ra3Map.getContext().getAsset<SidesList>(Ra3MapConst.ASSET_SidesList);
    }

    public List<PlayerModel> GetPlayers()
    {
        return _sidesList.players.Select(p => new PlayerModel(p)).ToList();
    }
}