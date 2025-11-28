namespace TeleporterChessTests;

using TeleporterChess.Model;
using TeleporterChess.Utils;

public class CoordinateConverterTests
{
    [Theory]
    [InlineData(-4, -4, Column.A, Row._1)]
    [InlineData(0, 0, Column.E, Row._5)]
    [InlineData(3, 3, Column.H, Row._8)]
    public void ConvertGridMapToSquareCoordinatesReturnsCorrectCoordinates(int gridMapColumn, int gridMapRow, Column expectedColumn, Row expectedRow)
    {
        (Column, Row) squareCoordinates = CoordinateConverter.ConvertGridMapToSquareCoordinates((gridMapColumn, gridMapRow));

        Assert.Equal((expectedColumn, expectedRow), squareCoordinates);
    }
}
