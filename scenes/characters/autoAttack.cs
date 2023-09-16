using Godot;
using System;

public partial class autoAttack : RigidBody2D
{
	private Color QuasColor = new Color(0.314f, 0.592f, 0.765f);
	private Color WexColor = new Color(1f, 0.686f, 1f);
	private Color ExortColor = new Color(0.992f, 0.588f, 0.22f);
	private Color WhiteColor = new Color(0, 0, 0);

	public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{

	}

	public override void _PhysicsProcess(double delta)
	{

	}

	private void _on_timer_timeout()
	{
		QueueFree();
	}

}
