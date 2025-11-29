using Godot;
using TeleporterChess.Model;

namespace TeleporterChess.Utils;

public struct CoordinateConverter
{
    const int GRIDMAP_OFFSET = 4;

    public static (Column column, Row row) ConvertGridMapCoordinatesToBoardCoordinates(Vector3I gridMapCoordinates)
    {
        return ((Column)gridMapCoordinates.X + GRIDMAP_OFFSET, (Row)gridMapCoordinates.Z + GRIDMAP_OFFSET);
    }

    public static Vector3I ConvertBoardCoordinatesToGridMapCoordinates(Column column, Row row)
    {
        Vector3I result = Vector3I.Zero;
        result.X = (int)column - GRIDMAP_OFFSET;
        result.Z = (int)row - GRIDMAP_OFFSET;
        return result;
    }
}
