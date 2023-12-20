using Godot;
using System;

public partial class PlayerInput : Node
{
[Signal]
public delegate void ChangeHorizontalEventHandler(float value);
[Signal]
public delegate void ChangeVerticalEventHandler(float value);
[Signal]
public delegate void CycleOptionsEventHandler(float value);
[Signal]
public delegate void InteractionEventHandler();
    // Called when the node enters the scene tree for the first time.

    PlayerVectorInputs playerVectorInputs = new PlayerVectorInputs();

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);

        playerVectorInputs.vertical = HandleAxisInput(@event, "Pitch", playerVectorInputs.vertical);
        playerVectorInputs.horizontal = HandleAxisInput(@event, "Yaw", playerVectorInputs.horizontal);
        playerVectorInputs.cycle = HandleAxisInput(@event, "Roll", playerVectorInputs.cycle);

        if (@event.IsAction("Interact"))
        {
            EmitSignal(SignalName.Interaction);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    private Vector2 HandleAxisInput(InputEvent @event, string axisName, Vector2 inputData)
    {
        Vector2 resultData = inputData;

        if (@event.IsActionPressed($"{axisName} +"))
        {
            resultData.X = @event.GetActionStrength($"{axisName} +");
        }
        else if (@event.IsActionReleased($"{axisName} +"))
        {
            resultData.X = 0;
        }

        if (@event.IsActionPressed($"{axisName} -"))
        {
            resultData.Y = @event.GetActionStrength($"{axisName} -") * -1;
        }
        else if (@event.IsActionReleased($"{axisName} -"))
        {
            resultData.Y = 0;
        }

        if ((@event.IsActionPressed($"{axisName} +") || @event.IsActionPressed($"{axisName} -"))
            || @event.IsActionReleased($"{axisName} +") || @event.IsActionReleased($"{axisName} -"))
        {

            EmitSignal($"Change{axisName}", resultData.X + resultData.Y);

        }
        return resultData;
    }
}

public struct PlayerVectorInputs
{
    public Vector2 vertical;
    public Vector2 horizontal;
    public Vector2 cycle;

    public PlayerVectorInputs()
    {
        vertical = Vector2.Zero;
        horizontal = Vector2.Zero;
        cycle = Vector2.Zero;
    }
}