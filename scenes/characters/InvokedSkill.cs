using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class InvokedSkill : Node2D
{
	CharacterBody2D Inovker;
	Node2D SkillSlot1;
	Node2D SkillSlot2;
	Label SkillNames;
	string Skill1String = "Empty";
	string Skill2String = "Empty";
	string SkillReplacementString = "Empty";

	public string[] OrbsSlots;
	public string[] InvokedSkillSlots;
	public Dictionary<int, string> InvokeDict = new Dictionary<int, string>();

	public override void _Ready()
	{
		Inovker = (CharacterBody2D)GetNode("..");
		SkillSlot1 = (Node2D)GetNode("SkillSlot1");
		SkillSlot2 = (Node2D)GetNode("SkillSlot2");
		SkillNames = (Label)GetNode("SkillNames(debug)");

		// OrbsSlots = {"Quas", "Wex", "Exort"};
		InvokeDict.Add(300, "ColdSnap");
		InvokeDict.Add(210, "GhostWalk");
		InvokeDict.Add(201, "IceWall");
		InvokeDict.Add(30, "EMP");
		InvokeDict.Add(120, "Tornado");
		InvokeDict.Add(21, "Alacrity");
		InvokeDict.Add(3, "SunStrike");
		InvokeDict.Add(102, "ForgeSpirit");
		InvokeDict.Add(12, "ChaosMeteor");
		InvokeDict.Add(111, "DeafeningBlast");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Invoke"))
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string str in OrbsSlots)
			{
				stringBuilder.Append(str);
			}
			string builtOrbsSlots = stringBuilder.ToString();
			int InovkedNumber = CountSpells(builtOrbsSlots);

			if (InvokeDict.ContainsKey(InovkedNumber))
			{
				string InvokedSkillString = InvokeDict[InovkedNumber];
				if (Skill2String == InvokedSkillString)
				{
					SkillReplacementString = Skill1String;
					Skill1String = Skill2String;
					Skill2String = SkillReplacementString;
					SkillReplacementString = "Empty";
				}
				else if (Skill1String != InvokedSkillString & Skill2String != InvokedSkillString)
				{
					Skill2String = Skill1String;
					Skill1String = InvokedSkillString;
				}
			}
			else
			{
				GD.Print("No corresponding invoked number found in dict!");
			}

			SkillNames.Text = InovkedNumber + Skill1String + Skill2String;
		}
	}
	public void _on_invoker_get_orbs_slots(string[] OS)
	{
		OrbsSlots = SetOrbsSlots(OS);
	}

	private string[] SetOrbsSlots(string[] OS)
	{
		string[] OrbsSlotsi = OS;
		return OrbsSlotsi;
	}

	private int CountSpells(string inputString)
	{
		int count = 0;
		foreach (char c in inputString)
		{
			if (c == 'Q')
			{
				count += 100;
			}
			else if (c == 'W')
			{
				count += 10;
			}
			else if (c == 'E')
			{
				count += 1;
			}
		}
		return count;
	}
}
