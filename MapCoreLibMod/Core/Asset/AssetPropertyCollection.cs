using System.Collections.Generic;
using System.IO;
using MapCoreLibMod.Util;

namespace MapCoreLibMod.Core.Asset
{
    public class AssetPropertyCollection
    {

        public Dictionary<string, AssetProperty> propertyMap = new Dictionary<string, AssetProperty>();

        public AssetPropertyCollection fromStream(BinaryReader binaryReader, MapDataContext context)
        {
            var propertyCount = binaryReader.ReadInt16();
            for (int i = 0; i < propertyCount; i++)
            {
                var assetProperty = new AssetProperty().fromStream(binaryReader, context);
                propertyMap.put(assetProperty.name, assetProperty);
            }

            return this;
        }

        public void saveData(BinaryWriter binaryWriter, MapDataContext context)
        {
            binaryWriter.Write((ushort)propertyMap.Count);
            foreach (var property in propertyMap.Values)
            {
                property.saveData(binaryWriter, context);
            }
        }

        public void addProperty(string name, object data, MapDataContext context)
        {
            if (propertyMap.ContainsKey(name))
            {
                return;
            }

            AssetProperty property = AssetProperty.of(name, data, context);
            propertyMap.Add(property.name, property);
        }
        
        public void addOrSetProperty(string name, object data, MapDataContext context)
        {
            if (propertyMap.ContainsKey(name))
            {
                propertyMap[name].data = data;
                return;
            }

            AssetProperty property = AssetProperty.of(name, data, context);
            propertyMap.Add(property.name, property);
        }
        
        public AssetProperty? getProperty(string name)
        {
            if (!propertyMap.ContainsKey(name))
            {
                return null;
            }

            return propertyMap[name];
        }
        
        public void setProperty(string name, object data)
        {
            if (!propertyMap.ContainsKey(name))
            {
                return;
            }

            propertyMap[name].data = data;
        }
        
        public void removeProperty(string name)
        {
            if (!propertyMap.ContainsKey(name))
            {
                return;
            }

            propertyMap.Remove(name);
        }

        public override string ToString()
        {
            var result = "{\n";
            foreach (var pair in propertyMap)
            {
                result += pair.Key + " : " + pair.Value + "\n";
            }
            result += "}";
            
            
            return result;
        }
    }
}