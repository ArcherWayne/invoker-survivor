using Godot;
using System;

public partial class globals : Node
{
	// invoker related parameters
	public float invokerMaxHealth = 550;
	public float invokerCurrentHealth = 550;
	public float invokerMana = 300;
	public int invokerStrength = 10;
	public int invokerAgility = 10;
	public int invokerIntellengence = 10;
	public int invokerQuasLevel = 0;
	public int invokerWexLevel = 0;
	public int invokerExortLevel = 0;
	public int invokerLevel = 1;
	public int invokerExperience = 0;
	public int invokerLevelUpCap = 100;
	public float inovkerAttackDamage = 100;
	public float inovkerAttackInterval = 0.5f;
	public float invokerAttackProjectileSpeed = 400;
	public float inovkerAmour = 10;
	public int invokerMoveSpeed = 325;

	// creep related parameters
	public float creepSpawnInterval = 0.5f;
	public float creepMaxHealth = 200;
	public float creepMoveSpeed = 100;
	public float creepAttackDamage = 10;
	public int creepLevel = 1;
	public int creepExperienceGiveToPlayer = 10;
}
