using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiCurrentMask : GuiScript<GuiCurrentMask>
{


	void Update()
	{
		if (Globals.currentMask == null)
		{
			return;
		}
		else
		{
            Image("Mask").Anim = Globals.currentMask;
        }
	}
}