namespace TeleporterChess.Model;

public enum Column : uint
{
    A = 1, B, C, D, E, F, G, H
}

public enum Row : uint
{
    _1 = 1, _2, _3, _4, _5, _6, _7, _8
}

public struct Square
{
    Column column;
    Row row;

    public Square(Column column, Row row)
    {
        this.column = column;
        this.row = row;
    }

    public (uint, uint) GetOneBasedCoordinates()
    {
        return ((uint)column, (uint)row);
    }

    public (uint, uint) GetZeroBasedCoordinates()
    {
        return ((uint)column - 1, (uint)row - 1);
    }

    public (Column, Row) GetManifestCoordinates()
    {
        return (column, row);
    }

    public override string ToString()
    {
        return $"{column}{(uint)row}";
    }
}
