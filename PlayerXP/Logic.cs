﻿using Exiled.API.Features;
using Hints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlayerXP
{
	partial class EventHandler
	{
		
		private const int baseXP = 1000;
		private System.Random rand = new System.Random();

		private void SendHint(Player player, string msg, float time = 8f)
		{
			player.HintDisplay.Show(new TextHint(msg, new HintParameter[] { new StringHintParameter("") }, HintEffectPresets.FadeInAndOut(0.25f, 1f, 0f), time));
		}

		internal void AddXP(string userid, int xp, string msg = null, float karmaOverride = -1f)
		{
			if (pInfoDict.ContainsKey(userid))
			{
			   
				PlayerInfo info = pInfoDict[userid];
				Player player = Player.Get(userid);
				AdjustKarma(player, karmaOverride == -1f ? PlayerXP.instance.Config.KarmaGainedOnGoodDeed : karmaOverride);
				info.xp += (int)(xp * PlayerXP.instance.Config.XpScale * (PlayerXP.instance.Config.KarmaEnabled ? info.karma : PlayerXP.instance.Config.KarmaInitial));
				if (msg != null) SendHint(player, $"<color=\"yellow\">{msg}</color>");
				int calc = (info.level - 1) * PlayerXP.instance.Config.XpIncrement + baseXP;
				if (info.xp >= calc)
				{
					
					info.xp -= calc;
					info.level++;
					SendHint(player, $"<color=\"yellow\"><b>Has subido de nivel a {info.level}! Necesitas {calc + PlayerXP.instance.Config.XpIncrement - info.xp} EXP para tu próximo nivel.</b></color>", 4f);
				}
				pInfoDict[userid] = info;
			}
			if (PlayerXP.instance.Config.IsDebug) Log.Info($"Dando {xp}EXP a {Player.Get(userid).Nickname} ({userid}).");
		}

		internal void RemoveXP(string userid, int xp, string msg = null)
		{
			if (pInfoDict.ContainsKey(userid))
			{
				PlayerInfo info = pInfoDict[userid];
				Player player = Player.Get(userid);
				info.xp -= xp;
				if (msg != null) SendHint(player, $"<color=\"yellow\">{msg}</color>", 2f);
				if (info.xp <= 0)
				{
					if (info.level > 1)
					{
						info.level--;
						info.xp = info.level * PlayerXP.instance.Config.XpIncrement + baseXP - Math.Abs(info.xp);
					}
					else
					{
						info.xp = 0;
					}
				}
				pInfoDict[userid] = info;
			}

			if (PlayerXP.instance.Config.IsDebug) Log.Info($"Removiendo {xp} EXP de {Player.Get(userid).Nickname} ({userid}).");
		}

		internal void AdjustKarma(Player player, float amount, bool canOverflow = false)
		{
			if (PlayerXP.instance.Config.KarmaEnabled && pInfoDict.ContainsKey(player.UserId))
			{
				float final = pInfoDict[player.UserId].karma += amount;
				Log.Warn("attempting adjust to " + final);
				Log.Warn(final > PlayerXP.instance.Config.KarmaMaximum);
				if (final > PlayerXP.instance.Config.KarmaMaximum)
				{
					if (canOverflow)
					{
						if (final > PlayerXP.instance.Config.KarmaMaximumOverflow)
						{
							pInfoDict[player.UserId].karma = PlayerXP.instance.Config.KarmaMaximumOverflow;
						}
						else
						{
							pInfoDict[player.UserId].karma = final;
						}
					}
					else
					{
						pInfoDict[player.UserId].karma = PlayerXP.instance.Config.KarmaMaximum;
					}
				}
				else if (final < PlayerXP.instance.Config.KarmaMinimum)
				{
					pInfoDict[player.UserId].karma = PlayerXP.instance.Config.KarmaMinimum;
				}
				else
				{
					pInfoDict[player.UserId].karma = final;
				}
			}
			Log.Warn($"Ajustando jugador '{player.Nickname}' karma de {amount} a {pInfoDict[player.UserId].karma}");
		}

		internal int GetLevel(string userid)
		{
			if (pInfoDict.ContainsKey(userid))
			{
				return pInfoDict[userid].level;
			}
			else return -1;
		}

		internal int GetXP(string userid)
		{
			if (pInfoDict.ContainsKey(userid))
			{
				return pInfoDict[userid].xp;
			}
			else return -1;
		}

		private void SaveStats()
		{
			if (PlayerXP.instance.Config.IsDebug) Log.Info($"Saving stats for a total of {pInfoDict.Count} players.");
			foreach (KeyValuePair<string, PlayerInfo> info in pInfoDict)
			{
				if (PlayerXP.instance.Config.IsDebug) Log.Info($"Saving stats for {info.Key}...");
				File.WriteAllText(Path.Combine(PlayerXP.XPPath, $"{info.Key}.json"), JsonConvert.SerializeObject(info.Value, Formatting.Indented));
			}
		}

		internal int XpToLevelUp(string userid)
		{
			if (pInfoDict.ContainsKey(userid))
			{
				PlayerInfo info = pInfoDict[userid];
				return (info.level - 1) * PlayerXP.instance.Config.XpIncrement + baseXP + PlayerXP.instance.Config.XpIncrement;
			}
			else return -1;
		}

		private void UpdateCache()
		{
			foreach (FileInfo file in new DirectoryInfo(PlayerXP.XPPath).GetFiles())
			{
				PlayerInfo info = JsonConvert.DeserializeObject<PlayerInfo>(File.ReadAllText(file.FullName));
				if (info.level == 1 && info.xp == 0)
				{
					File.Delete(file.FullName);
					continue;
				}
				string userid = file.Name.Replace(".json", "");
				if (PlayerXP.instance.Config.IsDebug) Log.Info($"Loading cached stats for {info.name} ({userid})...");
				pInfoDict.Add(userid, info);
			}
			pInfoDict = pInfoDict.OrderByDescending(x => x.Value.level).ThenByDescending(x => x.Value.xp).ToDictionary(x => x.Key, x => x.Value);
		}

		private bool IsUnarmed(Player player)
		{
			foreach (var item in player.Inventory.items)
			{
				if (item.id == ItemType.GrenadeFrag || item.id == ItemType.GunCOM15 ||
					item.id == ItemType.GunE11SR || item.id == ItemType.GunLogicer ||
					item.id == ItemType.GunMP7 || item.id == ItemType.GunProject90 ||
					item.id == ItemType.GunUSP || item.id == ItemType.MicroHID ||
					item.id == ItemType.SCP018) return false;
			}
			return true;
		}

		private Player FindEligibleClassd()
		{
			Player bestPlayer = null;
			float highestKarma = PlayerXP.instance.Config.KarmaLabeledBadActor;
			foreach (Player player in Player.List.Where(x => x.Team == Team.CDP).OrderBy(c => rand.Next()))
			{
				if (pInfoDict.ContainsKey(player.UserId))
				{
					if (pInfoDict[player.UserId].karma >= PlayerXP.instance.Config.KarmaLabeledBadActor)
					{
						return player;
					}
					else if (pInfoDict[player.UserId].karma > highestKarma)
					{
						bestPlayer = player;
						highestKarma = pInfoDict[player.UserId].karma;
					}
				}
			}
			return bestPlayer;
		}

		private int CalcXP(Player player, int xp)
		{
			return (int)(xp * PlayerXP.instance.Config.XpScale * (PlayerXP.instance.Config.KarmaEnabled ? pInfoDict.ContainsKey(player.UserId) ? pInfoDict[player.UserId].karma : 1f : PlayerXP.instance.Config.KarmaInitial));
		}
	}
}
