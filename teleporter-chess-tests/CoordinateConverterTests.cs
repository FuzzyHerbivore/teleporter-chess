namespace TeleporterChessTests;

using Godot;

using TeleporterChess.Model;
using TeleporterChess.Utils;

public class CoordinateConverterTests
{
    [Theory]
    [InlineData(-4, -4, Column.A, Row._1)]
    [InlineData(0, 0, Column.E, Row._5)]
    [InlineData(3, 3, Column.H, Row._8)]
    public void ConvertGridMapCoordinatesToSquareReturnsCorrectSquare(int gridMapColumn, int gridMapRow, Column expectedColumn, Row expectedRow)
    {
        Vector3I gridMapVector = Vector3I.Zero;
        gridMapVector.X = gridMapColumn;
        gridMapVector.Z = gridMapRow;

        Square square = CoordinateConverter.ConvertGridMapCoordinatesToSquare(gridMapVector);
        Square expectedSquare = new(expectedColumn, expectedRow);
        Assert.Equal(expectedSquare, square);
    }

    [Theory]
    [InlineData(Column.A, Row._1, -4, -4)]
    [InlineData(Column.E, Row._5, 0, 0)]
    [InlineData(Column.H, Row._8, 3, 3)]
    public void ConvertSquareToGridMapCoordinatesReturnsCorrectCoordinates(Column squareColumn, Row squareRow, int expectedColumn, int expectedRow)
    {
        Vector3I gridMapCoordinates = CoordinateConverter.ConvertSquareToGridMapCoordinates(new Square(squareColumn, squareRow));

        Assert.Equal((expectedColumn, expectedRow), (gridMapCoordinates.X, gridMapCoordinates.Z));
    }
}
