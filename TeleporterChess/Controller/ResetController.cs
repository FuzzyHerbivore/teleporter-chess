#nullable enable

using System;
using Godot;
using TeleporterChess.Model;

namespace TeleporterChess.Controller;

public partial class ResetController : Node
{
    Action? ResetAction;

    public void SetAvailableActions(GameActions gameActions)
    {
        ResetAction = gameActions.ResetAction;
    }

    public override void _UnhandledKeyInput(InputEvent @event)
    {
        if (@event.IsActionPressed("reset"))
        {
            ResetAction?.Invoke();
        }
    }
}
