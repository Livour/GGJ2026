using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiScore : GuiScript<GuiScore>
{


	void Update()
	{
		
		Label("ScoreCounter").Text = ((int) Globals.gameManager.Candies).ToString();
		
	}
}