using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


public partial class invoker : CharacterBody2D
{
	[Export]
	private int moveSpeed = 525;

	[Signal]
	public delegate void SetTypeEventHandler(string type);

	// movment related parameters
	private bool isMoving = false;
	private Vector2 moveDestination;
	private Vector2 moveDirection;

	private Vector2 previousFramePos;

	// animation related parameters
	private Sprite2D InvokerImage;

	// orb related parameters
	private PackedScene OrbsScene;
	private Marker2D OrbsPos1;
	private Marker2D OrbsPos2;
	private Marker2D OrbsPos3;

	private Node2D HadOrbs;
	public Node2D Orbs1;
	public Node2D Orbs2;
	public Node2D Orbs3;

	public float OrbsDistanceWithPlayer = 40.0f;
	public float OrbsRotationAngularSpeed = 1.0f;
	private float OrbsCurrentAngle = 0.0f;


	private int OrbsSlotsMaxLenght = 3;
	private string [] OrbsSlots = new string[3] {"Quas", "Wex", "Exort"};

	public override void _Ready()
	{
		moveDestination = Position;

		InvokerImage = GetNode<Sprite2D>("InvokerImage");
		OrbsPos1 = GetNode<Marker2D>("OrbsStartPosition/pos1");
		OrbsPos2 = GetNode<Marker2D>("OrbsStartPosition/pos2");
		OrbsPos3 = GetNode<Marker2D>("OrbsStartPosition/pos3");

		HadOrbs = (Node2D)GetNode("HadOrbs");
		Orbs1 = (Node2D)GetNode("HadOrbs/Orbs1");
		Orbs2 = (Node2D)GetNode("HadOrbs/Orbs2");
		Orbs3 = (Node2D)GetNode("HadOrbs/Orbs3");
	}
	public override void _Process(double delta)
	{
		ChangeFacingDirection();
		GetOrbs();

		AdjustMarkPosition(delta);
		AdjustOrbsPosition();
		/*** debug section

		***/

		// GetPreviousPos must be at end of the _Process()!!!
		GetPreviousPos();
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("right_click_to_move"))
		{
			GetMovingDirection();
			if (moveDestination != Position)
			{
				isMoving = true;
			}
			else
			{
				isMoving = false;
			}
		}

		if (isMoving)
		{
			Velocity = moveDirection * moveSpeed;

			MoveAndSlide();
		}

		// check if hits the target position
		CheckProximity(moveDestination);

		if (Position == moveDestination)
		{
			isMoving = false;
		}
	}


	// animaiton and motino related functions
	private Vector2 GetMovingDirection()
	{
		moveDestination = GetGlobalMousePosition();
		moveDirection = (moveDestination - Position).Normalized();
		return moveDirection;
	}

	private void CheckProximity(Vector2 pos)
	{
		float distance = Position.DistanceTo(pos);

		if (distance < 10)
		{
			Position = pos;
		}
	}

	private void GetPreviousPos()
	{
		// save previous frame position, put at the end of _PhysicsProcess
		previousFramePos = Position;
	}

	private void ChangeFacingDirection()
	{
		if (Position.X < previousFramePos.X)
		{
			// isFacingLeft = true;
			InvokerImage.FlipH = true;
		}
		else if (Position.X > previousFramePos.X)
		{
			// isFacingLeft = false;
			InvokerImage.FlipH = false;
		}
	}

	// skill related functions
	private void GetOrbs()
	{
		if (Input.IsActionJustPressed("Quas"))
		{
			int i = 0;
			for (i = 0; i<2; i++)
			{
				OrbsSlots[i] = OrbsSlots[i + 1];
			}
			OrbsSlots[2] = "Quas";
			SetOrbsType();
		}

		if (Input.IsActionJustPressed("Wex"))
		{
			int i = 0;
			for (i = 0; i<2; i++)
			{
				OrbsSlots[i] = OrbsSlots[i + 1];
			}
			OrbsSlots[2] = "Wex";
			SetOrbsType();
		}

		if (Input.IsActionJustPressed("Exort"))
		{
			int i = 0;
			for (i = 0; i<2; i++)
			{
				OrbsSlots[i] = OrbsSlots[i + 1];
			}
			OrbsSlots[2] = "Exort";
			SetOrbsType();
		}
	}

	private void SetOrbsType()
	{
		
		EmitSignal(SignalName.SetType, OrbsSlots[0]);
	}

	private void AdjustMarkPosition(double delta)
	{

		float deg120 = 2 * (Mathf.Pi / 3);
		OrbsCurrentAngle += OrbsRotationAngularSpeed * (float)delta;

		float x_1 = OrbsDistanceWithPlayer * Mathf.Cos(OrbsCurrentAngle);
		float y_1 = OrbsDistanceWithPlayer * Mathf.Sin(OrbsCurrentAngle);
		float x_2 = OrbsDistanceWithPlayer * Mathf.Cos(OrbsCurrentAngle+deg120);
		float y_2 = OrbsDistanceWithPlayer * Mathf.Sin(OrbsCurrentAngle+deg120);
		float x_3 = OrbsDistanceWithPlayer * Mathf.Cos(OrbsCurrentAngle-deg120);
		float y_3 = OrbsDistanceWithPlayer * Mathf.Sin(OrbsCurrentAngle-deg120);

		OrbsPos1.Position = new Vector2(x_1, y_1);
		OrbsPos2.Position = new Vector2(x_2, y_2);
		OrbsPos3.Position = new Vector2(x_3, y_3);
		
	}

	private void AdjustOrbsPosition()
	{
		Orbs1.Position = OrbsPos1.Position;
		Orbs2.Position = OrbsPos2.Position;
		Orbs3.Position = OrbsPos3.Position;
	}

}
