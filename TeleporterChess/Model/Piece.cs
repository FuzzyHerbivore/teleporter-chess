using System.Diagnostics.CodeAnalysis;

namespace TeleporterChess.Model;

public struct Piece(Piece.Type type, Player.Color color)
{
    public enum Type
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn
    }

    public Type type = type;
    public Player.Color color = color;

    public override readonly bool Equals([NotNullWhen(true)] object obj)
    {
        return base.Equals(obj);
    }

    public override readonly int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(Piece piece, Piece otherPiece)
    {
        return piece.Equals(otherPiece);
    }

    public static bool operator !=(Piece piece, Piece otherPiece)
    {
        return !piece.Equals(otherPiece);
    }
}
