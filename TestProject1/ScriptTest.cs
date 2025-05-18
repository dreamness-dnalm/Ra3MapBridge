using System.Text;
using MapCoreLibMod.Core;
using MapCoreLibMod.Core.Asset;
using MapCoreLibMod.Core.Util;

namespace TestProject1;

public class ScriptTest
{
    [Test]
    public static void t01()
    {
        var mapName = "bin_test";
        
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        
        var ra3Map = new Ra3Map(Path.Combine(PathUtil.RA3MapFolder, mapName, mapName + ".map"));
        ra3Map.parse();


        var scriptList = ra3Map.getContext().getAsset<PlayerScriptsList>("PlayerScriptsList");
        Console.WriteLine(scriptList);
        var name = scriptList.scriptLists[0].scripts[1].Name;
        Console.WriteLine(name);
        var bytes = Encoding.Default.GetBytes(name);
        var name2 = Encoding.GetEncoding("GB2312").GetString(bytes);
        Console.WriteLine(name2);
        // var cdet = new CharsetDetector();
        // cdet.Feed(bytes, 0, bytes.Length);
        // cdet.DataEnd();
        // Console.WriteLine(cdet.Charset);
        // // Console.WriteLine(cdet.Confidence);
        // var name3 = Encoding.GetEncoding(cdet.Charset).GetString(bytes);
        // Console.WriteLine(name3);
        

        
        
    }

    [Test]
    public void guessCode()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        byte[] data = {
            0x73, 0x63, 0x72, 0x69, 0x70, 0x74, 0xBD, 0xC5, 0xB1, 0xBE, 0x61, 0x61, 0x61, 0x61, 0x32, 
        };
        // Get all available encodings
        var encodings = Encoding.GetEncodings();

        foreach (var encodingInfo in encodings)
        {
            try
            {
                var encoding = encodingInfo.GetEncoding();
                var decodedString = encoding.GetString(data);
                Console.WriteLine($"Encoding: {encoding.EncodingName} ({encoding.WebName})");
                Console.WriteLine($"Decoded String: {decodedString}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Encoding: {encodingInfo.Name} failed with error: {ex.Message}");
            }
        }
    }
}