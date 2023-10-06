using Godot;
using System;

public partial class globals : Node
{
	// invoker related parameters
	public float invokerMaxHealth = 550;
	public float invokerCurrentHealth = 550;
	public float invokerMana = 300;
	public float invokerExperience = 0;
	public int invokerStrength = 10;
	public int invokerAgility = 10;
	public int invokerIntellengence = 10;
	public float inovkerAttackDamage = 50;
	public float inovkerAttackInterval = 0.5f;
	public float inovkerAmour = 10;
	public int invokerMoveSpeed = 325;

	// creep related parameters
	public float creepMaxHealth = 200;
	public float creepMoveSpeed = 500;
	public float creepAttackDamage = 10;
}
