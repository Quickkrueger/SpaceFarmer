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

        float pitchValue = 0;

        pitchValue += @event.GetActionStrength("Pitch Up");
        pitchValue += @event.GetActionStrength("Pitch Down") * -1f;

        if (pitchValue != 0 || @event.IsAction("Pitch Up") || @event.IsAction("Pitch Down"))
        {
            EmitSignal(SignalName.ChangePitch, pitchValue);
        }

        float yawValue = 0;

        yawValue += @event.GetActionStrength("Yaw Left");
        yawValue += @event.GetActionStrength("Yaw Right") * -1f;

        if (yawValue != 0 || @event.IsAction("Yaw Right") || @event.IsAction("Yaw Left"))
        {
            EmitSignal(SignalName.ChangeYaw, yawValue);
        }

        float rollValue = 0;

        rollValue += @event.GetActionStrength("Roll Left");
        rollValue += @event.GetActionStrength("Roll Right") * -1f;

        if (rollValue != 0 || @event.IsAction("Roll Right") || @event.IsAction("Roll Left"))
        {
            EmitSignal(SignalName.ChangeRoll, rollValue);
        }

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
}
