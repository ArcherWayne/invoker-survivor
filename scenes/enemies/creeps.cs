using Godot;
using System;

public partial class creeps : CharacterBody2D
{
	private globals globals;
	private CharacterBody2D player;
	private Sprite2D CreepImage;


	private float creepMaxHealth;
	private float creepCurrentHealth;
	private float creepMoveSpeed;
	private float creepAttackDamage;
	// private bool isFacingRight = true;
	private Vector2 playerPosition;
	private Vector2 moveDestination;
	private Vector2 moveDirection;

	public override void _Ready()
	{
		globals = (globals)GetNode("/root/Globals");

		player = (CharacterBody2D)GetNode("/root/Level/Invoker");
		CreepImage = (Sprite2D)GetNode("CreepImage");

		creepMaxHealth = globals.creepMaxHealth;
		creepCurrentHealth = creepMaxHealth;
		creepMoveSpeed = globals.creepMoveSpeed;
		creepAttackDamage = globals.creepAttackDamage;
	}

	public override void _Process(double delta)
	{
		playerPosition = GetPlayerPosition();
		CheckingFacingDirection();
		GetMoveDirectionToPlayer();
		CheckHealth();
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = moveDirection * globals.creepMoveSpeed;
		MoveAndSlide();
	}

	private Vector2 GetPlayerPosition()
	{
		playerPosition = player.GlobalPosition;
		return playerPosition;
	}

	private void CheckingFacingDirection()
	{
		if (playerPosition.X <= Position.X)
		{
			// isFacingRight = false;
			CreepImage.FlipH = true;
		}
		else
		{
			// isFacingRight = true;
			CreepImage.FlipH = false;
		}
	}

	private Vector2 GetMoveDirectionToPlayer()
	{
		moveDestination = playerPosition;
		moveDirection = (moveDestination - Position).Normalized();
		return moveDirection;
	}

	public void TakeDamage()
	{
		// GD.Print("TakeDamage");
		creepCurrentHealth -= globals.inovkerAttackDamage;
	}
	
	private void CheckHealth()
	{
		if (creepCurrentHealth <= 0)
		{
			QueueFree();
			globals.invokerExperience += globals.creepExperienceGiveToPlayer;
			GD.Print(globals.invokerExperience);
			GD.Print(globals.invokerLevel);
		}
	}
	
	

}
