using Godot;
using System;
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
	private PackedScene OrbsScene;
	// private Node2D OrbsStartPosition;
	private Node2D HadOrbs;
	private Marker2D OrbsPos1;
	private Marker2D OrbsPos2;
	private Marker2D OrbsPos3;

	private string[] OrbSlots = new string[3];

	public override void _Ready()
	{
		moveDestination = Position;

		InvokerImage = GetNode<Sprite2D>("InvokerImage");
		OrbsPos1 = GetNode<Marker2D>("OrbsStartPosition/pos1");
		OrbsPos2 = GetNode<Marker2D>("OrbsStartPosition/pos2");
		OrbsPos3 = GetNode<Marker2D>("OrbsStartPosition/pos3");

		HadOrbs = (Node2D)GetNode("HadOrbs");

		// OrbsStartPosition = (Node2D)GetNode("OrbsStartPosition");

		OrbsScene = (PackedScene)ResourceLoader.Load("res://scenes/characters/orbs.tscn");


	}
	public override void _Process(double delta)
	{
		ChangeFacingDirection();
		GetOrbs();

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
			GD.Print("q");
			Node2D Orbs = (Node2D)OrbsScene.Instantiate();
			Orbs.Position = OrbsPos1.Position;
			HadOrbs.AddChild(Orbs);
		}

		if (Input.IsActionJustPressed("Wex"))
		{
			GD.Print("w");
			Node2D Orbs = (Node2D)OrbsScene.Instantiate();
			Orbs.Position = OrbsPos2.Position;
			HadOrbs.AddChild(Orbs);
		}

		if (Input.IsActionJustPressed("Exort"))
		{
			GD.Print("e");
			Node2D Orbs = (Node2D)OrbsScene.Instantiate();
			Orbs.Position = OrbsPos3.Position;
			HadOrbs.AddChild(Orbs);
		}
	}
}
