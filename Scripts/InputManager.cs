using Godot;
using System;

[GlobalClass]
public partial class InputManager : Node
{
	[Export(PropertyHint.Enum, "Player, Ship")]
	private string inputGroupName;
	// Called when the node enters the scene tree for the first time.
	
}
