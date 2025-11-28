namespace TeleporterChessTests;

using Godot;
using TeleporterChess.Model;

public class SquareModelTests
{
    [Theory]
    [InlineData(Column.A, Row._1, -4, -4)]
    [InlineData(Column.E, Row._5, 0, 0)]
    [InlineData(Column.H, Row._8, 3, 3)]
    public void GetGridMapCoordinatesReturnsCorrectGridMapCoordinates(Column squareColumn, Row squareRow, int expectedColumn, int expectedRow)
    {
        Square square = new(squareColumn, squareRow);

        Vector3I gridMapCoordinates = square.GetGridMapCoordinates();

        Assert.Equal((expectedColumn, expectedRow), (gridMapCoordinates.X, gridMapCoordinates.Z));
    }

    [Theory]
    [InlineData(Column.A, Row._1, "A1")]
    [InlineData(Column.B, Row._5, "B5")]
    [InlineData(Column.H, Row._8, "H8")]
    public void ToStringReturnsCorrectlyFormattedCoordinates(Column column, Row row, string expectedString)
    {
        Square square = new(column, row);

        string squareString = square.ToString();

        Assert.Equal(expectedString, squareString);
    }
}
