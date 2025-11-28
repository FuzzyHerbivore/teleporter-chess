using TeleporterChess.Model;

namespace TeleporterChess.Utils;

public struct CoordinateConverter
{
    const int GRIDMAP_OFFSET = 5;

    public static (Column, Row) ConvertGridMapToSquareCoordinates((int, int) gridMapCoordinates)
    {
        return ((Column)gridMapCoordinates.Item1 + GRIDMAP_OFFSET, (Row)gridMapCoordinates.Item2 + GRIDMAP_OFFSET);
    }

    public static (int, int) ConvertSquareToGridMapCoordinates((Column, Row) squareCoordinates)
    {
        return ((int)squareCoordinates.Item1 - GRIDMAP_OFFSET, (int)squareCoordinates.Item2 - GRIDMAP_OFFSET);
    }
}
