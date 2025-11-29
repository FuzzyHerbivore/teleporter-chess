#nullable enable

using System;

namespace TeleporterChess.Model;

public struct GameActions(Action? resetAction)
{
    public Action? ResetAction { get; private set; } = resetAction;
}
