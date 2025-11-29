using System.Collections.Generic;
using Godot;

namespace TeleporterChess.Model;

public class Board
{
    Dictionary<Square, Piece> placedPieces = [];
    Square? selectedSquare;

    public BoardData Data => new()
    {
        placedPieces = new(placedPieces),
    };

    BoardActions availableActions;
    public BoardActions AvailableActions => availableActions;

    public Board()
    {
        availableActions = new(SelectSquare, DeselectAll);
    }

    public void Reset()
    {
        placedPieces = new()
            {
                {new Square(Column.A, Row._1), new Piece(Piece.Type.Rook, Player.Color.White)},
                {new Square(Column.B, Row._1), new Piece(Piece.Type.Knight, Player.Color.White)},
                {new Square(Column.C, Row._1), new Piece(Piece.Type.Bishop, Player.Color.White)},
                {new Square(Column.D, Row._1), new Piece(Piece.Type.Queen, Player.Color.White)},
                {new Square(Column.E, Row._1), new Piece(Piece.Type.King, Player.Color.White)},
                {new Square(Column.F, Row._1), new Piece(Piece.Type.Bishop, Player.Color.White)},
                {new Square(Column.G, Row._1), new Piece(Piece.Type.Knight, Player.Color.White)},
                {new Square(Column.H, Row._1), new Piece(Piece.Type.Rook, Player.Color.White)},
                {new Square(Column.A, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.B, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.C, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.D, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.E, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.F, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.G, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.H, Row._2), new Piece(Piece.Type.Pawn, Player.Color.White)},
                {new Square(Column.A, Row._8), new Piece(Piece.Type.Rook, Player.Color.Black)},
                {new Square(Column.B, Row._8), new Piece(Piece.Type.Knight, Player.Color.Black)},
                {new Square(Column.C, Row._8), new Piece(Piece.Type.Bishop, Player.Color.Black)},
                {new Square(Column.D, Row._8), new Piece(Piece.Type.Queen, Player.Color.Black)},
                {new Square(Column.E, Row._8), new Piece(Piece.Type.King, Player.Color.Black)},
                {new Square(Column.F, Row._8), new Piece(Piece.Type.Bishop, Player.Color.Black)},
                {new Square(Column.G, Row._8), new Piece(Piece.Type.Knight, Player.Color.Black)},
                {new Square(Column.H, Row._8), new Piece(Piece.Type.Rook, Player.Color.Black)},
                {new Square(Column.A, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
                {new Square(Column.B, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
                {new Square(Column.C, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
                {new Square(Column.D, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
                {new Square(Column.E, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
                {new Square(Column.F, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
                {new Square(Column.G, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
                {new Square(Column.H, Row._7), new Piece(Piece.Type.Pawn, Player.Color.Black)},
            };
    }

    public bool TryPlacing(Piece piece, Square square)
    {
        if (!IsPlaceable(piece, square)) return false;

        placedPieces[square] = piece;
        return true;
    }

    public Piece? GetPieceAt(Square square)
    {
        if (placedPieces.TryGetValue(square, out Piece piece))
        {
            return piece;
        }

        return null;
    }

    public bool SelectSquare(Square square)
    {
        selectedSquare = square;
        GD.Print($"Selected {selectedSquare}");
        return true; // TODO: Check for validity depending on what mode we're in... think about API
    }

    public void DeselectAll()
    {
        selectedSquare = null;
    }

    private bool IsPlaceable(Piece piece, Square square)
    {
        // TODO: Add other conditions per piece type in separate methods
        if (GetPieceAt(square) != null) return false; // TODO: Change this to check for capture
                                                      // TODO: Add check for check/checkmate/stallmate

        return true;
    }
}
