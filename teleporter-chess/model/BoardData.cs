using System.Collections.Generic;

public struct BoardData
{
    public uint rowCount;
    public uint columnCount;

    public Dictionary<(uint, uint), Piece> squares;
}
