using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomTitle : RoomScript<RoomTitle>
{


	void OnEnterRoom()
	{
		
		// Hide the inventory in the title scene
		G.CurrentMask.Hide();
		G.LevelTopGui.Hide();
		G.ClickToContinue.Hide();
		G.Timer.Hide();
		G.Score.Hide();
		C.Plr.Disable();
		
		// Later we could start some music here
		//SystemAudio.PlayMusic("MusicSlowStrings", 1);
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		
		// Start cutscene, so this can be skipped by pressing ESC
		E.StartCutscene();
		
		// Wait a moment
		yield return E.Wait(0.5f);
		
		// Turn on the "new game" prop and fade it in
		Prop("Start").Enable();
		yield return Prop("Start").Fade(0,1,1.0f);
		
		// This is the point the game will skip to if ESC is pressed
		E.EndCutscene();
		
		yield return E.Break;
	}

	IEnumerator OnInteractPropStart( IProp prop )
	{
		E.ChangeRoomBG(R.Lore);
		yield return E.ConsumeEvent;
	}
}