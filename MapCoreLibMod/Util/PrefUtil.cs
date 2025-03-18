using System;
using System.Collections.Generic;
using MapCoreLibMod.Util;

namespace MapCoreLibMod.Log
{
    internal static class PrefUtil
    {
        private static Dictionary<string, long> record = new Dictionary<string, long>();

        public static void start(string tag)
        {
            record.put(tag, DateTime.Now.Millisecond);
        }

        public static void stop(string tag)
        {
            LogUtil.log($"{tag} | consume time: {DateTime.Now.Millisecond - record[tag]}ms");
        }
    }
}