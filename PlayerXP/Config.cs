﻿using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PlayerXP
{
	public class Config : IConfig
	{
		[Description("Whether or not the plugin is enabled.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Whether or not debug information should be output to the console.")]
		public bool IsDebug { get; set; } = false;

		[Description("A global scaling factor for all XP values.")]
		public float XpScale { get; set; } = 1.0f;

		[Description("How much more XP it should take to get to the next level than the previous one.")]
		public int XpIncrement { get; set; } = 250;

		[Description("The text a player is shown for killing another player.")]
		public string PlayerKillMessage { get; set; } = "You have gained {xp} xp for killing {target}!";

		[Description("The text shown to a player who is killed.")]
		public string PlayerDeathMessage { get; set; } = "You were killed by {killer}, level {level}.";

		[Description("The text shown to a player when they teamkill.")]
		public string PlayerTeamkillMessage { get; set; } = "You have lost {xp} xp for teamkilling {target}.";

		[Description("The text shown to Tutorials after an SCP gets a kill.")]
		public string TutorialScpKillsPlayerMessage { get; set; } = "You have gained {xp} xp for an SCP killing an enemy!";

		[Description("The text shown to SCP-079 after another SCP gets a kill.")]
		public string Scp079AssistedKillMessage { get; set; } = "You have gained {xp} xp for another SCP killing an enemy!";

		[Description("The text shown to SCP-106 after a player dies in the pocket dimension.")]
		public string Scp106PocketDimensionDeathMessage { get; set; } = "You have gained {xp} for killing {target} in the pocket dimension!";

		[Description("The text shown to SCP-049 after they create a zombie.")]
		public string Scp049CreateZombieMessage { get; set; } = "You have gained {xp} xp for turning {target} into a zombie!";

		[Description("The text shown to a Class-D for escaping.")]
		public string DclassEscapeMessage { get; set; } = "You have gained {xp} xp for escaping as a Class-D!";

		[Description("The text shown to Chaos for a Class-D escaping.")]
		public string ChaosDclassEscapeMessage { get; set; } = "You have gained {xp} xp for {target} escaping as a Class-D!";

		[Description("The text shown to a Scientist for escaping.")]
		public string ScientistEscapeMessage { get; set; } = "You have gained {xp} xp for escaping as a Scientist!";

		[Description("The text shown to MTF for a Scientist escaping.")]
		public string MtfScientistEscapeMessage { get; set; } = "You have gained {xp} xp for {target} escaping as a Scientist!";

		// All
		public int RoundWin { get; set; } = 200;
		public int TeamKillPunishment { get; set; } = 200;

		// SCPs
		public int Scp049Kill { get; set; } = 25;
		public int Scp0492Kill { get; set; } = 25;
		public int Scp096Kill { get; set; } = 25;
		public int Scp106Kill { get; set; } = 25;
		public int Scp173Kill { get; set; } = 25;
		public int Scp939Kill { get; set; } = 25;

		// Class-D
		public int DclassScientistKill { get; set; } = 50;
		public int DclassMtfKill { get; set; } = 100;
		public int DclassScpKill { get; set; } = 200;
		public int DclassTutorialKill { get; set; } = 100;
		public int DclassEscape { get; set; } = 100;

		// Scientist
		public int ScientistDclassKill { get; set; } = 50;
		public int ScientistChaosKill { get; set; } = 100;
		public int ScientistScpKill { get; set; } = 200;
		public int ScientistTutorialKill { get; set; } = 100;
		public int ScientistEscape { get; set; } = 100;

		// MTF
		public int MtfDclassKill { get; set; } = 25;
		public int MtfChaosKill { get; set; } = 50;
		public int MtfScpKill { get; set; } = 100;
		public int MtfTutorialKill { get; set; } = 50;
		public int MtfScientistEscape { get; set; } = 25;

		// Chaos
		public int ChaosScientistKill { get; set; } = 25;
		public int ChaosMtfKill { get; set; } = 50;
		public int ChaosScpKill { get; set; } = 100;
		public int ChaosTutorialKill { get; set; } = 50;
		public int ChaosDclassEscape { get; set; } = 25;

		// Tutorial
		public int TutorialDclassKill { get; set; } = 25;
		public int TutorialScientistKill { get; set; } = 25;
		public int TutorialMtfKill { get; set; } = 50;
		public int TutorialChaosKill { get; set; } = 50;
		public int TutorialScpKillsPlayer { get; set; } = 10;

		// SCP-106
		public int Scp106PocketDeath { get; set; } = 50;

		// SCP-049
		public int Scp049ZombieCreated { get; set; } = 25;

		// SCP-079
		public int Scp079AssistedKill { get; set; } = 10;
	}
}