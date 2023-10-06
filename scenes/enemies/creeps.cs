using Godot;
using System;

public partial class creeps : CharacterBody2D
{
	private globals globals;
	private float creepMaxHealth;
	private float creepMoveSpeed;
	private float creepAttackDamage;

	public override void _Ready()
	{
		globals = (globals)GetNode("/root/Globals");

		creepMaxHealth = globals.creepMaxHealth;
		creepMoveSpeed = globals.creepMoveSpeed;
		creepAttackDamage = globals.creepAttackDamage;
	}

	public override void _Process(double delta)
	{

	}
}
