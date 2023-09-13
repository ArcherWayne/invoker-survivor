using Godot;
using System;

public partial class level : Node2D
{
	private Node2D HadOrbs;
	private CharacterBody2D Invoker;
	private Node2D projectile;

	private PackedScene AutoAttackScene;
	private int autoAttackTrajectorySpeed = 400;
	private bool CanAutoAttack = true;

	public override void _Ready()
	{
		// OrbsScene = (PackedScene)ResourceLoader.Load("res://scenes/characters/orbs.tscn");
		// HadOrbs = (Node2D)GetNode("HadOrbs");

		AutoAttackScene = (PackedScene)ResourceLoader.Load("res://scenes/characters/autoAttack.tscn");
		Invoker = (CharacterBody2D)GetNode("Invoker");
		projectile = (Node2D)GetNode("projectiles");

	}

	public override void _Process(double delta)
	{
	}

	public void _on_invoker_left_click(Vector2 direction, Vector2 position)
	{
		if (CanAutoAttack)
		{
			RigidBody2D autoAttack = (RigidBody2D)AutoAttackScene.Instantiate();
			autoAttack.Position = position;
			autoAttack.LinearVelocity = direction * autoAttackTrajectorySpeed;
			autoAttack.Rotation = direction.Angle();
			projectile.AddChild(autoAttack);
			CanAutoAttack = false;
		}
	}

	public void _on_auto_attack_interval_timeout()
	{
		CanAutoAttack = true;
	}

}
