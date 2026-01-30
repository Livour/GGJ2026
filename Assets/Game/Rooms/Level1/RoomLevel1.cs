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
		Globals.gameManager.StartRun(NumOfHouses,NumOfMasks,RunDurationSeconds);
        yield return E.Break;
	}
	IEnumerator HandleGameOver() {
        // Handle game over logic here
        yield return E.Break;
    }

	IEnumerator OnInteractHotspotHouse1( IHotspot hotspot )
	{
		Globals.OnVisitHouse(0, HandleGameOver);
        yield return E.Break;
	}

	IEnumerator OnInteractHotspotHouse2( IHotspot hotspot )
	{
        Globals.OnVisitHouse(1, HandleGameOver);
        yield return E.Break;
	}

	IEnumerator OnInteractHotspotHouse3( IHotspot hotspot )
	{
        Globals.OnVisitHouse(2, HandleGameOver);
        yield return E.Break;
	}

	IEnumerator OnInteractHotspotHouse4( IHotspot hotspot )
	{
        Globals.OnVisitHouse(3, HandleGameOver);
        yield return E.Break;
	}
}