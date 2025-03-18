using System.Collections.Generic;
using System.IO;
using MapCoreLibMod.Util;

namespace MapCoreLibMod.Core.Asset
{
    public class LibraryMaps: MajorAsset
    {
        public List<string> libraryMaps;

        protected override void saveData(BinaryWriter bw, MapDataContext context)
        {
            bw.Write(libraryMaps.Count);
            foreach (var libraryMap in libraryMaps)
            {
                bw.writeDefaultString(libraryMap);
            }
        }

        public override string getAssetName()
        {
            return Ra3MapConst.ASSET_LibraryMaps;
        }

        public override short getVersion()
        {
            return base.getVersion();
        }
    }
}