using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomLevel1 : RoomScript<RoomLevel1>
{
	public readonly int NumOfMasks = 6;
	public readonly int NumOfHouses = 4;
	public readonly int RunDurationSeconds = 120;

    IEnumerator OnEnterRoomAfterFade()
	{
		HandleNewGame();
        yield return E.Break;
	}
	
	void HandleNewGame()
	{
        Globals.gameManager.StartRun(NumOfHouses, NumOfMasks, RunDurationSeconds);
        Globals.OnNewGame();
    }
	IEnumerator HandleHouseInteract(int houseIndex)
	{
		yield return C.WalkToClicked();
		var result = Globals.OnVisitHouse(houseIndex);
		Debug.Log("res: "+result);
        if (result == ActionResult.AlreadyVisited)
		{
			GuiPrompt.Script.Show("Game Over, Start new game?", "Yes", "Return to title", () =>
			{
				HandleNewGame();
			}, () =>
			{
				E.ChangeRoomBG(R.Title);
			});

            Debug.Log("Game Over - Already Visited");
        }
		else if(result == ActionResult.IllegalMove)
		{
			yield return C.Display("You cannot visit the same house twice in a row!");
			Debug.Log("Illegal Move - Same House");
        }
        yield return E.Break;
    }

    IEnumerator OnInteractPropHouse1( IProp prop )
	{
        yield return E.WaitFor(() => HandleHouseInteract(0));
    }

	IEnumerator OnInteractPropHouse2( IProp prop )
	{
        yield return E.WaitFor(() => HandleHouseInteract(1));
    }

	IEnumerator OnInteractPropHouse3( IProp prop )
	{
		yield return E.WaitFor(()=> HandleHouseInteract(2) );
		
		yield return E.Break;
	}

	IEnumerator OnInteractPropHouse4( IProp prop )
	{
		yield return E.WaitFor(()=> HandleHouseInteract(3) );
		
		yield return E.Break;
	}
}