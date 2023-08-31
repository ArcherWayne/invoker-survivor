using Godot;
using System;

public partial class orbs : Node2D
{


	[Export]
	public string type;

	public string[] orbsTypeArray = new string[3];

	private Node2D OrbsImage;
	
	public override void _Ready()
	{
		OrbsImage = (Node2D)GetNode("OrbsImage");

		orbsTypeArray[0] = "quas";
		orbsTypeArray[1] = "wex";
		orbsTypeArray[2] = "exort";
	}

	public override void _Process(double delta)
	{
		SetOrbColor();

	}

	public void SetOrbType(string orbType)
	{
		if (Array.IndexOf(orbsTypeArray, orbType) != -1)
		{
			type = orbType;
		}
		else
		{

		}
	}

	public void SetOrbColor()
	{
		switch(type){
			case "quas" :
				OrbsImage.Modulate = new Color(0, 0, 1);
				break;
			case "wex" :
				OrbsImage.Modulate = new Color(0, 1, 0);
				break;
			case "exort" :
				OrbsImage.Modulate = new Color(1, 0, 0);
				break;

			default :
				OrbsImage.Modulate = new Color(0, 0, 0);
				break;

		}
	}


}
