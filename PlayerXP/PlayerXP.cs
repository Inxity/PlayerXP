﻿using System;
using System.IO;
using Exiled.API.Features;
using PlayerXP.API;

namespace PlayerXP
{
	public class PlayerXP : Plugin<Config>
	{
		public static PlayerXP instance;
		private EventHandler ev;
		public static string XPPath = Path.Combine(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EXILED"), "Plugins"), "PlayerXP");

		public override void OnEnabled()
		{
			base.OnEnabled();

			if (!Config.IsEnabled) return;

			if (!Directory.Exists(XPPath)) Directory.CreateDirectory(XPPath);

			instance = this;
			ev = new EventHandler();
			PXP.singleton = ev;

			Exiled.Events.Handlers.Server.WaitingForPlayers += ev.OnWaitingForPlayers;
			Exiled.Events.Handlers.Server.SendingConsoleCommand += ev.OnConsoleCommand;
			Exiled.Events.Handlers.Server.SendingRemoteAdminCommand += ev.OnRAConsoleCommand;
			Exiled.Events.Handlers.Server.RoundStarted += ev.OnRoundStart;
			Exiled.Events.Handlers.Server.RestartingRound += ev.OnRoundRestart;
			Exiled.Events.Handlers.Server.RoundEnded += ev.OnRoundEnd;
			Exiled.Events.Handlers.Player.Verified += ev.OnPlayerVerify;
			Exiled.Events.Handlers.Player.Dying += ev.OnPlayerDying;
			Exiled.Events.Handlers.Player.FailingEscapePocketDimension += ev.OnPocketDimensionDie;
			Exiled.Events.Handlers.Player.EscapingPocketDimension += ev.OnPocketEscape;
			Exiled.Events.Handlers.Scp049.FinishingRecall += ev.OnRecallZombie;
			Exiled.Events.Handlers.Player.Escaping += ev.OnCheckEscape;
			Exiled.Events.Handlers.Player.Handcuffing += ev.OnHandcuff;
			Exiled.Events.Handlers.Player.RemovingHandcuffs += ev.OnRemovingHandcuff;
		}

		public override void OnDisabled() 
		{
			base.OnDisabled();

			Exiled.Events.Handlers.Server.WaitingForPlayers -= ev.OnWaitingForPlayers;
			Exiled.Events.Handlers.Server.SendingConsoleCommand -= ev.OnConsoleCommand;
			Exiled.Events.Handlers.Server.SendingRemoteAdminCommand -= ev.OnRAConsoleCommand;
			Exiled.Events.Handlers.Server.RoundStarted -= ev.OnRoundStart;
			Exiled.Events.Handlers.Server.RestartingRound -= ev.OnRoundRestart;
			Exiled.Events.Handlers.Server.RoundEnded -= ev.OnRoundEnd;
			Exiled.Events.Handlers.Player.Verified += ev.OnPlayerVerify;
			Exiled.Events.Handlers.Player.Dying -= ev.OnPlayerDying;
			Exiled.Events.Handlers.Player.FailingEscapePocketDimension -= ev.OnPocketDimensionDie;
			Exiled.Events.Handlers.Scp049.FinishingRecall -= ev.OnRecallZombie;
			Exiled.Events.Handlers.Player.Escaping -= ev.OnCheckEscape;
			Exiled.Events.Handlers.Player.Handcuffing -= ev.OnHandcuff;
			Exiled.Events.Handlers.Player.RemovingHandcuffs -= ev.OnRemovingHandcuff;
			Exiled.Events.Handlers.Player.EscapingPocketDimension -= ev.OnPocketEscape;

			ev = null;
		}

		public override string Name => "PlayerXp";
	}
}
