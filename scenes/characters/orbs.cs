using Godot;
using System;

public partial class orbs : Node2D
{
	public string type;
	public string[] orbsType = new string[3];
	
	// public Array typeArray = ["quas", "wex", "exort"];
	// public string quas = 'quas';
	public override void _Ready()
	{
		orbsType[0] = "quas";
		orbsType[1] = "wex";
		orbsType[2] = "exort";
	}

	public void SetOrbType(string orbType)
	{
		type = orbType;
	}


}
