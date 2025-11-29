#nullable enable

using System;
using System.Collections.Generic;
using TeleporterChess.Model;

namespace TeleporterChess.Utils;

public readonly struct GridMapIdMapper
{
    private static readonly Dictionary<Piece, int> PieceGridMapIdMapping = new() {
        { new Piece(Piece.Type.King, Player.Color.Black), 0 },
        { new Piece(Piece.Type.King, Player.Color.White), 1 },
        { new Piece(Piece.Type.Knight, Player.Color.Black), 2 },
        { new Piece(Piece.Type.Knight, Player.Color.White), 3 },
        { new Piece(Piece.Type.Pawn, Player.Color.Black), 4 },
        { new Piece(Piece.Type.Pawn, Player.Color.White), 5 },
        { new Piece(Piece.Type.Queen, Player.Color.Black), 6 },
        { new Piece(Piece.Type.Queen, Player.Color.White), 7 },
        { new Piece(Piece.Type.Rook, Player.Color.Black), 8 },
        { new Piece(Piece.Type.Rook, Player.Color.White), 9 },
        { new Piece(Piece.Type.Bishop, Player.Color.Black), 10 },
        { new Piece(Piece.Type.Bishop, Player.Color.White), 11 }
    };

    public static int MapPieceToGridMapId(Piece piece)
    {
        if (!PieceGridMapIdMapping.TryGetValue(piece, out int value)) throw new Exception($"No GridMap id found for piece {piece} GridMapIdMapper is not set up correctly!");

        return value;
    }

    public static Piece? MapGridMapIdToPiece(int mapId)
    {
        foreach ((Piece piece, int id) in PieceGridMapIdMapping)
        {
            if (id == mapId) return piece;
        }

        return null;
    }
}
