using TeleporterChess.model;

public enum PieceType
{
    King,
    Queen,
    Bishop,
    Knight,
    Rook,
    Pawn
}

public struct Piece
{
    public PieceType pieceType;
    public Player player;
}