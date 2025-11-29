#nullable enable

using System;
using System.Collections.Generic;

namespace TeleporterChess.Model;

public class Board
{
    Dictionary<Square, Piece> placedPieces = [];
    readonly Action UpdateGameModel;
    readonly Action SwitchCurrentPlayer;
    readonly Func<Player.Color> GetCurrentPlayerColor;

    SelectedPiece? selectedPiece; // Typestate pattern

    public BoardData Data => new()
    {
        placedPieces = new(placedPieces),
    };

    BoardActions availableActions;
    public BoardActions AvailableActions => availableActions;

    public Board(Action updateModelAction, Action switchCurrentPlayerAction, Func<Player.Color> getCurrentPlayerColor)
    {
        UpdateGameModel = updateModelAction;
        SwitchCurrentPlayer = switchCurrentPlayerAction;
        GetCurrentPlayerColor = getCurrentPlayerColor;

        availableActions = new(InteractWithSquare, DeselectAll);
    }

    public bool InteractWithSquare(Square square)
    {
        Piece? piece = GetPieceAt(square);

        // Select piece, no matter if a piece was selected before or not, but check for current player
        if (piece is Piece somePiece)
        {
            if (somePiece.color != GetCurrentPlayerColor()) return false;

            selectedPiece = new(somePiece, square);

            return true;
        }

        return TryMovingSelectedPieceTo(square);
    }

    public void DeselectAll()
    {
        selectedPiece = null;

        UpdateGameModel();
    }

    public bool TryMovingSelectedPieceTo(Square square)
    {
        if (selectedPiece is not SelectedPiece someSelectedPiece) return false;

        bool success = TryPlacing(someSelectedPiece.piece, someSelectedPiece.square, square);

        if (success)
        {
            selectedPiece = null;

            SwitchCurrentPlayer();
            UpdateGameModel();

            return true;
        }

        return false;
    }

    public Piece? GetPieceAt(Square square)
    {
        if (placedPieces.TryGetValue(square, out Piece piece))
        {
            return piece;
        }

        return null;
    }

    public void Reset()
    {
        ResetPlacedPieces();
    }

    public bool TryPlacing(Piece piece, Square? fromSquare, Square toSquare)
    {
        if (!IsPlaceable(piece, toSquare)) return false;

        placedPieces[toSquare] = piece;

        if (fromSquare is Square someFromSquare) placedPieces.Remove(someFromSquare);

        return true;
    }

    private bool IsPlaceable(Piece piece, Square square)
    {
        // TODO: Add other conditions per piece type in separate methods
        if (GetPieceAt(square) != null) return false; // TODO: Change this to check for capture
                                                      // TODO: Add check for check/checkmate/stallmate

        return true;
    }

    private void ResetPlacedPieces()
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
}
