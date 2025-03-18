using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Asset;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{
    // ----------- texture ------------------
    
    private BlendTileData _blendTileData { get; set; }
    
    private Dictionary<string, int> textureIndexDict = new Dictionary<string, int>();
    
    public void SetTileTexture(int x, int y, string texture)
    {
        if (!textureIndexDict.ContainsKey(texture))
        {
            _blendTileData.addTexture(ra3Map.getContext(), texture);
            textureIndexDict.Add(texture, _blendTileData.textures.Count - 1);
        }
        _blendTileData.tiles[x, y] = _blendTileData.GetTile(x, y, textureIndexDict[texture]);
    }
    
    public string GetTileTexture(int x, int y)
    {
        int tmp = y % 8 / 2 * 16 + y % 2 * 2 + x % 8 / 2 * 4 + x % 2;
        
        
        
        var index = _blendTileData.tiles[x, y];
        
        // result = 64 * textureIndex + index
        var textureIndex = (_blendTileData.tiles[x, y] - tmp) / 64;
        return _blendTileData.textures[textureIndex].name;
    }
    
    // ---------- passability ----------------
    
    public void SetPassability(int x, int y, string passability)
    {
        _blendTileData.passability[x, y] = Enum.Parse<Passability>(passability, true);
    }
    
    public string GetPassability(int x, int y)
    {
        return _blendTileData.passability[x, y].ToString();
    }
    
    public void UpdatePassabilityMap()
    {
        _blendTileData.UpdatePassabilityMap(ra3Map.getContext());
    }
    
    // ---- init ----
    private void LoadBlendTileData()
    {
        _blendTileData = ra3Map.getContext().getAsset<BlendTileData>(Ra3MapConst.ASSET_BlendTileData);
        
        for(int i = 0; i < _blendTileData.textures.Count; i++)
        {
            textureIndexDict.Add(_blendTileData.textures[i].name, i);
        }
    }
}