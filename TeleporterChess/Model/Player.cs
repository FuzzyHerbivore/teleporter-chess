using System.Diagnostics.CodeAnalysis;

namespace TeleporterChess.Model;

public struct Player
{
    public enum Color
    {
        Black,
        White
    }

    public Color color;

    public override readonly bool Equals([NotNullWhen(true)] object obj)
    {
        return base.Equals(obj);
    }

    public override readonly int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(Player player, Player otherPlayer)
    {
        return player.Equals(otherPlayer);
    }

    public static bool operator !=(Player player, Player otherPlayer)
    {
        return !player.Equals(otherPlayer);
    }
}
