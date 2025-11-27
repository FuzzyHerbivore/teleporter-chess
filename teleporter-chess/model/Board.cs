using System;
using System.Collections.Generic;

namespace TeleporterChess.model
{
    public class Board
    {
        const uint ROW_COUNT = 8;
        const uint COLUMN_COUNT = 8;

        readonly Dictionary<(uint, uint), Piece> squares;

        public BoardData Data => new BoardData()
        {
            rowCount = ROW_COUNT,
            columnCount = COLUMN_COUNT,
            squares = new(squares)
        };

        public bool IsPlaceable(Piece piece, uint row, uint column)
        {
            if (row >= ROW_COUNT) return false;
            if (column >= COLUMN_COUNT) return false;

            var square = (row, column);

            // TODO: Add other conditions per piece type in separate methods

            if (GetSquare(row, column) != null) return false; // TODO: Change this to check for capture
            // TODO: Add check for checkmate/stallmate

            return true;
        }

        public bool TryPlacing(Piece piece, uint row, uint column)
        {
            if (!IsPlaceable(piece, row, column)) return false;

            var square = (row, column);
            squares[square] = piece;

            return true;
        }

        private Piece? GetSquare(uint row, uint column)
        {
            if (squares.TryGetValue((row, column), out Piece piece))
            {
                return piece;
            }

            return null;
        }


    }
}
