using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PowerTools.Quest;

namespace PowerScript
{	
	// Shortcut access to SystemAudio.Get
	public class Audio : SystemAudio
	{
	}

	public static partial class C
	{
		// Access to specific characters (Auto-generated)
		public static ICharacter Main           { get { return PowerQuest.Get.GetCharacter("Main"); } }
		public static ICharacter Narrator       { get { return PowerQuest.Get.GetCharacter("Narrator"); } }
		// #CHARS# - Do not edit this line, it's used by the system to insert characters
	}

	public static partial class I
	{		
		// Access to specific Inventory (Auto-generated)
		public static IInventory VampireMask    { get { return PowerQuest.Get.GetInventory("VampireMask"); } }
		public static IInventory GhostMask      { get { return PowerQuest.Get.GetInventory("GhostMask"); } }
		public static IInventory ZombieMask     { get { return PowerQuest.Get.GetInventory("ZombieMask"); } }
		// #INVENTORY# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	public static partial class G
	{
		// Access to specific gui (Auto-generated)
		public static IGui DialogTree     { get { return PowerQuest.Get.GetGui("DialogTree"); } }
		public static IGui SpeechBox      { get { return PowerQuest.Get.GetGui("SpeechBox"); } }
		public static IGui HoverText  { get { return PowerQuest.Get.GetGui("HoverText"); } }
		public static IGui DisplayBox    { get { return PowerQuest.Get.GetGui("DisplayBox"); } }
		public static IGui Prompt         { get { return PowerQuest.Get.GetGui("Prompt"); } }
		public static IGui Toolbar          { get { return PowerQuest.Get.GetGui("Toolbar"); } }
		public static IGui Options        { get { return PowerQuest.Get.GetGui("Options"); } }
		public static IGui Save           { get { return PowerQuest.Get.GetGui("Save"); } }
		public static IGui Timer          { get { return PowerQuest.Get.GetGui("Timer"); } }
		public static IGui Score          { get { return PowerQuest.Get.GetGui("Score"); } }
		public static IGui ClickToContinue { get { return PowerQuest.Get.GetGui("ClickToContinue"); } }
		public static IGui LevelTopGui    { get { return PowerQuest.Get.GetGui("LevelTopGui"); } }
        public static IGui CurrentMask { get { return PowerQuest.Get.GetGui("CurrentMask"); } }
        // #GUI# - Do not edit this line, it's used by the system to insert rooms for easy access
    }

	public static partial class R
	{
		// Access to specific room (Auto-generated)
		public static IRoom Level1          { get { return PowerQuest.Get.GetRoom("Level1"); } }
		public static IRoom Lore           { get { return PowerQuest.Get.GetRoom("Lore"); } }
		public static IRoom Title    { get { return PowerQuest.Get.GetRoom("Title"); } }
		// #ROOM# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	// Dialog
	public static partial class D
	{
		// Access to specific dialog trees (Auto-generated)
		// #DIALOG# - Do not edit this line, it's used by the system to insert rooms for easy access	    	    
	}


}
