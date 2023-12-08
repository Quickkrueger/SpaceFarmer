using Godot;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

public partial class ShipMovement : Node
{
	
	private CharacterBody3D moveableCharacter;
	private Vector3 rotationalInputs;
	private bool runningRotation = false;

	[Export]
	public Vector3 rotationalSpeeds;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		moveableCharacter = GetParent<CharacterBody3D>();

		if(moveableCharacter == null) 
		{ 
			Free(); 
		}
	}

	public void UpdatePitch(float pitchInput)
	{
		rotationalInputs.X = pitchInput;
        RotateShip();
    }

    public void UpdateYaw(float yawInput)
    {
        rotationalInputs.Y =  yawInput;
        RotateShip();
    }

    public void UpdateRoll(float rollInput)
    {
        rotationalInputs.Z =  rollInput;
		RotateShip();
    }

	private void RotateShip()
	{
		if(rotationalInputs != Vector3.Zero && !runningRotation)
		{
			runningRotation = true;
			RotateCoroutine();
		}
	}

	private async Task RotateCoroutine()
	{
		moveableCharacter.Rotate(moveableCharacter.GlobalBasis.X.Normalized(), (float)GetPhysicsProcessDeltaTime() * rotationalInputs.X * rotationalSpeeds.X);
        moveableCharacter.Rotate(moveableCharacter.GlobalBasis.Y.Normalized(), (float)GetPhysicsProcessDeltaTime() * rotationalInputs.Y * rotationalSpeeds.Y);
        moveableCharacter.Rotate(moveableCharacter.GlobalBasis.Z.Normalized(), (float)GetPhysicsProcessDeltaTime() * rotationalInputs.Z * rotationalSpeeds.Z);

        await ToSignal(GetTree().CreateTimer(GetPhysicsProcessDeltaTime()), SceneTreeTimer.SignalName.Timeout);

		if (!runningRotation || rotationalInputs == Vector3.Zero)
		{
            runningRotation = false;
        }
		else if(rotationalInputs != Vector3.Zero && runningRotation)
		{
            RotateCoroutine();
			return;
        }
		
	}
}
