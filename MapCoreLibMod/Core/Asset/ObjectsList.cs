using System.Collections.Generic;
using System.IO;
using MapCoreLib.Util;

namespace MapCoreLib.Core.Asset
{
    public class ObjectsList: MajorAsset
    {
        public List<MapObject> mapObjects = new List<MapObject>();
        
        public HashSet<string> uniqueIDSet = new HashSet<string>();
        
        public HashSet<string> waypointNameSet = new HashSet<string>();
        
        private Random random = new Random();

        public override MajorAsset fromStream(BinaryReader binaryReader, MapDataContext context)
        {
            base.fromStream(binaryReader, context);
            while (binaryReader.BaseStream.Position - dataStartPos < dataSize)
            {
                var mapObject = (MapObject) new MapObject().fromStream(binaryReader, context);
                mapObjects.Add(mapObject);
                uniqueIDSet.Add(mapObject.uniqueID);
            }

            return this;
        }

        protected override void saveData(BinaryWriter binaryWriter, MapDataContext context)
        {
            foreach (var mapObject in mapObjects)
            {
                mapObject.Save(binaryWriter, context);
            }
        }
        
        public MapObject AddObject(MapDataContext context, string typeName, Vec3D pos, float angle=0, string belongToTeam="PlyrNeutral/teamPlyrNeutral", string objName = "")
        {
            MapObject o = MapObject.ofObj(typeName, pos, angle, objName, belongToTeam, context);
            var uniqueID = typeName + mapObjects.Count + 1000;
            while (uniqueIDSet.Contains(uniqueID))
            {
                uniqueID = uniqueID + random.Next(1000);
            }
            
            o.assetPropertyCollection.addProperty("uniqueID", uniqueID, context);
            mapObjects.Add(o);
            var assetList = context.getAsset<AssetList>(Ra3MapConst.ASSET_AssetList);
            assetList.addInstance(typeName);
            uniqueIDSet.Add(uniqueID);
            return o;
        }
        
        public MapObject AddWaypoint(MapDataContext context, string name, Vec3D pos)
        {
            if (waypointNameSet.Contains(name))
            {
                throw new ArgumentException("Waypoint name is already registered: " + name);
            }
            
            MapObject o = MapObject.ofWaypoint(pos, context);
            // var uniqueID = "_WaypointObj" + mapObjects.Count + 1000;
            // while (uniqueIDSet.Contains(uniqueID))
            // {
            //     uniqueID = uniqueID + random.Next(1000);
            // }
            o.assetPropertyCollection.addProperty("uniqueID", name, context);
            o.assetPropertyCollection.addProperty("waypointID", mapObjects.Count + 1000, context);
            o.assetPropertyCollection.addProperty("waypointName", name, context);
            o.assetPropertyCollection.addProperty("waypointTypeOption", "", context);
            mapObjects.Add(o);
            // var assetList = context.getAsset<AssetList>(Ra3MapConst.ASSET_AssetList);
            uniqueIDSet.Add(name);
            waypointNameSet.Add(name);
            return o;
        }

        public MapObject AddPlayerStartWaypoint(MapDataContext context, int playerIndex, Vec3D pos)
        {
            if (playerIndex < 1 || playerIndex > 8)
            {
                throw new ArgumentException("Player index is out of range: " + playerIndex);
            }
            return AddWaypoint(context, $"Player_{playerIndex}_Start", pos);
        }

        public override string getAssetName()
        {
            return Ra3MapConst.ASSET_ObjectsList;
        }

        public override short getVersion()
        {
            return 3;
        }

        public static ObjectsList newInstance(MapDataContext context)
        {
            var objectsList = new ObjectsList();
            objectsList.name = Ra3MapConst.ASSET_ObjectsList;
            objectsList.id = context.MapStruct.RegisterString(objectsList.name);
            objectsList.version = objectsList.getVersion();
            return objectsList;
        }
    }
}