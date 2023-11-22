using Godot;
using System;

public partial class ui : CanvasLayer
{
	private globals globals;

	public ProgressBar HealthPoint;
	public Label HealthValueLabel;
	public ProgressBar ManaPoint;
	public Label ManaValueLabel;
	public Label LevelLabel;

	public TextureRect Skill1;
	public TextureRect Skill2;
	public TextureRect Skill3;
	public TextureRect Skill4;
	public TextureRect Skill5;
	public TextureRect Skill6;

	private Texture2D AlacrityImage;
	private Texture2D ChaosMeteorImage;
	private Texture2D ColdSnapImage;
	private Texture2D DeafeningBlastImage;
	private Texture2D EMPImage;
	private Texture2D ForgeSpiritImage;
	private Texture2D GhostWalkImage;
	private Texture2D IceWallImage;
	private Texture2D SunStrikeImage;
	private Texture2D TornadoImage;


	public override void _Ready()
	{
		globals = GetNode<globals>("/root/Globals");

		HealthPoint = GetNode<ProgressBar>("BottomArea/HBoxContainer/BarAndSkillIcons/HealthPoint");
		HealthValueLabel = GetNode<Label>("BottomArea/HBoxContainer/BarAndSkillIcons/HealthPoint/HealthValueLabel");
		ManaPoint = GetNode<ProgressBar>("BottomArea/HBoxContainer/BarAndSkillIcons/ManaPoint");
		ManaValueLabel = GetNode<Label>("BottomArea/HBoxContainer/BarAndSkillIcons/ManaPoint/ManaValueLabel");

		LevelLabel = GetNode<Label>("BottomArea/HBoxContainer/PlayerHead/LevelLabel");

		Skill1 = GetNode<TextureRect>("BottomArea/HBoxContainer/BarAndSkillIcons/SkillIcons/Skill1");
		Skill2 = GetNode<TextureRect>("BottomArea/HBoxContainer/BarAndSkillIcons/SkillIcons/Skill2");
		Skill3 = GetNode<TextureRect>("BottomArea/HBoxContainer/BarAndSkillIcons/SkillIcons/Skill3");
		Skill4 = GetNode<TextureRect>("BottomArea/HBoxContainer/BarAndSkillIcons/SkillIcons/Skill4");
		Skill5 = GetNode<TextureRect>("BottomArea/HBoxContainer/BarAndSkillIcons/SkillIcons/Skill5");
		Skill6 = GetNode<TextureRect>("BottomArea/HBoxContainer/BarAndSkillIcons/SkillIcons/Skill6");
		
		AlacrityImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Alacrity.png");
		ChaosMeteorImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Chaos Meteor.png");
		ColdSnapImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Cold Snap.png");
		DeafeningBlastImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Deafening Blast.png");
		EMPImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/EMP.png");
		ForgeSpiritImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Forge Spirit.png");
		GhostWalkImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Ghost Walk.png");
		IceWallImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Ice Wall.png");
		SunStrikeImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Sun Strike.png");
		TornadoImage = GD.Load<Texture2D>("res://assets/graphics/icons/InvokerSkills/Tornado.png");	
	}

	public override void _Process(double delta)
	{
		HealthPoint.MaxValue = globals.invokerMaxHealth;
		HealthPoint.Value = globals.invokerCurrentHealth;
		int MaxHealthPointLabel = (int)globals.invokerMaxHealth;
		int CurrentHealthPointLabel = (int)globals.invokerCurrentHealth;
		string HealthValueText = CurrentHealthPointLabel.ToString() + "/" + MaxHealthPointLabel.ToString();
		HealthValueLabel.Text = HealthValueText;

		ManaPoint.MaxValue = globals.invokerMaxMana;
		ManaPoint.Value = globals.invokerCurrentMana;
		int MaxManaPointLabel = (int)globals.invokerMaxMana;
		int CurrentManaPointLabel = (int)globals.invokerCurrentMana;
		string ManaValueText = CurrentManaPointLabel.ToString() + "/" + MaxManaPointLabel.ToString();
		ManaValueLabel.Text = ManaValueText;

		LevelLabel.Text = "Level = " + globals.invokerLevel.ToString();

		CheckInvokedSKills();
	}

	public void CheckInvokedSKills()
	{
		if (Input.IsActionJustPressed("Invoke"))
		{
			if (globals.invokerSkill1String == "ColdSnap"){ Skill4.Texture = ColdSnapImage; }
			else if (globals.invokerSkill1String == "GhostWalk"){ Skill4.Texture = GhostWalkImage; }
			else if (globals.invokerSkill1String == "IceWall"){ Skill4.Texture = IceWallImage; }
			else if (globals.invokerSkill1String == "EMP"){ Skill4.Texture = EMPImage; }
			else if (globals.invokerSkill1String == "Tornado"){ Skill4.Texture = TornadoImage; }
			else if (globals.invokerSkill1String == "Alacrity"){ Skill4.Texture = AlacrityImage; }
			else if (globals.invokerSkill1String == "SunStrike"){ Skill4.Texture = SunStrikeImage; }
			else if (globals.invokerSkill1String == "ForgeSpirit"){ Skill4.Texture = ForgeSpiritImage; }
			else if (globals.invokerSkill1String == "ChaosMeteor"){ Skill4.Texture = ChaosMeteorImage; }
			else if (globals.invokerSkill1String == "DeafeningBlast"){ Skill4.Texture = DeafeningBlastImage; }

			if (globals.invokerSkill2String == "ColdSnap"){ Skill5.Texture = ColdSnapImage; }
			else if (globals.invokerSkill2String == "GhostWalk"){ Skill5.Texture = GhostWalkImage; }
			else if (globals.invokerSkill2String == "IceWall"){ Skill5.Texture = IceWallImage; }
			else if (globals.invokerSkill2String == "EMP"){ Skill5.Texture = EMPImage; }
			else if (globals.invokerSkill2String == "Tornado"){ Skill5.Texture = TornadoImage; }
			else if (globals.invokerSkill2String == "Alacrity"){ Skill5.Texture = AlacrityImage; }
			else if (globals.invokerSkill2String == "SunStrike"){ Skill5.Texture = SunStrikeImage; }
			else if (globals.invokerSkill2String == "ForgeSpirit"){ Skill5.Texture = ForgeSpiritImage; }
			else if (globals.invokerSkill2String == "ChaosMeteor"){ Skill5.Texture = ChaosMeteorImage; }
			else if (globals.invokerSkill2String == "DeafeningBlast"){ Skill5.Texture = DeafeningBlastImage; }
		}
	}
}
