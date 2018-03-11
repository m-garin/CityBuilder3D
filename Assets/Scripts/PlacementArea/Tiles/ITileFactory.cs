
namespace PlacementArea.Tiles
{
    public interface ITileFactory
    {
        ITile Create(int _x, int _y);
    }
}