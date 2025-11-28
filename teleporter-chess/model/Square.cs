namespace TeleporterChess.Model;

public enum Column : uint
{
    A, B, C, D, E, F, G, H
}

public enum Row : uint
{
    _1, _2, _3, _4, _5, _6, _7, _8
}

public struct Square(Column column, Row row)
{
    public Column Column { get; private set; } = column;
    public Row Row { get; private set; } = row;

    public readonly (uint, uint) GetCoordinates()
    {
        return ((uint)Column, (uint)Row);
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
