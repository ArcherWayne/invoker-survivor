using Godot;
using System;

public partial class ui : CanvasLayer
{
	private globals globals;

	public ProgressBar HealthPoint;
	public Label HealthValue;
	public ProgressBar ManaPoint;
	public Label ManaValue;

	public override void _Ready()
	{
		globals = GetNode<globals>("/root/Globals");

		HealthPoint = GetNode<ProgressBar>("BottomArea/HBoxContainer/BarAndSkillIcons/HealthPoint");
		HealthValue = GetNode<Label>("BottomArea/HBoxContainer/BarAndSkillIcons/HealthPoint/HealthValue");
		ManaPoint = GetNode<ProgressBar>("BottomArea/HBoxContainer/BarAndSkillIcons/ManaPoint");
		ManaValue = GetNode<Label>("BottomArea/HBoxContainer/BarAndSkillIcons/ManaPoint/ManaValue");
	}

	public override void _Process(double delta)
	{
		HealthPoint.MaxValue = globals.invokerMaxHealth;
		HealthPoint.Value = globals.invokerCurrentHealth;
		int MaxHealthPointLabel = (int)globals.invokerMaxHealth;
		int CurrentHealthPointLabel = (int)globals.invokerCurrentHealth;
		string HealthValueText = CurrentHealthPointLabel.ToString() + "/" + MaxHealthPointLabel.ToString();
		HealthValue.Text = HealthValueText;
	}
}
