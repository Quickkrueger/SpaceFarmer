using Godot;
using System;

public partial class PlayerShip : CharacterBody3D
{
	[Export]
	public ShipMovement shipMovement;
	
	private void OnChangePitch(float value)
	{
		shipMovement?.UpdatePitch(value);
	}

	private void OnChangeRoll(float value)
	{
		shipMovement?.UpdateRoll(value);
	}

	private void OnChangeYaw(float value)
	{
		shipMovement?.UpdateYaw(value);
	}

	private void OnPrimary()
	{
		GD.Print("Primary");
	}

	private void OnSecondary()
	{
		GD.Print("Secondary");
	}

	private void OnBoost()
	{
		GD.Print("Boost");
	}

	private void OnBrake()
	{
		GD.Print("Brake");
	}

}
