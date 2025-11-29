namespace TeleporterChessTests;

using Godot;
using TeleporterChess.Model;

public class SquareModelTests
{
    [Theory]
    [InlineData(-4, -4, Column.A, Row._1)]
    [InlineData(0, 0, Column.E, Row._5)]
    [InlineData(3, 3, Column.H, Row._8)]
    public void ConstructorTakingVector3ICreatesCorrectSquare(int gridMapCoordinateX, int gridMapCoordinateZ, Column expectedColumn, Row expectedRow)
    {
        Square expectedSquare = new(new Vector3I(gridMapCoordinateX, 0, gridMapCoordinateZ));

        Assert.Equal((expectedColumn, expectedRow), (expectedSquare.Column, expectedSquare.Row));
    }

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
