using Godot;
using System;

public partial class InvokedSkill : Node2D
{
	CharacterBody2D Inovker;
	public string[] OrbsSlots;

	public override void _Ready()
	{
		// OrbsSlots = ["Quas", "Wex", "Exort"];
		Inovker = (CharacterBody2D)GetNode("..");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Invoke"))
		{

		}
	}
	public void _on_invoker_get_orbs_slots(string[] OS)
	{
		var OrbsSlots = OS;
		GD.Print(OrbsSlots);
	}
}
