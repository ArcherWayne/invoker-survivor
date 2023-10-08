using Godot;
using System;

public partial class level : Node2D
{
	private Node2D HadOrbs;
	private CharacterBody2D Invoker;
	private Node2D projectile;
	private Node Creeps;

	private PackedScene AutoAttackScene;
	private PackedScene CreepsScene;
	private bool CanAutoAttack = true;

	public override void _Ready()
	{
		AutoAttackScene = (PackedScene)ResourceLoader.Load("res://scenes/characters/autoAttack.tscn");
		CreepsScene = (PackedScene)ResourceLoader.Load("res://scenes/enemies/creeps.tscn");

		Invoker = (CharacterBody2D)GetNode("Invoker");
		projectile = (Node2D)GetNode("projectiles");
		Creeps = (Node)GetNode("Creeps");
	}

	public override void _Process(double delta)
	{
	}

	public void _on_invoker_left_click(Vector2 direction, Vector2 position)
	{
		if (CanAutoAttack)
		{
			Area2D autoAttack = (Area2D)AutoAttackScene.Instantiate();
			autoAttack.Position = position;
			// autoAttack.LinearVelocity = direction * autoAttackTrajectorySpeed;
			autoAttack.Rotation = direction.Angle();
			projectile.AddChild(autoAttack);
			CanAutoAttack = false;
		}
	}

	public void _on_auto_attack_interval_timeout()
	{
		CanAutoAttack = true;
	}

	public void _on_creep_spawn_timer_timeout()
	{
		CharacterBody2D creep = (CharacterBody2D)CreepsScene.Instantiate();
		// creep.Position = Invoker.Position;
		Creeps.AddChild(creep);

		float randomValue = GD.Randf();
		float minAngle = 0f;
		float maxAngle = 360f;
		float randomAngle = Mathf.Lerp(minAngle, maxAngle, randomValue);

		float distanceWithPlayer = 1000;
		Vector2 positionRelativeToPlayer = new Vector2();
		positionRelativeToPlayer.X = distanceWithPlayer * Mathf.Cos(randomAngle);
		positionRelativeToPlayer.Y = distanceWithPlayer * Mathf.Sin(randomAngle);

		creep.Position = Invoker.Position + positionRelativeToPlayer;
	}

}
