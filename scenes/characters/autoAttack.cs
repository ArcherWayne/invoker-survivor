using Godot;
using System;

public partial class autoAttack : Area2D
{
	private globals globals;

	private float speed;
	private Vector2 direction;
	private Vector2 deltaPosition;
	private Color QuasColor = new Color(0.314f, 0.592f, 0.765f);
	private Color WexColor = new Color(1f, 0.686f, 1f);
	private Color ExortColor = new Color(0.992f, 0.588f, 0.22f);
	private Color WhiteColor = new Color(0, 0, 0);

	public override void _Ready()
	{
		globals = GetNode<globals>("/root/Globals");
		speed = globals.invokerAttackProjectileSpeed;
	}

	public override void _Process(double delta)
	{
		deltaPosition.X = speed * (float)delta * Mathf.Cos(Rotation);
		deltaPosition.Y = speed * (float)delta * Mathf.Sin(Rotation);
		Position += deltaPosition;
		// Position += direction * speed * (float)delta;
	}


	private void _on_timer_timeout()
	{
		QueueFree();
	}

	private void _on_body_entered(Node body)
	{
		if (body.IsInGroup("creeps"))
		{
			QueueFree();
			body.Call("TakeDamage");
		}
	}
}
