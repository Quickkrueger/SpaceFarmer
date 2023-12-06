using Godot;
using System;


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

	public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);

		if(@event.IsAction("Pitch Up"))
		{
			EmitSignal(SignalName.ChangePitch, @event.GetActionStrength("Pitch Up"));
		}
        if (@event.IsAction("Pitch Down"))
        {
            EmitSignal(SignalName.ChangePitch, @event.GetActionStrength("Pitch Down") * -1f);
        }

        if (@event.IsAction("Yaw Left"))
        {
            EmitSignal(SignalName.ChangeYaw, @event.GetActionStrength("Yaw Left"));
        }
        if (@event.IsAction("Yaw Right"))
        {
            EmitSignal(SignalName.ChangeYaw, @event.GetActionStrength("Yaw Right") * -1f);
        }

        if (@event.IsAction("Roll Left"))
        {
            EmitSignal(SignalName.ChangeRoll, @event.GetActionStrength("Roll Left"));
        }
        if (@event.IsAction("Roll Right"))
        {
            EmitSignal(SignalName.ChangeRoll, @event.GetActionStrength("Roll Right") * -1f);
        }

        if (@event.IsActionPressed("Primary Fire"))
        {
            EmitSignal(SignalName.PrimaryAttack);
        }
        if (@event.IsActionPressed("Secondary Fire"))
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
}
