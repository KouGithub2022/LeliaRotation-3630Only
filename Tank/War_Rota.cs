using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Tank
{

	[RotationDesc(ActionID.PrimalRend)]
	public class WarPvPRotation : WAR_Base
	{
        #region PvPDeclaration

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Purify { get; } = new BaseAction(ActionID.PvP_Purify)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Guard { get; } = new BaseAction(ActionID.PvP_Guard)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_HeavySwing { get; } = new BaseAction(ActionID.PvP_HeavySwing);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Maim { get; } = new BaseAction(ActionID.PvP_Maim);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_StormsPath { get; } = new BaseAction(ActionID.PvP_StormsPath);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_PrimalRend { get; } = new BaseAction(ActionID.PvP_PrimalRend);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Onslaught { get; } = new BaseAction(ActionID.PvP_Onslaught);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Orogeny { get; } = new BaseAction(ActionID.PvP_Orogeny, ActionOption.Buff);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Blota { get; } = new BaseAction(ActionID.PvP_Blota);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Bloodwhetting { get; } = new BaseAction(ActionID.PvP_Bloodwhetting, ActionOption.Buff);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_FellCleave { get; } = new BaseAction(ActionID.PvP_FellCleave)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_InnerRelease },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_ChaoticCyclone { get; } = new BaseAction(ActionID.PvP_ChaoticCyclone, ActionOption.Buff)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_NascentChaos },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_PrimalScream { get; } = new BaseAction(ActionID.PvP_PrimalScream)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia WAR(PvP)";
		public override string Description => "PvP Rotation for WAR";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
			.SetInt(CombatType.PvP, "PSValue", 30000, "LB:原初の怒号を行うために必要な敵のHPは？", 1, 100000)
			.SetInt(CombatType.PvP, "OSValue", 50000, "オンスロートを行うために必要なプレイヤーのHPは？", 1, 100000)
            .SetBool(CombatType.PvP, "SprintPvP", true, "スプリントを使います。")
            .SetBool(CombatType.PvP, "RecuperatePvP", true, "快気を使います。")
            .SetInt(CombatType.PvP, "RCValue", 75, "快気を使うプレイヤーのHP%%は？", 1, 100)
            .SetBool(CombatType.PvP, "PurifyPvP", true, "浄化を使います。")
            .SetBool(CombatType.PvP, "1343PvP", true, "スタン")
            .SetBool(CombatType.PvP, "3219PvP", true, "氷結")
            .SetBool(CombatType.PvP, "3022PvP", true, "徐々に睡眠")
            .SetBool(CombatType.PvP, "1348PvP", true, "睡眠")
            .SetBool(CombatType.PvP, "1345PvP", false, "バインド")
            .SetBool(CombatType.PvP, "1344PvP", false, "ヘヴィ")
            .SetBool(CombatType.PvP, "1347PvP", true, "沈黙")
            .SetBool(CombatType.PvP, "GuardPvP", true, "防御を使う")
            .SetInt(CombatType.PvP, "GuardValue", 15000, "防御を使うプレイヤーのHP%%は？", 1, 100000)
            .SetBool(CombatType.PvP, "GuardCancel", true, "自分が防御中は攻撃を中止します。");

		protected override bool GeneralGCD(out IAction act)
		{
			act = null;

            #region PvP
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("GuardPvP") && Player.CurrentHp < Configs.GetInt("GuardValue") &&
                PvP_Guard.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;

            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("PurifyPvP"))
            {
                if (Configs.GetBool("1343PvP") && Player.HasStatus(true, (StatusID)1343) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool("3219PvP") && Player.HasStatus(true, (StatusID)3219) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool("3022PvP") && Player.HasStatus(true, (StatusID)3022) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool("1348PvP") && Player.HasStatus(true, (StatusID)1348) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool("1345PvP") && Player.HasStatus(true, (StatusID)1345) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool("1344PvP") && Player.HasStatus(true, (StatusID)1344) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool("1347PvP") && Player.HasStatus(true, (StatusID)1347) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
            }


            //if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("RecuperatePvP") && Player.GetHealthRatio() <= Configs.GetInt("RCValue") &&
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("RecuperatePvP") && ((Player.CurrentHp / Player.MaxHp) * 100) < Configs.GetInt("RCValue") &&
                PvP_Recuperate.CanUse(out act, CanUseOption.MustUse)) return true;


			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("PSValue") && PvP_PrimalScream.IsEnabled)
			{
				if (PvP_PrimalScream.CanUse(out act, CanUseOption.MustUse)) return true;

				if (PvP_Bloodwhetting.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_PrimalRend.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_ChaoticCyclone.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_FellCleave.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
			}

			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Bloodwhetting.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_FellCleave.CanUse(out act, CanUseOption.MustUse)) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_ChaoticCyclone.CanUse(out act, CanUseOption.MustUse)) return true;

			
			if (PvP_PrimalRend.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_StormsPath.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Maim.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_HeavySwing.CanUse(out act, CanUseOption.MustUse)) return true;

            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {
            //if (!PvP_Shadowbringer.IsCoolingDown && HostileTarget && HostileTarget.CurrentHp > Configs.GetInt("SBValue") && PvP_Shadowbringer.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && Player.CurrentHp > Configs.GetInt("OSValue") && PvP_Onslaught.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Orogeny.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Blota.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.AttackAbility(out act);
        }



    }
}
