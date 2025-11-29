#nullable enable

using System;

namespace TeleporterChess.Model;

public struct BoardActions(Func<Square, bool>? selectSquareAction, Action? deselectAllAction)
{
    public Func<Square, bool>? SelectSquareAction { get; private set; } = selectSquareAction;
    public Action? DeselectAllAction { get; private set; } = deselectAllAction;
}
