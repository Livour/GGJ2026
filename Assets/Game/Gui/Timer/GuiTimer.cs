using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiTimer : GuiScript<GuiTimer>
{


	void Update()
	{
		Label("Countdown").Text = ((int) Globals.gameManager.TimeLeft).ToString();
    }
}