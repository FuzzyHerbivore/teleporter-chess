namespace TeleporterChessTests;

using TeleporterChess.Model;

public class SquareModelTests
{
    [Theory]
    [InlineData(Column.A, Row._1, 0, 0)]
    [InlineData(Column.E, Row._5, 4, 4)]
    [InlineData(Column.H, Row._8, 7, 7)]
    public void GetCoordinatesReturnsCorrectCoordinates(Column column, Row row, uint expectedColumn, uint expectedRow)
    {
        Square square = new(column, row);

        (uint, uint) indexCoordinates = square.GetCoordinates();

        Assert.Equal((expectedColumn, expectedRow), indexCoordinates);
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
