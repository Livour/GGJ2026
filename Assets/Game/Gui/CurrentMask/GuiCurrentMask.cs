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
			if(Globals.gameManager.ConsumeNewMask())
			{
                Image("Mask").Instance.GetComponentInChildren<ParticleSystem>().Play();
            }
            Image("Mask").Anim = Globals.currentMask;
        }
	}
}