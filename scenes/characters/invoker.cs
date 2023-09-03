using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


public partial class invoker : CharacterBody2D
{
	// [Signal]
	// public delegate void SetTypeEventHandler();

	[Export]
	private int moveSpeed = 525;


	// get nodes
	private Sprite2D InvokerImage;

	// movment related parameters
	private bool isMoving = false;
	private Vector2 moveDestination;
	private Vector2 moveDirection;

	private Vector2 previousFramePos;

	// animation related parameters
	// private bool isFacingLeft = false;

	// orb related parameters
	// private PackedScene OrbsScene;
	// private Node2D OrbsStartPosition;
	private Node2D HadOrbs;
	private Marker2D OrbsPos1;
	private Marker2D OrbsPos2;
	private Marker2D OrbsPos3;

	private Node2D Orbs1;
	private Node2D Orbs2;
	private Node2D Orbs3;

	[Export]
	public float OrbsDistanceWithPlayer = 40.0f;
	[Export]
	public float OrbsRotationAngularSpeed = 1.0f;
	private float OrbsCurrentAngle = 0.0f;

	[Signal]
	public delegate void Orb1SetTypeEventHandler(string type);
	[Signal]
	public delegate void Orb2SetTypeEventHandler(string type);
	[Signal]
	public delegate void Orb3SetTypeEventHandler(string type);

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

		// OrbsDistanceWithPlayer = 40;
		// OrbsRotationAngularSpeed = 30;
	}
	public override void _Process(double delta)
	{
		ChangeFacingDirection();
		GetOrbs();
		SetOrbsType();

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
		}

		if (Input.IsActionJustPressed("Wex"))
		{
			int i = 0;
			for (i = 0; i<2; i++)
			{
				OrbsSlots[i] = OrbsSlots[i + 1];
			}
			OrbsSlots[2] = "Wex";
		}

		if (Input.IsActionJustPressed("Exort"))
		{
			int i = 0;
			for (i = 0; i<2; i++)
			{
				OrbsSlots[i] = OrbsSlots[i + 1];
			}
			OrbsSlots[2] = "Exort";
		}
		GD.Print(OrbsSlots);
	}

	private void SetOrbsType()
	{
		EmitSignal(SignalName.Orb1SetType, OrbsSlots[0]);
		EmitSignal(SignalName.Orb2SetType, OrbsSlots[1]);
		EmitSignal(SignalName.Orb3SetType, OrbsSlots[2]);
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
