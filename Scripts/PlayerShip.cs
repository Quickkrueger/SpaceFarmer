using Godot;
using System;

public partial class PlayerShip : CharacterBody3D
{
	
	private void OnChangePitch(float value)
	{
		GD.Print("Pitch");
	}

	private void OnChangeRoll(float value)
	{
		GD.Print("Roll");
	}

	private void OnChangeYaw(float value)
	{
		GD.Print("Yaw");
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
