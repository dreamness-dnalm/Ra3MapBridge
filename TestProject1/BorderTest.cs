using MapCoreLibMod.Core.Util;
using Ra3MapBridge;

namespace TestProject1;

public class BorderTest
{
    [Test]
    public void TestBorder()
    {
        var ra3MapWrap = Ra3MapWrap.Open(PathUtil.RA3MapFolder, "border_test2");

        var heightMapBorders = ra3MapWrap.GetBorders();

        // foreach (var border in heightMapBorders)
        // {
        //     Console.WriteLine(border);
        //     ra3MapWrap.SetBorder(border, border.Corner1X + 50, border.Corner1Y + 50, border.Corner2X - 50, border.Corner2Y - 50);
        // }
        
        // ra3MapWrap.RemoveBorder(heightMapBorders[2]);
        
        ra3MapWrap.AddBorder(80, 80, 190, 190);
        
        Console.WriteLine(heightMapBorders.Count);
        
        foreach (var border in heightMapBorders)
        {
            Console.WriteLine(border);
        }
        
        ra3MapWrap.Save();
    }
}