using Godot;
using System;

public partial class invoker : CharacterBody2D
{
	[Signal]
	public delegate void RightClickToMoveEventHandler(Vector2 position);
	public override void _Process(double delta)
	{
		RightClickToMove();
	}

	private void RightClickToMove()
	{
		if (Input.IsActionJustPressed("right_click_to_move"))
		{
			Position = GetGlobalMousePosition();
		}
	}

	
}
