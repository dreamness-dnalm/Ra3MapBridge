using MapCoreLib.Core;
using MapCoreLib.Core.Asset;
using MapCoreLib.Util;
using Ra3MapBridge.model;

namespace Ra3MapBridge;

public partial class Ra3MapWrap
{
        
    // ---------- objects ----------------
    private ObjectsList objectsList { get; set; }

    public List<ObjectModel> GetObjects()
    {
        return objectsList.mapObjects.Where(o => o.typeName != "*Waypoints/Waypoint")
            .Select(o => new ObjectModel(o))
            .ToList();
    }

    public ObjectModel AddObject(string typeName, float x, float y, float z=0)
    {
        return new ObjectModel(objectsList.AddObject(ra3Map.getContext(), typeName, new Vec3D(x, y, z)));
    }
    
    public bool RemoveObjectOrWaypoint(string uniqueID)
    {
        var objectsListMapObjects = objectsList.mapObjects;

        for (int i = 0; i < objectsListMapObjects.Count; i++)
        {
            if(objectsListMapObjects[i].uniqueID == uniqueID)
            {
                objectsListMapObjects.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // public bool RemoveObject(ObjectModel obj)
    // {
    //     return RemoveObjectOrWaypoint(obj.UniqueID);
    // }
    
    // --------- waypoint -----------
    
    public List<WaypointModel> GetWaypoints()
    {
        return objectsList.mapObjects.Where(o => o.typeName == "*Waypoints/Waypoint")
            .Select(o => new WaypointModel(o))
            .ToList();
    }
    
    public WaypointModel AddWaypoint(string waypointName, float x, float y, float z=0)
    {
        return new WaypointModel(objectsList.AddWaypoint(ra3Map.getContext(), waypointName, new Vec3D(x, y, z)));
    }

    public WaypointModel AddPlayerStartWaypoint(MapDataContext context, int playerIndex, float x, float y, float z = 0)
    {
        return new WaypointModel(objectsList.AddPlayerStartWaypoint(context, playerIndex, new Vec3D(x, y, z)));
    }

    public bool RemoveWaypoint(string waypointName)
    {
        var objectsListMapObjects = objectsList.mapObjects;

        for (int i = 0; i < objectsListMapObjects.Count; i++)
        {
            if(objectsListMapObjects[i].uniqueID == waypointName)
            {
                objectsListMapObjects.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public WaypointModel GetWaypoint(string waypointName)
    {
        return GetWaypoints().FirstOrDefault(w => w.waypoint_name == waypointName, null);
    }
    
    // ---- init ----
    private void LoadObjectsList()
    {
        objectsList = ra3Map.getContext().getAsset<ObjectsList>(Ra3MapConst.ASSET_ObjectsList);
    }
}