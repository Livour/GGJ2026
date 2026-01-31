using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomLore : RoomScript<RoomLore>
{


	IEnumerator OnInteractPropNovel1( IProp prop )
	{
		prop.Disable();
		yield return E.Break;
	}

    IEnumerator OnInteractPropNovel2(IProp prop)
    {
        prop.Disable();
        yield return E.Break;
    }

    IEnumerator OnInteractPropNovel3(IProp prop)
    {
        prop.Disable();
        yield return E.Break;
    }

    IEnumerator OnInteractPropNovel4(IProp prop)
    {
        E.ChangeRoom(R.Level1);
        prop.Disable();
        yield return E.Break;
    }

	IEnumerator OnLookAtPropNovel3( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnUseInvPropNovel3( IProp prop, IInventory item )
	{

		yield return E.Break;
	}
}