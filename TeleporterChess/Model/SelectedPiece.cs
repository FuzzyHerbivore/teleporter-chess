namespace TeleporterChess.Model;

public struct SelectedPiece(Piece piece, Square square)
{
    public Piece piece = piece;
    public Square square = square;
}
