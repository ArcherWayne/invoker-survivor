using Godot;
using System;

public partial class orbs : Node2D
{


	[Export]
	public string type { get; set; }
	// {
	// 	get
	// 	{
	// 		return type;
	// 	}
	// 	set
	// 	{
	// 		type = value;
	// 	}
	// }
	// public string AccessType


	public string[] orbsTypeArray = new string[3];

	private Node2D OrbsImage;

	
	public override void _Ready()
	{
		OrbsImage = (Node2D)GetNode("OrbsImage");

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
				OrbsImage.Modulate = new Color(0.314f, 0.592f, 0.765f);
				break;
			case "Wex" :
				OrbsImage.Modulate = new Color(1f, 0.686f, 1f);
				break;
			case "Exort" :
				OrbsImage.Modulate = new Color(0.992f, 0.588f, 0.22f);
				break;

			default :
				OrbsImage.Modulate = new Color(0, 0, 0);
				break;
		}
	}

	public void _on_invoker_orb_1_set_type(string AssignedType)
	{
		type = AssignedType;
	}


}
