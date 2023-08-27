using Godot;
using System;
using System.Security.Cryptography.X509Certificates;


public partial class invoker : CharacterBody2D
{
	[Export]
	private int moveSpeed = 525;


	// get nodes
	Sprite2D InvokerImage;

	// movment related parameters
	private bool isMoving = false;
	private Vector2 moveDestination;
	private Vector2 moveDirection;

	private Vector2 previousFramePos;

	// animation related parameters
	private bool isFacingLeft = false;

	public override void _Ready()
	{
		moveDestination = Position;

		InvokerImage = GetNode<Sprite2D>("InvokerImage");
	}
	public override void _Process(double delta)
	{
		if (Position.X < previousFramePos.X)
		{
			isFacingLeft = true;
			InvokerImage.FlipH = true;
		}
		else if (Position.X > previousFramePos.X)
		{
			isFacingLeft = false;
			InvokerImage.FlipH = false;
		}

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
				ChangeFacingDirection(moveDestination);
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


	// skill related functions
	private void GetOrbs()
	{
		if (Input.IsActionJustPressed("quas"))
		{

		}

		if (Input.IsActionJustPressed("wex"))
		{

		}

		if (Input.IsActionJustPressed("exort"))
		{

		}
	}
}
