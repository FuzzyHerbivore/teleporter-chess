using Godot;
using TeleporterChess.Utils;

namespace TeleporterChess.Model;

public enum Column : uint
{
    A, B, C, D, E, F, G, H
}

public enum Row : uint
{
    _1, _2, _3, _4, _5, _6, _7, _8
}

public struct Square
{
    public Square(Column column, Row row)
    {
        Column = column;
        Row = row;
    }

    public Square(Vector3I vector)
    {
        (Column, Row) = CoordinateConverter.ConvertGridMapCoordinatesToBoardCoordinates(vector);
    }

    public Column Column { get; private set; }
    public Row Row { get; private set; }

    public readonly Vector3I GetGridMapCoordinates()
    {
        return CoordinateConverter.ConvertBoardCoordinatesToGridMapCoordinates(Column, Row);
    }

    public readonly (Column, Row) GetManifestCoordinates()
    {
        return (Column, Row);
    }
    public override readonly string ToString()
    {
        return $"{Column}{(uint)Row + 1}"; // Row needs to compensate for zero-based index
    }
}
