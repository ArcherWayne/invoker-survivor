using Godot;
using System;

public partial class level : Node2D
{
	// private PackedScene OrbsScene;
	private Node2D HadOrbs;
	private CharacterBody2D Invoker;

	public override void _Ready()
	{
		// OrbsScene = (PackedScene)ResourceLoader.Load("res://scenes/characters/orbs.tscn");
		// HadOrbs = (Node2D)GetNode("HadOrbs");

		Invoker = (CharacterBody2D)GetNode("Invoker");

	}

	// public void OnInvokerGetQuas(Vector2 pos)
	// {
		// Node2D Orbs = (Node2D)OrbsScene.Instantiate();
		// Orbs.Position = pos;
		// HadOrbs.AddChild(Orbs);
	// }

	// public void OnInvokerGetWex(Vector2 pos)
	// {
	// 	Node2D Orbs = (Node2D)OrbsScene.Instantiate();
	// 	Orbs.Position = pos;
	// 	HadOrbs.AddChild(Orbs);
	// }
	
	// public void OnInvokerGetExort(Vector2 pos)
	// {
	// 	Node2D Orbs = (Node2D)OrbsScene.Instantiate();
	// 	Orbs.Position = pos;
	// 	HadOrbs.AddChild(Orbs);
	// }
}
