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

	public override void _Ready()
	{
		globals = GetNode<globals>("/root/Globals");

		HealthPoint = GetNode<ProgressBar>("BottomArea/HBoxContainer/BarAndSkillIcons/HealthPoint");
		HealthValueLabel = GetNode<Label>("BottomArea/HBoxContainer/BarAndSkillIcons/HealthPoint/HealthValueLabel");
		ManaPoint = GetNode<ProgressBar>("BottomArea/HBoxContainer/BarAndSkillIcons/ManaPoint");
		ManaValueLabel = GetNode<Label>("BottomArea/HBoxContainer/BarAndSkillIcons/ManaPoint/ManaValueLabel");

		LevelLabel = GetNode<Label>("BottomArea/HBoxContainer/PlayerHead/LevelLabel");
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
		ManaPoint.Value = globals.inovkerCurrentMana;
		int MaxManaPointLabel = (int)globals.invokerMaxMana;
		int CurrentManaPointLabel = (int)globals.inovkerCurrentMana;
		string ManaValueText = CurrentManaPointLabel.ToString() + "/" + MaxManaPointLabel.ToString();
		ManaValueLabel.Text = ManaValueText;

		LevelLabel.Text = "Level = " + globals.invokerLevel.ToString();
	}
}
