#nullable enable

using System;

namespace TeleporterChess.Model;

public struct GameActions(Action? resetAction, Action? switchCurrentPlayerAction)
{
    public Action? ResetAction { get; private set; } = resetAction;
    public Action? SwitchCurrentPlayerAction { get; private set; } = switchCurrentPlayerAction;
}
