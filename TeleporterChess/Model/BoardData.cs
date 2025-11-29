using System.Collections.Generic;

namespace TeleporterChess.Model;

public struct BoardData
{
    public Dictionary<Square, Piece> placedPieces;
    public BoardActions availableActions;
}
