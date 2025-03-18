using MapCoreLibMod.Core.Asset;

namespace Ra3MapBridge.model;

public class ObjectModel
{
    enum StanceEnum
    {
        GUARD = 0,
        AGGRESSIVE = 1,
        HOLD_POSITION = 2,
        HOLD_FIRE = 3
    }
    
    public MapObject _mapObject;
    
    public ObjectModel(MapObject mapObject)
    {
        _mapObject = mapObject;
    }
    
    public float angle
    {
        get => _mapObject.angle;
        set => _mapObject.angle = value;
    }
    
    public float x
    {
        get => _mapObject.position.x;
        set => _mapObject.position.x = value;
    }
    
    public float y
    {
        get => _mapObject.position.y;
        set => _mapObject.position.y = value;
    }
    
    public float z
    {
        get => _mapObject.position.z;
        set => _mapObject.position.z = value;
    }
    
    public string unique_id => _mapObject.assetPropertyCollection.getProperty("uniqueID").data.ToString();
    
    public string type_name
    {
        get => _mapObject.typeName;
        set => _mapObject.typeName = value;
    }

    public string belong_to_team_full_name
    {
        get => _mapObject.assetPropertyCollection.getProperty("originalOwner").data.ToString();
        set => _mapObject.assetPropertyCollection.getProperty("originalOwner").data = value;
    }

    public string object_name
    {
        get => _mapObject.assetPropertyCollection.getProperty("objectName").data.ToString();
        set => _mapObject.assetPropertyCollection.getProperty("objectName").data = value;
    }
    
    public int initial_health
    {
        get => (int)_mapObject.assetPropertyCollection.getProperty("objectInitialHealth").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectInitialHealth").data = value;
    }
    
    public bool enabled
    {
        get => (bool)_mapObject.assetPropertyCollection.getProperty("objectEnabled").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectEnabled").data = value;
    }

    public bool indestructible
    {
        get => (bool)_mapObject.assetPropertyCollection.getProperty("objectIndestructible").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectIndestructible").data = value;
    }
    
    public bool unsellable
    {
        get => (bool)_mapObject.assetPropertyCollection.getProperty("objectUnsellable").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectUnsellable").data = value;
    }
    
    public bool powered
    {
        get => (bool)_mapObject.assetPropertyCollection.getProperty("objectPowered").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectPowered").data = value;
    }
    
    public bool recruitable_ai
    {
        get => (bool)_mapObject.assetPropertyCollection.getProperty("objectRecruitableAI").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectRecruitableAI").data = value;
    }
    
    public bool targetable
    {
        get => (bool)_mapObject.assetPropertyCollection.getProperty("objectTargetable").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectTargetable").data = value;
    }
    
    public bool sleeping
    {
        get => (bool)_mapObject.assetPropertyCollection.getProperty("objectSleeping").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectSleeping").data = value;
    }
    
    public int base_priority
    {
        get => (int)_mapObject.assetPropertyCollection.getProperty("objectBasePriority").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectBasePriority").data = value;
    }
    
    public int base_phase
    {
        get => (int)_mapObject.assetPropertyCollection.getProperty("objectBasePhase").data;
        set => _mapObject.assetPropertyCollection.getProperty("objectBasePhase").data = value;
    }
    
    public string layer
    {
        get => _mapObject.assetPropertyCollection.getProperty("objectLayer").data.ToString();
        set => _mapObject.assetPropertyCollection.getProperty("objectLayer").data = value;
    }
    
    public string stance
    {
        get
        {
            return ((StanceEnum)((int)_mapObject.assetPropertyCollection.getProperty("objectInitialStance").data)).ToString();
        }
        set => _mapObject.assetPropertyCollection.getProperty("objectInitialStance").data = (int)Enum.Parse<StanceEnum>(value);
    }
    
    public int experience_level
    {
        get => (int)_mapObject.assetPropertyCollection.getProperty("objectExperienceLevel").data;
        set
        {
            if (value < 1 || value > 4)
            {
                throw new ArgumentException("Experience level must be between 1 and 4");
            }
            _mapObject.assetPropertyCollection.getProperty("objectExperienceLevel").data = value;
        }
    }

    public override string ToString()
    {
        return "ObjectModel{" +
               "angle=" + angle +
               ", x=" + x +
               ", y=" + y +
               ", z=" + z +
               ", unique_id='" + unique_id + '\'' +
               ", type_name='" + type_name + '\'' +
               ", belong_to_team_name='" + belong_to_team_full_name + '\'' +
               ", object_name='" + object_name + '\'' +
               ", initial_health=" + initial_health +
               ", enabled=" + enabled +
               ", indestructible=" + indestructible +
               ", unsellable=" + unsellable +
               ", powered=" + powered +
               ", recruitable_ai=" + recruitable_ai +
               ", targetable=" + targetable +
               ", sleeping=" + sleeping +
               ", base_priority=" + base_priority +
               ", base_phase=" + base_phase +
               ", layer='" + layer + '\'' +
               ", stance='" + stance + '\'' +
               ", experience_level=" + experience_level +
               '}';
    }
}