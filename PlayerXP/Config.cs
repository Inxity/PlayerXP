using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PlayerXP
{
	public class Config : IConfig
	{
		// --- GENERAL SETTINGS ---

		[Description("Si el plugin debe estar activado o no.")]
		public bool IsEnabled { get; set; } = true;
		[Description("Numero del servidor")]
		public int SvNumber { get; set; } = 1;

		[Description("Modo debug, que muestra distintos logs en la consola.")]
		public bool IsDebug { get; set; } = false;

		[Description("Un factor de escala global para todos los valores de XP.")]
		public float XpScale { get; set; } = 1.0f;
		[Description("Boost de EXP por VIP y Donador")]
		public float XPBoost { get; set; } = 1.15f;

		[Description("¿Cuánto más XP debería necesitar para pasar al siguiente nivel que el anterior?.")]
		public int XpIncrement { get; set; } = 250;

		// --- KARMA ---

		[Description("Si el karma esta activad o no.")]
		public bool KarmaEnabled { get; set; } = true;

		[Description("If a player's karma can exceed the maximum karma until the maximum overflow karma when escorting a detained member of the opposing team.")]
		public bool KarmaOnlyOverflowOnDisarmedEscape { get; set; } = true;

		[Description("Cuánto karma se pierde cuando un jugador mata a otro jugador que no tiene armas.")]
		public float KarmaLostOnDefenselessKill { get; set; } = 0.1f;

		[Description("Cuánto karma se gana cuando un jugador hace una buena acción.")]
		public float KarmaGainedOnGoodDeed { get; set; } = 0.05f;

		[Description("Cuánto karma se gana por acompañar a un miembro del equipo contrario detenido.")]
		public float KarmaGainedOnDisarmedEscape { get; set; } = 0.1f;

		[Description("La cantidad mínima de karma que puede tener un jugador.")]
		public float KarmaMinimum { get; set; } = 0f;

		[Description("La cantidad de karma con la que comienzan todos los jugadores.")]
		public float KarmaInitial { get; set; } = 1f;

		[Description("La cantidad máxima de karma que un jugador puede tener sin desbordamiento de karma.")]
		public float KarmaMaximum { get; set; } = 1f;

		[Description("La cantidad máxima de karma que un jugador puede tener con el desbordamiento de karma.")]
		public float KarmaMaximumOverflow { get; set; } = 1.5f;

		[Description("La cantidad de karma que un jugador debe tener para poder jugar como SCP.")]
		public float KarmaLabeledBadActor { get; set; } = 0.5f;

		// --- TRANSLATIONS ---

		[Description("The text a player is shown for killing another player.")]
		public string PlayerKillMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de EXP por matar a {target}!";

		[Description("The text shown to a player who is killed.")]
		public string PlayerDeathMessage { get; set; } = "Fuiste asesinado por {killer}, nivel: <color=F61907>{level}</color>.";

		[Description("The text shown to a player when they teamkill.")]
		public string PlayerTeamkillMessage { get; set; } = "Perdiste <color=#F61907>{xp}</color> de EXP por TK a {target}.";

		[Description("The text shown to Tutorials after an SCP gets a kill.")]
		public string TutorialScpKillsPlayerMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de EXP for an SCP killing an enemy!";

		[Description("The text shown to SCP-079 after another SCP gets a kill.")]
		public string Scp079AssistedKillMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de EXP por que un SCP de tu equipo mato a un enemigo!";

		[Description("The text shown to SCP-106 after a player dies in the pocket dimension.")]
		public string Scp106PocketDimensionDeathMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de exp por matar a {target} en la dimension de bolsillo!";

		[Description("The text shown to SCP-049 after they create a zombie.")]
		public string Scp049CreateZombieMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de exp por curar a {target} y convertirlo en un zombie!";

		[Description("The text shown to a Class-D for escaping.")]
		public string DclassEscapeMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de exp por escapar como un Class-D!";

		[Description("The text shown to Chaos for a Class-D escaping.")]
		public string ChaosDclassEscapeMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de xxp por que {target} escapo como Class-D!";

		[Description("The text shown to a Scientist for escaping.")]
		public string ScientistEscapeMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de exp por escapar como Cientifico!";

		[Description("The text shown to MTF for a Scientist escaping.")]
		public string MtfScientistEscapeMessage { get; set; } = "Ganaste <color=#32F607>{xp}</color> de exp por que {target} escapo como Cientifico!";

		// --- XP VALUES ---
		// All
		[Description("Valores de EXP.")]
		public int RoundWin { get; set; } = 200;
		public int TeamKillPunishment { get; set; } = 200;
		[Description("EXP al matar un Espia")]
		public int SpyKill { get; set; } = 75;
		[Description("EXP por asistencia de kill")]
		public int AssistKill { get; set; } = 15;
		

		// SCPs
		[Description("Cuanta EXP ganan los SCP.")]
		public int Scp049Kill { get; set; } = 25;
		public int Scp0492Kill { get; set; } = 25;
		public int Scp096Kill { get; set; } = 25;
		public int Scp106Kill { get; set; } = 25;
		public int Scp173Kill { get; set; } = 25;
		public int Scp939Kill { get; set; } = 25;
		[Description("SCP-035")]
		public int Scp035Kill { get; set; } = 25;

		// Class-D
		[Description("Class-D EXP.")]
		public int DclassScientistKill { get; set; } = 50;
		public int DclassMtfKill { get; set; } = 100;
		public int DclassScpKill { get; set; } = 200;
		public int DclassTutorialKill { get; set; } = 100;
		public int DclassEscape { get; set; } = 100;
		public int D035Kill { get; set; } = 100;

		// Scientist
		[Description("Cientifico EXP.")]
		public int ScientistDclassKill { get; set; } = 50;
		public int ScientistChaosKill { get; set; } = 100;
		public int ScientistScpKill { get; set; } = 200;
		public int ScientistTutorialKill { get; set; } = 100;
		public int ScientistEscape { get; set; } = 100;
		public int S035Kill { get; set; } = 100;

		// MTF
		[Description("MTF EXP.")]
		public int MtfDclassKill { get; set; } = 25;
		public int MtfChaosKill { get; set; } = 50;
		public int MtfScpKill { get; set; } = 100;
		public int MtfTutorialKill { get; set; } = 50;
		public int MtfScientistEscape { get; set; } = 25;
		public int M035Kill { get; set; } = 100;

		// Chaos
		[Description("Chaos EXP.")]
		public int ChaosScientistKill { get; set; } = 25;
		public int ChaosMtfKill { get; set; } = 50;
		public int ChaosScpKill { get; set; } = 100;
		public int ChaosTutorialKill { get; set; } = 50;
		public int ChaosDclassEscape { get; set; } = 25;
		public int C035Kill { get; set; } = 100;

		// Tutorial
		[Description("Tutorial EXP | Por alguna razon esto esta aca.")]
		public int TutorialDclassKill { get; set; } = 25;
		public int TutorialScientistKill { get; set; } = 25;
		public int TutorialMtfKill { get; set; } = 50;
		public int TutorialChaosKill { get; set; } = 50;
		public int TutorialScpKillsPlayer { get; set; } = 10;
		public int T035Kill { get; set; } = 10;



		// SCP-106
		[Description("SCP-106 EXP.")]
		public int Scp106PocketDeath { get; set; } = 50;
		public int Scp106PocketScape { get; set; } = 80;
		[Description("Mensaje de Escape")]
		public string Scp106PocketScapeMsg { get; set; } = "Ganaste<color=#32F607>{xp}</color> de exp por escapar de la dimension de bolsillo, tu nivel es <color=red>{level}</color>!";

		// SCP-049
		[Description("049 EXP al revivir")]
		public int Scp049ZombieCreated { get; set; } = 25;

		// SCP-079
		[Description("079 EXP al asistir una kill.")]
		public int Scp079AssistedKill { get; set; } = 10;
	}
}
