using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Melee
{

	[RotationDesc(ActionID.HissatsuGyoten)]
	public class SamPvPRotation : SAM_Base
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
        public static IBaseAction PvP_Yukikaze { get; } = new BaseAction(ActionID.PvP_Yukikaze);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Gekko { get; } = new BaseAction(ActionID.PvP_Gekko);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Kasha { get; } = new BaseAction(ActionID.PvP_Kasha);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_OgiNamikiri { get; } = new BaseAction(ActionID.PvP_OgiNamikiri)
        {
            StatusProvide = new StatusID[1] { (StatusID)3199 },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Kaeshi { get; } = new BaseAction(ActionID.PvP_Kaeshi)
        {
            StatusProvide = new StatusID[1] { (StatusID)3200 },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Soten { get; } = new BaseAction(ActionID.PvP_Soten);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Hyosetsu { get; } = new BaseAction(ActionID.PvP_Hyosetsu,ActionOption.Buff)
		{
			StatusNeed = new StatusID[] { StatusID.PvP_Kaiten },
		};


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Mangetsu { get; } = new BaseAction(ActionID.PvP_Mangetsu)
		{
			StatusNeed = new StatusID[] { StatusID.PvP_Kaiten },
		};


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Oka { get; } = new BaseAction(ActionID.PvP_Oka)
		{
			StatusNeed = new StatusID[] { StatusID.PvP_Kaiten },
		};


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Chiten { get; } = new BaseAction(ActionID.PvP_Chiten, ActionOption.Buff);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Mineuchi { get; } = new BaseAction(ActionID.PvP_Mineuchi);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_MeikyoShisui { get; } = new BaseAction(ActionID.PvP_MeikyoShisui, ActionOption.Buff);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Midare { get; } = new BaseAction(ActionID.PvP_Midare)
		{
			StatusNeed = new StatusID[] { StatusID.PvP_Midare },
		};


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Zantetsuken { get; } = new BaseAction(ActionID.PvP_Zantetsuken)
		{
			FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
			ActionCheck = (t, m) => LimitBreakLevel >= 1,
		};
		#endregion

		public override string GameVersion => "6.51";
		public override string RotationName => "Lelia SAM(PvP)";
		public override string Description => "PvP Rotation for SAM";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "Use the LB in PvP when Target is killable by it")
            //			.SetInt(CombatType.PvP, "ZTValue", 30000, "How much HP does the enemy have for LB:Zantetsuken to be done", 1, 100000)
            //			.SetInt(CombatType.PvP, "OSValue", 30000, "How much HP does the enemy have for Onslaught to be done", 1, 100000)
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
            .SetInt(CombatType.PvP, "GuardValue", 15000, "防御を使うプレイヤーのHPは？", 1, 100000)
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



			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Zantetsuken.IsEnabled)
			{
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Chiten.CanUse(out act, CanUseOption.MustUse) && InCombat && PvP_Zantetsuken.IsEnabled) return true;
                if (PvP_StandardIssueElixir.CanUse(out act)) return true;
                if (Configs.GetBool("LBInPvP") && PvP_Zantetsuken.CanUse(out act, CanUseOption.MustUse) && PvP_StandardIssueElixir.IsCoolingDown) return true;
            }


            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_Midare))
			{
				if (PvP_Midare.CanUse(out act, CanUseOption.MustUse)) return true;
			}


            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_OgiNamikiri.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, (StatusID)3199) && !PvP_Kaeshi.IsInCooldown && PvP_Kaeshi.CanUse(out act, CanUseOption.MustUse)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Hyosetsu.CanUse(out act, CanUseOption.MustUse) && Player.HasStatus(true, StatusID.PvP_Kaiten)) return true;
//            if (PvP_Soten.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Mangetsu.CanUse(out act, CanUseOption.MustUse) && Player.HasStatus(true, StatusID.PvP_Kaiten)) return true;
//            if (PvP_Soten.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Oka.CanUse(out act, CanUseOption.MustUse) && Player.HasStatus(true, StatusID.PvP_Kaiten)) return true;

			if (PvP_Kasha.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Gekko.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Yukikaze.CanUse(out act, CanUseOption.MustUse)) return true;


            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
            //return false;
			#endregion
		}
        protected override bool AttackAbility(out IAction act)
        {
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !HostileTarget.HasStatus(true, StatusID.PvP_Kaiten) && !Player.HasStatus(true, (StatusID)3199) && PvP_Soten.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Chiten.CanUse(out act, CanUseOption.MustUse) && InCombat && !PvP_Zantetsuken.IsEnabled) return true;
            if (HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Mineuchi.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, (StatusID)3199) && PvP_MeikyoShisui.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            return base.AttackAbility(out act);
        }

    }
}