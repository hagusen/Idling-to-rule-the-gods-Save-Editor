using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Data.GameState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5E404248-33EE-4422-802F-2EB74208EDCB
// Assembly location: C:\Users\jabja\Desktop\Idling to Rule the Gods\Idling to Rule the Gods_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.Dungeons;
using Assets.Scripts.Gui;
using Assets.Scripts.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data {
    public class GameState {
        
        public string Serialize() {
            StringBuilder builder = new StringBuilder();
            Conv.AppendValue(builder, "a", this.Divinity.Serialize());
            Conv.AppendValue(builder, "b", this.CurrentHealth.Serialize());
            Conv.AppendValue(builder, "c", this.TimeStampGameClosed);
            Conv.AppendValue(builder, "d", this.CreatingPower.Serialize());
            Conv.AppendValue(builder, "e", this.Clones.Serialize());
            Conv.AppendValue(builder, "g", this.Title);
            Conv.AppendList<Training>(builder, this.AllTrainings, "h");
            Conv.AppendList<Creation>(builder, this.AllCreations, "i");
            Conv.AppendList<Skill>(builder, this.AllSkills, "j");
            Conv.AppendList<Fight>(builder, this.AllFights, "k");
            Conv.AppendValue(builder, "l", this.CloneAttackDivider);
            Conv.AppendValue(builder, "m", this.CloneDefenseDivider);
            Conv.AppendValue(builder, "n", this.CloneHealthDivider);
            Conv.AppendValue(builder, "o", this.Multiplier.Serialize());
            Conv.AppendValue(builder, "p", this.PremiumBoni.Serialize());
            Conv.AppendValue(builder, "q", this.ShouldSubmitScore.ToString());
            Conv.AppendValue(builder, "r", this.KongUserId);
            Conv.AppendValue(builder, "s", this.KongUserName);
            Conv.AppendValue(builder, "t", this.IsTutorialShown.ToString());
            Conv.AppendValue(builder, "u", this.IsGuestMsgShown.ToString());
            Conv.AppendValue(builder, "x", this.Statistic.Serialize());
            List<AchievementId> idList1 = Achievement.AchievementsToIdList(this.TrainingAchievements);
            Conv.AppendList<AchievementId>(builder, idList1, "y");
            List<AchievementId> idList2 = Achievement.AchievementsToIdList(this.SkillAchievements);
            Conv.AppendList<AchievementId>(builder, idList2, "z");
            List<AchievementId> idList3 = Achievement.AchievementsToIdList(this.FightingAchievements);
            Conv.AppendList<AchievementId>(builder, idList3, "A");
            List<AchievementId> idList4 = Achievement.AchievementsToIdList(this.CreatingAchievements);
            Conv.AppendList<AchievementId>(builder, idList4, "B");
            Conv.AppendValue(builder, "C", this.IsMonumentUnlocked.ToString());
            Conv.AppendList<Monument>(builder, this.AllMonuments, "D");
            Conv.AppendValue(builder, "E", this.isBuyUnlocked.ToString());
            Conv.AppendValue(builder, "F", this.PhysicalPowerBase.Serialize());
            Conv.AppendValue(builder, "G", this.MysticPowerBase.Serialize());
            Conv.AppendValue(builder, "H", this.BattlePowerBase.Serialize());
            Conv.AppendValue(builder, "I", this.CreatingPowerBase.Serialize());
            Conv.AppendValue(builder, "J", this.IsUpgradeUnlocked.ToString());
            Conv.AppendValue(builder, "K", this.Generator.Serialize());
            Conv.AppendValue(builder, "N", this.TitleGod);
            Conv.AppendValue(builder, "O", this.GameSettings.Serialize());
            Conv.AppendValue(builder, "P", this.PrinnyBaal.Serialize());
            Conv.AppendValue(builder, "Q", this.Avatar.Serialize());
            Conv.AppendValue(builder, "S", this.Crits.Serialize());
            Conv.AppendValue(builder, "T", this.HomePlanet.Serialize());
            Conv.AppendValue(builder, "U", this.CreatingSpeedBoniDuration);
            Conv.AppendList<Might>(builder, this.AllMights, "V");
            Conv.AppendValue(builder, "W", this.AvatarName);
            Conv.AppendValue(builder, "X", this.Ext.Serialize());
            Conv.AppendValue(builder, "Y", this.IsBlackListed.ToString());
            Conv.AppendValue(builder, "Z", this.IsSocialDialogShown.ToString());
            Conv.AppendValue(builder, NS.n1.Nr(), this.SteamId);
            Conv.AppendValue(builder, NS.n2.Nr(), this.SteamName);
            Conv.AppendValue(builder, NS.n3.Nr(), this.AndroidId);
            Conv.AppendValue(builder, NS.n4.Nr(), this.AndroidName);
            Conv.AppendValue(builder, NS.n5.Nr(), this.TimeStampGameClosedOfflineMS);
            Conv.AppendValue(builder, NS.n6.Nr(), this.Logging);
            Conv.AppendValue(builder, NS.n7.Nr(), this.ApeCampaigns);
            Conv.AppendValue(builder, NS.n8.Nr(), this.PandoraFeedings);
            Conv.AppendValue(builder, NS.n9.Nr(), this.SpaceDim.Serialize());
            Conv.AppendValue(builder, NS.n10.Nr(), this.PatreonTier.Serialize());
            Conv.AppendValue(builder, NS.n11.Nr(), this.ChickenGodReached);
            Conv.AppendValue(builder, NS.n12.Nr(), this.UBV4Battle.Serialize());
            Conv.AppendValue(builder, NS.n13.Nr(), this.OverflowBoost.Serialize());
            return Conv.ToBase64(builder.ToString(), nameof(GameState));
        }

        internal static GameState FromString(string base64String) {
            if (string.IsNullOrEmpty(base64String))
                return new GameState(true, 0);
            string[] parts = Conv.StringPartsFromBase64(base64String, nameof(GameState));
            GameState state = new GameState(false, 0);
            state.OldCreatingPower = new CDouble(Conv.getStringFromParts(parts, "d"));
            state.PhysicalPowerBase = new CDouble(Conv.getStringFromParts(parts, "F"));
            state.MysticPowerBase = new CDouble(Conv.getStringFromParts(parts, "G"));
            state.BattlePowerBase = new CDouble(Conv.getStringFromParts(parts, "H"));
            state.CreatingPowerBase = new CDouble(Conv.getStringFromParts(parts, "I"));
            state.Multiplier = Multi.FromString(Conv.getStringFromParts(parts, "o"));
            state.Divinity = new CDouble(Conv.getStringFromParts(parts, "a"));
            state.TimeStampGameClosed = Conv.getLongFromParts(parts, "c");
            state.CurrentHealth = new CDouble(Conv.getStringFromParts(parts, "b"));
            state.Clones = ShadowClone.FromString(Conv.getStringFromParts(parts, "e"));
            state.Title = Conv.getStringFromParts(parts, "g");
            state.CloneAttackDivider = Conv.getIntFromParts(parts, "l", 0);
            if (state.CloneAttackDivider == 0)
                state.CloneAttackDivider = 1000;
            state.CloneDefenseDivider = Conv.getIntFromParts(parts, "m", 0);
            if (state.CloneDefenseDivider == 0)
                state.CloneDefenseDivider = 1000;
            state.CloneHealthDivider = Conv.getIntFromParts(parts, "n", 0);
            if (state.CloneHealthDivider == 0)
                state.CloneHealthDivider = 1000;
            state.PremiumBoni = Premium.FromString(Conv.getStringFromParts(parts, "p"));
            state.PremiumBoni.CheckGPBoniValues();
            state.ShouldSubmitScore = Conv.getStringFromParts(parts, "q").ToLower().Equals("true");
            state.KongUserId = Conv.getStringFromParts(parts, "r");
            state.KongUserName = Conv.getStringFromParts(parts, "s");
            state.IsTutorialShown = Conv.getStringFromParts(parts, "t").ToLower().Equals("true");
            state.IsGuestMsgShown = Conv.getStringFromParts(parts, "u").ToLower().Equals("true");
            state.Statistic = Statistic.FromString(Conv.getStringFromParts(parts, "x"));
            string stringFromParts1 = Conv.getStringFromParts(parts, "h");
            char[] chArray1 = new char[1] { '&' };
            foreach (string base64String1 in stringFromParts1.Split(chArray1)) {
                if (!string.IsNullOrEmpty(base64String1))
                    state.AllTrainings.Add(Training.FromString(base64String1));
            }
            if (state.AllTrainings.Count == 0)
                state.AllTrainings = Training.Initial();
            string stringFromParts2 = Conv.getStringFromParts(parts, "i");
            char[] chArray2 = new char[1] { '&' };
            foreach (string base64String1 in stringFromParts2.Split(chArray2)) {
                if (!string.IsNullOrEmpty(base64String1))
                    state.AllCreations.Add(Creation.FromString(base64String1));
            }
            if (state.AllCreations.Count == 0)
                state.AllCreations = Creation.Initial();
            string stringFromParts3 = Conv.getStringFromParts(parts, "j");
            char[] chArray3 = new char[1] { '&' };
            foreach (string base64String1 in stringFromParts3.Split(chArray3)) {
                if (!string.IsNullOrEmpty(base64String1))
                    state.AllSkills.Add(Skill.FromString(base64String1));
            }
            if (state.AllSkills.Count == 0)
                state.AllSkills = Skill.Initial();
            string stringFromParts4 = Conv.getStringFromParts(parts, "k");
            char[] chArray4 = new char[1] { '&' };
            foreach (string base64String1 in stringFromParts4.Split(chArray4)) {
                if (!string.IsNullOrEmpty(base64String1))
                    state.AllFights.Add(Fight.FromString(base64String1));
            }
            if (state.AllFights.Count == 0)
                state.AllFights = Fight.Initial();
            if (state.AllFights.Count == 28) {
                state.AllFights.Add(new Fight(Fight.FightType.genbu));
                state.AllFights.Add(new Fight(Fight.FightType.byakko));
                state.AllFights.Add(new Fight(Fight.FightType.suzaku));
                state.AllFights.Add(new Fight(Fight.FightType.seiryuu));
                state.AllFights.Add(new Fight(Fight.FightType.godzilla));
                state.AllFights.Add(new Fight(Fight.FightType.monster_queen));
            }
            string stringFromParts5 = Conv.getStringFromParts(parts, "D");
            char[] chArray5 = new char[1] { '&' };
            foreach (string base64String1 in stringFromParts5.Split(chArray5)) {
                if (!string.IsNullOrEmpty(base64String1))
                    state.AllMonuments.Add(Monument.FromString(base64String1));
            }
            if (state.AllMonuments.Count == 0)
                state.AllMonuments = Monument.Initial();
            if (state.AllMonuments.Count == 7)
                state.AllMonuments.Add(new Monument(Monument.MonumentType.black_hole));
            state.GameSettings = Settings.FromString(Conv.getStringFromParts(parts, "O"));
            if (state.GameSettings.LastCreation == null)
                state.GameSettings.LastCreation = state.AllCreations[0];
            CDouble.NumberDisplay = state.GameSettings.NumberDisplay;
            Challenge.SetUCCReward(state);
            CDouble uccReward = Challenge.GetUCCReward(ChallengeType.AAC);
            Achievement.InitAchievements(state.Statistic.AchievementChallengesFinished.ToInt(), uccReward > (CDouble)0);
            string[] strArray1 = Conv.getStringFromParts(parts, "y").Split('&');
            List<AchievementId> idList1 = new List<AchievementId>();
            foreach (string base64String1 in strArray1) {
                if (!string.IsNullOrEmpty(base64String1))
                    idList1.Add(AchievementId.FromString(base64String1));
            }
            state.TrainingAchievements = Achievement.TrainingAchievementsFromIdList(idList1);
            string[] strArray2 = Conv.getStringFromParts(parts, "z").Split('&');
            List<AchievementId> idList2 = new List<AchievementId>();
            foreach (string base64String1 in strArray2) {
                if (!string.IsNullOrEmpty(base64String1))
                    idList2.Add(AchievementId.FromString(base64String1));
            }
            state.SkillAchievements = Achievement.SkillAchievementsFromIdList(idList2);
            string[] strArray3 = Conv.getStringFromParts(parts, "A").Split('&');
            List<AchievementId> idList3 = new List<AchievementId>();
            foreach (string base64String1 in strArray3) {
                if (!string.IsNullOrEmpty(base64String1))
                    idList3.Add(AchievementId.FromString(base64String1));
            }
            state.FightingAchievements = Achievement.FightAchievementsFromIdList(idList3);
            string[] strArray4 = Conv.getStringFromParts(parts, "B").Split('&');
            List<AchievementId> idList4 = new List<AchievementId>();
            foreach (string base64String1 in strArray4) {
                if (!string.IsNullOrEmpty(base64String1))
                    idList4.Add(AchievementId.FromString(base64String1));
            }
            state.CreatingAchievements = Achievement.CreationAchievementsFromIdList(idList4);
            state.AddMultisFromGod();
            state.IsMonumentUnlocked = Conv.getStringFromParts(parts, "C").ToLower().Equals("true");
            state.IsBuyUnlocked = Conv.getStringFromParts(parts, "E").ToLower().Equals("true");
            state.IsUpgradeUnlocked = Conv.getStringFromParts(parts, "J").ToLower().Equals("true");
            state.Generator = DivinityGenerator.FromString(Conv.getStringFromParts(parts, "K"));
            state.TitleGod = Conv.getStringFromParts(parts, "N");
            state.PrinnyBaal = PBaal.FromString(Conv.getStringFromParts(parts, "P"));
            state.Avatar = AvatarOptions.FromString(Conv.getStringFromParts(parts, "Q"));
            state.Crits = Critical.FromString(Conv.getStringFromParts(parts, "S"));
            state.HomePlanet = Planet.FromString(Conv.getStringFromParts(parts, "T"));
            if (state.HomePlanet.IsCreated && state.HomePlanet.UpgradeLevel > (CDouble)1 && state.HomePlanet.TotalGainedGodPower == (CDouble)0) {
                state.HomePlanet.TotalGainedGodPower = (CDouble)(int)(state.Statistic.UBsDefeated.Double * 0.4);
                state.HomePlanet.ShadowCloneCount.Round();
            }
            if (state.Statistic.TotalPowersurge < state.HomePlanet.PowerSurgeMultiplier)
                state.Statistic.TotalPowersurge = state.HomePlanet.PowerSurgeMultiplier;
            if (state.Statistic.UltimateBaalChallengesFinished > (CDouble)0 || state.Statistic.ArtyChallengesFinished > (CDouble)0) {
                state.HomePlanet.UltimateBeingsV2[0].IsAvailable = true;
                foreach (UltimateBeing ultimateBeing in state.HomePlanet.UltimateBeings) {
                    if (state.HomePlanet.UpgradeLevel > (CDouble)4)
                        ultimateBeing.IsAvailable = true;
                }
            }
            state.CreatingSpeedBoniDuration = Conv.getLongFromParts(parts, "U");
            if (state.PremiumBoni.StatisticMulti <= (CDouble)0)
                state.PremiumBoni.StatisticMulti = (CDouble)1;
            string stringFromParts6 = Conv.getStringFromParts(parts, "V");
            char[] chArray6 = new char[1] { '&' };
            foreach (string base64String1 in stringFromParts6.Split(chArray6)) {
                if (!string.IsNullOrEmpty(base64String1))
                    state.AllMights.Add(Might.FromString(base64String1));
            }
            if (state.AllMights.Count == 0)
                state.AllMights = Might.Initial();
            state.AvatarName = Conv.getStringFromParts(parts, "W");
            if (string.IsNullOrEmpty(state.AvatarName))
                state.AvatarName = state.KongUserName;
            state.Ext = State2.Deserialize(Conv.getStringFromParts(parts, "X"));
            state.IsBlackListed = Conv.getStringFromParts(parts, "Y").ToLower().Equals("true");
            state.IsSocialDialogShown = Conv.getStringFromParts(parts, "Z").ToLower().Equals("true");
            state.SteamId = Conv.getStringFromParts(parts, NS.n1.Nr());
            state.SteamName = Conv.getStringFromParts(parts, NS.n2.Nr());
            state.AndroidId = Conv.getStringFromParts(parts, NS.n3.Nr());
            state.AndroidName = Conv.getStringFromParts(parts, NS.n4.Nr());
            state.TimeStampGameClosedOfflineMS = Conv.getLongFromParts(parts, NS.n5.Nr());
            state.Logging = Conv.getStringFromParts(parts, NS.n6.Nr());
            state.ApeCampaigns = Conv.getStringFromParts(parts, NS.n7.Nr());
            state.PandoraFeedings = Conv.getIntFromParts(parts, NS.n8.Nr(), 0);
            state.SpaceDim = new SpaceDim(Conv.getStringFromParts(parts, NS.n9.Nr()));
            state.PatreonTier = Conv.getCDoubleFromParts(parts, NS.n10.Nr(), false);
            state.ChickenGodReached = Conv.getBoolFromParts(parts, NS.n11.Nr());
            state.UBV4Battle = new BattleUBV4(Conv.getStringFromParts(parts, NS.n12.Nr()));
            state.OverflowBoost = new OverflowBoosts(Conv.getStringFromParts(parts, NS.n13.Nr()));
            state.Statistic.CalculateTotalPetGrowth(state.Ext.AllPets);
            if (state.CreatingPowerBase < (CDouble)0)
                state.CreatingPowerBase = (CDouble)0;
            try {
                state.SpaceDim.SetIdleClones(state);
                state.SetAvailableTitles();
                if (state.SteamId == null)
                    state.SteamId = string.Empty;
                if (state.SteamName == null)
                    state.SteamName = string.Empty;
                if (state.KongUserId == null)
                    state.KongUserId = string.Empty;
                if (state.KongUserName == null)
                    state.KongUserName = string.Empty;
                if (state.KongUserId != null)
                    state.KongUserId = state.KongUserId.Trim();
                int gpSpent = state.PremiumBoni.CalculateGPSpent(state);
                if (gpSpent > state.PremiumBoni.TotalGodPowerSpent)
                    state.PremiumBoni.TotalGodPowerSpent = gpSpent;
                StoryUi.SetUnlockedStoryParts(state);
                if (state.Statistic.UBsDefeated == (CDouble)0) {
                    foreach (UltimateBeing ultimateBeing in state.HomePlanet.UltimateBeings)
                        state.Statistic.UBsDefeated += (CDouble)ultimateBeing.TimesDefeated;
                }
                state.HomePlanet.InitUBMultipliers();
                state.Battle = new BattleState();
                if (state.Statistic.TotalRebirths == (CDouble)0)
                    state.Statistic.TimePlayedSinceRebirth = state.Statistic.TimePlayed;
                Creation creation = state.AllCreations.FirstOrDefault<Creation>((Func<Creation, bool>)(x => x.TypeEnum == Creation.CreationType.Universe));
                if (creation != null && creation.GodToDefeat.IsDefeated)
                    state.PrinnyBaal.IsUnlocked = true;
                if (state.GameSettings.LastCreation != null)
                    state.GameSettings.LastCreation = state.AllCreations.FirstOrDefault<Creation>((Func<Creation, bool>)(x => x.TypeEnum == state.GameSettings.LastCreation.TypeEnum));
                if (state.Clones.MaxShadowClones < state.Clones.IdleClones())
                    state.Clones.Count = state.Clones.MaxShadowClones;
                if (state.GameSettings.Framerate == 0)
                    state.GameSettings.Framerate = 30;
                if (!state.Generator.IsAvailable) {
                    Monument monument = state.AllMonuments.FirstOrDefault<Monument>((Func<Monument, bool>)(x => x.TypeEnum == Monument.MonumentType.temple_of_god));
                    if (monument != null && monument.Level > (CDouble)0)
                        state.Generator.IsAvailable = true;
                }
                state.Ext.InitPetStats(state);
                foreach (Pet allPet in state.Ext.AllPets) {
                    if (allPet.ZeroHealthTime > 60000L)
                        allPet.ZeroHealthTime = 60000L;
                    allPet.ShadowCloneCount.Round();
                    if (allPet.ShadowCloneCount < (CDouble)0)
                        allPet.ShadowCloneCount = (CDouble)0;
                    allPet.CalculateValues(state);
                    allPet.Dungeon.Init(state, allPet);
                    allPet.SetIsInDungeon(state);
                    allPet.SetIsCrafting(state);
                    if (!allPet.IsUnlocked)
                        allPet.Dungeon.UnequipAll(state, allPet);
                    if (allPet.Dungeon.Class.Type == PetClasses.Alchemist || allPet.Dungeon.Class.Type == PetClasses.Blacksmith)
                        allPet.SetCraftingExpPerHour(state);
                }
                state.Ext.SetEquipBonus(state);
                state.Multiplier.UpdatePetMultis(state, false);
                foreach (Might allMight in state.AllMights) {
                    if (allMight.TypeEnum == Might.MightType.physical_hp)
                        state.PhysicalHPMod = ((CDouble)100 + allMight.Level).ToInt();
                    allMight.ShadowCloneCount.Round();
                }
                state.CurrentHealth = new CDouble(Conv.getStringFromParts(parts, "b"));
                foreach (ClothingPart clothingPart in state.Avatar.ClothingParts) {
                    if (clothingPart.PermanentGPCost == (CDouble)0 && (CDouble)clothingPart.GodDefeatedTierNeeded <= state.Statistic.HighestGodDefeated)
                        clothingPart.IsPermanentUnlocked = true;
                }
                if (state.Statistic.Challenge == ChallengeType.UAC)
                    state.Crits = new Critical();
                if (state.Statistic.Challenge == ChallengeType.UBC || state.Statistic.Challenge == ChallengeType.UAC) {
                    Premium premium = Premium.FromString(state.Statistic.PremiumStatsBeforeUBCChallenge);
                    if (state.PremiumBoni.TotalItemsBought < premium.TotalItemsBought)
                        state.PremiumBoni.TotalItemsBought = premium.TotalItemsBought;
                }
                state.PremiumBoni.CheckCrystalBonus(state);
                state.DivinityGainSec(false);
                foreach (PetCampaign allCampaign in state.Ext.AllCampaigns) {
                    allCampaign.InitPetsInCampaign(state);
                    if (allCampaign.Type == Campaigns.GodPower && state.PremiumBoni.GodPowerFromPets < allCampaign.CampaignsFinished * (CDouble)5)
                        state.PremiumBoni.GodPowerFromPets = allCampaign.CampaignsFinished * (CDouble)5;
                }
                foreach (Monument allMonument in state.AllMonuments) {
                    if (!state.IsUpgradeUnlocked)
                        allMonument.Upgrade.Level = (CDouble)0;
                    if (!allMonument.IsAvailable(state))
                        allMonument.RemoveCloneCount(allMonument.ShadowCloneCount, state);
                    if (state.Statistic.MonumentMultiChallengesFinished > (CDouble)0)
                        allMonument.Init(allMonument.TypeEnum, state);
                }
                state.PremiumBoni.SetCrystalPowerMulti(state);
                if (double.IsNaN(state.PrinnyBaal.PowerLevel.Double) || double.IsInfinity(state.PrinnyBaal.PowerLevel.Double))
                    state.Statistic.HasReachedMaxBaal = true;
                if (state.PremiumBoni.GodPower < 0) {
                    state.PremiumBoni.GodPower += int.MaxValue;
                    int num = GameState.MaxPossibleGodPower(state).ToInt() - state.PremiumBoni.CalculateGPSpent(state);
                    if (state.PremiumBoni.GodPower > num)
                        state.PremiumBoni.GodPower = num;
                }
                Pet.SetPetFoodDescription(state);
                if (!state.Ext.ChpHasPet)
                    state.Ext.AllPets.FirstOrDefault<Pet>((Func<Pet, bool>)(x => x.TypeEnum == PetType.Stone)).IsUnlocked = false;
                if (state.Statistic.Challenge == ChallengeType.CPC && state.Statistic.UltimateBaalChallengesFinished == (CDouble)0 && state.Statistic.ArtyChallengesFinished == (CDouble)0)
                    state.Statistic.CancelChallenge();
                if (state.Divinity < (CDouble)0)
                    state.Divinity = (CDouble)0;
                state.Statistic.AllChallenges = Challenge.GetChallenges(ChallengeRebirthType.All, state);
                Premium.FromString(state.Statistic.PremiumStatsBeforeUBCChallenge);
                if (!string.IsNullOrEmpty(state.Statistic.PremiumStatsBeforeUBCChallenge) && !state.Statistic.HasStartedGPResetChallenge) {
                    Premium premiumFromChallenge = Premium.FromString(state.Statistic.PremiumStatsBeforeUBCChallenge);
                    if (state.PremiumBoni.TotalGodPowerSpent < premiumFromChallenge.TotalGodPowerSpent)
                        state.PremiumBoni.AddPremiumAfterChallenge(premiumFromChallenge);
                    state.Statistic.PremiumStatsBeforeUBCChallenge = string.Empty;
                }
                if (state.Logging.Length > 5000)
                    state.Logging = string.Empty;
                state.SetFSMBoost();
                if (state.Statistic.HighestGodDefeated > (CDouble)175)
                    state.Statistic.HighestGodDefeated = (CDouble)175;
                state.Statistic.SetPetStats(state);
                if (state.Statistic.SaveVersionsNumber < 969 && state.Statistic.Trigger > (CDouble)0 && state.Statistic.HighestMightOneDay > (CDouble)30000) {
                    foreach (Might allMight in state.AllMights) {
                        allMight.Level = (CDouble)0;
                        state.Statistic.Trigger = (CDouble)0;
                        state.PremiumBoni.TotalMight = state.Statistic.TotalRebirths * (CDouble)1000;
                        state.Statistic.HighestMightOneDay = (CDouble)5000;
                    }
                }
                if (state.Statistic.SaveVersionsNumber < 1065) {
                    state.Statistic.DungeonChallenges = new DungeonChallengeResult();
                    state.Ext.ChallengeTriesUsed = (CDouble)0;
                    state.Ext.Gems = new List<Gem>();
                }
                if (state.Statistic.SaveVersionsNumber < 1141) {
                    state.Statistic.BoughtEventPetToken = false;
                    if (state.Statistic.EvenItems < (CDouble)5000) {
                        CDouble cdouble = state.Statistic.EvenItems * (CDouble)20;
                        state.Ext.PetStones += cdouble;
                        state.Statistic.PetStonesHour += cdouble;
                    }
                    state.Statistic.EvenItemsTotal = (CDouble)0;
                    state.Statistic.EvenItems = (CDouble)0;
                }
                if (state.Statistic.SaveVersionsNumber < 1085 && state.Statistic.UBV2ChallengesFinished > (CDouble)10)
                    state.Statistic.UBV2ChallengesFinished = (CDouble)10;
                if (state.Statistic.SaveVersionsNumber < 1105) {
                    List<PetEquip> petEquipList = new List<PetEquip>();
                    foreach (PetEquip petEquip in state.Ext.PetEquips) {
                        if (petEquip.Type == Equips.AlchemistCape)
                            petEquipList.Add(petEquip);
                    }
                    if (petEquipList.Count > 1) {
                        for (int index = 1; index < petEquipList.Count; ++index)
                            state.Ext.PetEquips.Remove(petEquipList[index]);
                    }
                }
                if (state.Statistic.SaveVersionsNumber > 1146)
                    MainUi.SaveHasNewerVersionsInfo = "The save you have just loaded is from version " + (object)((double)state.Statistic.SaveVersionsName / 100.0) + "." + (object)state.Statistic.SaveVersionsNumber + "!\nThe game you are running just now runs on version " + App.GameVersion + ".\n\nThis is older than the version your save was made with. This means it is possible that you lost things which were added on the new version. Please be careful, update the game, then load online, or go back and play on the other platform where you made the save with.";
                state.Statistic.SaveVersionsNumber = 1146;
                Pet pet = state.Ext.AllPets.FirstOrDefault<Pet>((Func<Pet, bool>)(x => x.TypeEnum == PetType.Question));
                if (!pet.IsEvolved && pet.Name.Equals("Answer"))
                    pet.Name = "Question";
                PetUi.ToolbarInt = 0;
                if (state.Statistic.TBSScore < (CDouble)state.Crits.Score(state.GameSettings.TBSEyesIsMirrored))
                    state.Statistic.TBSScore = (CDouble)state.Crits.Score(state.GameSettings.TBSEyesIsMirrored);
                if (state.Statistic.DayPetChallengesFinished > (CDouble)0 && state.Statistic.BonusPetFood == (CDouble)0 && state.Statistic.HighestPetMultiOneDay > (CDouble)0) {
                    state.Statistic.SetPetFoodBonus(state);
                    Pet.SetPetFoodDescription(state);
                }
                foreach (Pet allPet in state.Ext.AllPets) {
                    if (allPet.IsInDungeon && allPet.IsInCampaign) {
                        PetCampaign petCampaign = (PetCampaign)null;
                        foreach (PetCampaign allCampaign in state.Ext.AllCampaigns) {
                            if (allCampaign.PetIdsCampaign.Contains(allPet.TypeEnum))
                                petCampaign = allCampaign;
                        }
                        if (petCampaign != null) {
                            petCampaign.PetIdsCampaign.Remove(allPet.TypeEnum);
                            petCampaign.PetsInCampaign.Remove(allPet);
                        }
                        if (allPet.TypeEnum == PetType.BHC && allPet.IsEvolved && state.UBV4Battle.Points < (CDouble)1000) {
                            allPet.Dungeon.Class.Type = PetClasses.None;
                            allPet.Dungeon.Class.Level = (CDouble)0;
                            allPet.Dungeon.Class.Experience = (CDouble)0;
                            ++state.PremiumBoni.PetToken;
                        }
                    }
                }
                state.InitAchievements();
                foreach (Crafting crafting in state.Ext.CraftingsInWork) {
                    if (crafting.CurrentEquipCrafting == Equips.AlchemistCape && crafting.UpgradeType == EquipUpgrades.None) {
                        crafting.CancelCrafting(state);
                        state.Ext.CraftingsInWork.Remove(crafting);
                    }
                }
                if (state.Clones.TotalClonesKilled < (CDouble)0)
                    state.Clones.TotalClonesKilled = (CDouble)0;
                if (state.Statistic.OverflowPoints + state.Statistic.OverflowPointsSpent > state.Statistic.OverflowChallengesFinished * (CDouble)500) {
                    state.Statistic.OverflowPointsSpent = (CDouble)0;
                    state.Statistic.OverflowPoints = state.Statistic.OverflowChallengesFinished * (CDouble)500;
                    state.OverflowBoost = new OverflowBoosts();
                }
                state.SteamName = state.SteamName.Replace("<", string.Empty).Replace(">", string.Empty).Replace("'", string.Empty).Replace("\"", string.Empty);
                state.KongUserName = state.KongUserName.Replace("<", string.Empty).Replace(">", string.Empty).Replace("'", string.Empty).Replace("\"", string.Empty);
                state.AndroidName = state.AndroidName.Replace("<", string.Empty).Replace(">", string.Empty).Replace("'", string.Empty).Replace("\"", string.Empty);
                state.CheckMightBoni();
                state.SetBHGPHour();
                state.Generator.SetClonesForCapMax(state);
                state.HomePlanet.SetNeededClones(state);
                foreach (SpaceDimElement element in state.SpaceDim.Elements)
                    element.Init(state.SpaceDim, state);
                state.CheckDungeonsForRebirthBacon();
                state.Statistic.SetUBsV2Defeated(state);
            }
            catch (Exception ex) {
                Log.Error(string.Empty + ex.StackTrace);
            }
            return state;
        }
    }
}

