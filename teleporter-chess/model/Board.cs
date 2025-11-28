using System.Collections.Generic;

namespace TeleporterChess.Model
{
    public class Board
    {
        const uint COLUMN_COUNT = 8;
        const uint ROW_COUNT = 8;

        readonly Dictionary<(uint, uint), Piece> squares = [];

        public BoardData Data => new()
        {
            columnCount = COLUMN_COUNT,
            rowCount = ROW_COUNT,
            squares = new(squares)
        };

        public bool IsPlaceable(Piece piece, uint column, uint row)
        {
            if (column >= COLUMN_COUNT) return false;
            if (row >= ROW_COUNT) return false;

            // TODO: Add other conditions per piece type in separate methods

            if (GetSquare(column, row) != null) return false; // TODO: Change this to check for capture
            // TODO: Add check for checkmate/stallmate

            return true;
        }

        public bool TryPlacing(Piece piece, uint column, uint row)
        {
            if (!IsPlaceable(piece, column, row)) return false;

            var square = (column, row);
            squares[square] = piece;

            return true;
        }

        public Piece? GetSquare(uint column, uint row)
        {
            if (squares.TryGetValue((column, row), out Piece piece))
            {
                return piece;
            }

            return null;
        }
    }
}
