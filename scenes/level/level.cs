using Godot;
using System;

public partial class level : Node2D
{
	private PackedScene OrbsScene;
	private Node2D HadOrbs;

	public override void _Ready()
	{
		OrbsScene = (PackedScene)ResourceLoader.Load("res://scenes/characters/orbs.tscn");
		HadOrbs = (Node2D)GetNode("HadOrbs");

	}

	public void OnInvokerGetQuas(Vector2 pos)
	{
		Node2D Orbs = (Node2D)OrbsScene.Instantiate();
		Orbs.Position = pos;
		HadOrbs.AddChild(Orbs);
		// FIXME: no image?
	}

	public void OnInvokerGetWex(Vector2 pos)
	{
		GD.Print("w");
		Node2D Orbs = (Node2D)OrbsScene.Instantiate();
		Orbs.Position = pos;
		HadOrbs.AddChild(Orbs);
	}
	
	public void OnInvokerGetExort(Vector2 pos)
	{
		GD.Print("e");
		Node2D Orbs = (Node2D)OrbsScene.Instantiate();
		Orbs.Position = pos;
		HadOrbs.AddChild(Orbs);
	}
}
