namespace MapCoreLibMod.Core.NewMap
{
    public interface NewMapOptionHandler
    {
        void handle(MapDataContext context, NewMapConfig config);

        string optionName();
    }
}