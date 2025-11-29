using TeleporterChess.Model;
using TeleporterChess.Utils;

namespace TeleporterChessTests;

public class GridMapIdMapperTests
{
    [Theory]
    [InlineData(Piece.Type.King, Player.Color.Black, 0)]
    [InlineData(Piece.Type.King, Player.Color.White, 1)]
    [InlineData(Piece.Type.Queen, Player.Color.Black, 6)]
    [InlineData(Piece.Type.Rook, Player.Color.White, 9)]
    public void MapGridMapIdToPieceReturnsCorrectId(Piece.Type pieceType, Player.Color pieceColor, int expectedGridMapId)
    {
        int gridMapId = GridMapIdMapper.MapPieceToGridMapId(new Piece(pieceType, pieceColor));

        Assert.Equal(expectedGridMapId, gridMapId);
    }

    [Fact]
    public void MapGridMapIdToPieceReturnsNullForIncorrectId()
    {
        int invalidId = 12;
        Piece? piece = GridMapIdMapper.MapGridMapIdToPiece(invalidId);

        Assert.Null(piece);
    }

    [Theory]
    [InlineData(0, Piece.Type.King, Player.Color.Black)]
    [InlineData(1, Piece.Type.King, Player.Color.White)]
    [InlineData(6, Piece.Type.Queen, Player.Color.Black)]
    [InlineData(9, Piece.Type.Rook, Player.Color.White)]
    public void MapGridMapIdToPieceReturnsCorrectPiece(int gridMapId, Piece.Type expectedPieceType, Player.Color expectedPieceColor)
    {
        Piece? piece = GridMapIdMapper.MapGridMapIdToPiece(gridMapId);

        Assert.Equal((expectedPieceType, expectedPieceColor), (piece?.type, piece?.color));
    }
}
