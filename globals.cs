using Godot;
using System;

public partial class globals : Node
{
	// invoker related parameters
	// health and mana
	public float invokerMaxHealth = 550;
	public float invokerCurrentHealth = 550;
	public float invokerMaxMana = 300;
	public float invokerCurrentMana = 150;

	public float invokerTakeDamageRange = 50;

	// atributes
	public int invokerStrength = 10;
	public int invokerAgility = 10;
	public int invokerIntellengence = 10;

	// skills
	public int invokerQuasLevel = 0;
	public int invokerWexLevel = 0;
	public int invokerExortLevel = 0;
	public string invokerSkill1String;
	public string invokerSkill2String;

	// level and experience
	public int invokerLevel = 1;
	public int invokerExperience = 0;

	// auto attack
	public float invokerAttackDamage = 100;
	public float invokerAttackInterval = 0.5f;
	public float invokerAttackProjectileSpeed = 400;

	// amour, movement speed
	public float invokerAmour = 10;
	public int invokerMoveSpeed = 325;

	// creep related parameters
	public float creepSpawnInterval = 0.5f;
	public float creepMaxHealth = 200;
	public float creepMoveSpeed = 100;
	public float creepKnockBackSpeed = -300;
	public float creepKnockBackReturn = 5;
	public float creepAttackDamage = 10;
	public int creepLevel = 1;
	public int creepExperienceGiveToPlayer = 50;

	public override void _Process(double delta)
	{
		for (int i = 1; i <= 9999; i++)
		{	
			if (invokerExperience >= 100*i && invokerExperience < 100*(i+1))
			{
				invokerLevel = i;
				break;
			}
		}
	}
}
