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
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
