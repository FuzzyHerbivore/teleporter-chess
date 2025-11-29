#nullable enable

using System;

namespace TeleporterChess.Model;

public struct BoardActions(Func<Square, bool>? interactWithSquareAction, Action? deselectAllAction)
{
    public Func<Square, bool>? InteractWithSquareAction { get; private set; } = interactWithSquareAction;
    public Action? DeselectAllAction { get; private set; } = deselectAllAction;
}
