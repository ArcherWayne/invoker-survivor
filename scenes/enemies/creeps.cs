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
	private float creepKnockBackSpeed;
	// private float creepSpeedBeforeKnockBack;
	private float creepAttackDamage;
	private Vector2 playerPosition;
	private float playerDistance;
	private Vector2 moveDestination;
	private Vector2 moveDirection;

	public override void _Ready()
	{
		AddToGroup("creeps");

		globals = (globals)GetNode("/root/Globals");

		player = (CharacterBody2D)GetNode("/root/Level/Invoker");
		CreepImage = (Sprite2D)GetNode("CreepImage");

		creepMaxHealth = globals.creepMaxHealth;
		creepCurrentHealth = creepMaxHealth;
		creepMoveSpeed = globals.creepMoveSpeed;
		creepAttackDamage = globals.creepAttackDamage;
		creepKnockBackSpeed = globals.creepKnockBackSpeed;

		// GD.Print(Name);
	}

	public override void _Process(double delta)
	{
		playerPosition = GetPlayerPosition();
		playerDistance = GetDistanceWithPlayer();
		CheckingFacingDirection();
		GetMoveDirectionToPlayer();
		CheckHealth();
		CheckDistanceWithPlayer();
		creepMoveSpeed = ReturnToOriginalSpeed();

		GD.Print(creepMoveSpeed);
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = moveDirection * creepMoveSpeed;
		MoveAndSlide();
	}

	private Vector2 GetPlayerPosition()
	{
		playerPosition = player.GlobalPosition;
		return playerPosition;
	}

	private float GetDistanceWithPlayer()
	{
		Vector2 playerDistanceVector = playerPosition - Position;
		playerDistance = playerDistanceVector.Length();
		return playerDistance;
	}

	private void CheckingFacingDirection()
	{
		if (playerPosition.X <= Position.X)
		{
			CreepImage.FlipH = true;
		}
		else
		{
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
		creepCurrentHealth -= globals.invokerAttackDamage;
	}
	
	private void CheckHealth()
	{
		if (creepCurrentHealth <= 0)
		{
			QueueFree();
			globals.invokerExperience += globals.creepExperienceGiveToPlayer;
		}
	}

	private void CheckDistanceWithPlayer()
	{
		if (playerDistance <= globals.invokerTakeDamageRange)
		{
			player.Call("TakeCreepDamage");
			SetKnockBack();
			// TakeDamage();
		}
	}

	private void SetKnockBack()
	{
		// creepSpeedBeforeKnockBack = creepMoveSpeed;
		creepMoveSpeed += creepKnockBackSpeed;
	}

	private float ReturnToOriginalSpeed()
	{
		if (creepMoveSpeed < globals.creepMoveSpeed - 20)
		{
			creepMoveSpeed += globals.creepKnockBackReturn;
		}
		else if (creepMoveSpeed > globals.creepMoveSpeed + 20)
		{
			creepMoveSpeed -= globals.creepKnockBackReturn;
		}
		else if ( - 20 <= creepMoveSpeed && creepMoveSpeed <= globals.creepMoveSpeed + 20)
		{
			creepMoveSpeed = globals.creepMoveSpeed;
		}
		
		return creepMoveSpeed;
	}
}
