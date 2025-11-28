using TeleporterChess.Model;

namespace TeleporterChess.Utils;

public struct CoordinateConverter
{
    const int GRIDMAP_OFFSET = 4;

    public static Square ConvertGridMapCoordinatesToSquare((int, int) gridMapCoordinates)
    {
        return new Square((Column)gridMapCoordinates.Item1 + GRIDMAP_OFFSET, (Row)gridMapCoordinates.Item2 + GRIDMAP_OFFSET);
    }

    public static (int, int) ConvertSquareToGridMapCoordinates(Square square)
    {
        return ((int)square.Column - GRIDMAP_OFFSET, (int)square.Row - GRIDMAP_OFFSET);
    }
}
