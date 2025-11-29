using System;

namespace TeleporterChess.Model;

public struct GameCallbacks
{
    public Action<Square> SelectSquare;
}
