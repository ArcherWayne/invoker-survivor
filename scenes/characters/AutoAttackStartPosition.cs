using Godot;
using System;

public partial class AutoAttackStartPosition : Node2D
{
	float distanceWithInvoker = 35;
	Marker2D AttackStartMarker;
	
	public override void _Ready()
	{
		AttackStartMarker = (Marker2D)GetNode("./AttackStartMarker");
	}

	public override void _Process(double delta)
	{
		UpdateStartMarkerPosition();
	}

	public void UpdateStartMarkerPosition()
	{
		Vector2 UpdatePosition = new Vector2();
		Vector2 facingDirection = (GetGlobalMousePosition() - Position).Normalized();
		var angle = facingDirection.Angle();

		UpdatePosition.X = distanceWithInvoker * Mathf.Cos(angle);
		UpdatePosition.Y = distanceWithInvoker * Mathf.Sin(angle);

		AttackStartMarker.Position = UpdatePosition;
		// GD.Print(Position);
	}
}
