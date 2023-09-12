using Godot;
using System;

public partial class orbs : Node2D
{


	[Export]
	public string type { get; set; }


	// Orbs related 
	public string[] orbsTypeArray = new string[3];

	private Color QuasColor = new Color(0.314f, 0.592f, 0.765f);
	private Color WexColor = new Color(1f, 0.686f, 1f);
	private Color ExortColor = new Color(0.992f, 0.588f, 0.22f);
	private Color WhiteColor = new Color(0, 0, 0);

	private Node2D OrbsImage;
	private GpuParticles2D OrbsParticle;
	private GpuParticles2D ChangedParticle;

	
	public override void _Ready()
	{
		var OrbsScene = (PackedScene)ResourceLoader.Load("res://scenes/characters/orbs.tscn");
		// OrbsImage = (Node2D)GetNode("OrbsImage");
		// OrbsParticle = (GpuParticles2D)GetNode("OrbsParticle");
		// ChangedParticle = (GpuParticles2D)GetNode("ChangedParticle");

		orbsTypeArray[0] = "Quas";
		orbsTypeArray[1] = "Wex";
		orbsTypeArray[2] = "Exort";

		Random rand = new Random();
		int randomIndex = rand.Next(0, orbsTypeArray.Length);

		type = orbsTypeArray[randomIndex];
	}

	public override void _Process(double delta)
	{
		SetOrbColor();
	}


	public void SetOrbColor()
	{
		switch(type){
			case "Quas" :
				SetModulate(QuasColor);
				break;
			case "Wex" :
				SetModulate(WexColor);
				break;
			case "Exort" :
				SetModulate(ExortColor);
				break;

			default :
				SetModulate(WhiteColor);
				break;
		}
	}

	public void _on_invoker_orb_set_type(string AssignedType)
	{
		type = AssignedType;
	}
	
	private void SetModulate(Color color)
	{
		OrbsImage.Modulate = color;
		OrbsParticle.Modulate = color;
		ChangedParticle.Modulate = color;
	}
}
