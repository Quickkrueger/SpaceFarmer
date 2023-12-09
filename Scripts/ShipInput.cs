using Godot;
using System;
using System.Runtime.CompilerServices;


public partial class ShipInput : Node
{
	[Signal]
	public delegate void ChangePitchEventHandler(float value);
	[Signal]
	public delegate void ChangeYawEventHandler(float value);
	[Signal]
	public delegate void ChangeRollEventHandler(float value);
	[Signal]
	public delegate void PrimaryAttackEventHandler();
	[Signal]
	public delegate void SecondaryAttackEventHandler();
	[Signal]
	public delegate void BoostEventHandler();
	[Signal]
	public delegate void BrakeEventHandler();

    private ShipRotationInputs shipRotationInputs = new ShipRotationInputs();

	public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);

        shipRotationInputs.pitch = HandleAxisInput(@event, "Pitch", shipRotationInputs.pitch);
        shipRotationInputs.yaw = HandleAxisInput(@event, "Yaw", shipRotationInputs.yaw);
        shipRotationInputs.roll = HandleAxisInput(@event, "Roll", shipRotationInputs.roll);

        if (@event.IsAction("Primary Fire"))
        {
            EmitSignal(SignalName.PrimaryAttack);
        }
        if (@event.IsAction("Secondary Fire"))
        {
            EmitSignal(SignalName.SecondaryAttack);
        }

        if (@event.IsAction("Boost"))
        {
            EmitSignal(SignalName.Boost);
        }
        if (@event.IsAction("Brake"))
        {
            EmitSignal(SignalName.Brake);
        }
    }

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
            GD.Print($"{axisName}: {resultData.X + resultData.Y}");

        }

        return resultData;
    }
}

  

public struct ShipRotationInputs
{
    public Vector2 pitch;
    public Vector2 yaw;
    public Vector2 roll;

    public ShipRotationInputs()
    {
        pitch = Vector2.Zero;
        yaw = Vector2.Zero;
        roll = Vector2.Zero;
    }
}
