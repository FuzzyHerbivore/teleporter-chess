using System;
using System.Collections.Generic;

namespace TeleporterChess.Model
{
    public class Board()
    {
        readonly Dictionary<Square, Piece> placedPieces = [];

        public BoardData Data => new()
        {
            placedPieces = new(placedPieces)
        };

        public void Reset()
        {
            placedPieces.Clear(); // TODO: Use start setup
        }

        public bool IsPlaceable(Piece piece, Square square)
        {
            // TODO: Add other conditions per piece type in separate methods
            if (GetPieceAt(square) != null) return false; // TODO: Change this to check for capture
            // TODO: Add check for check/checkmate/stallmate

            return true;
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
    }
}
