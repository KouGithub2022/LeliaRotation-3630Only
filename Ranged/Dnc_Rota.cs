using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaWaRotations.Ranged
{

	[RotationDesc(ActionID.EnAvant)]
	public class DncPvPRotation : DNC_Base
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
        private static IBaseAction PvP_Fountaincombo { get; } = new BaseAction(ActionID.PvP_Fountaincombo)
            {

            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Cascade { get; } = new BaseAction(ActionID.PvP_Cascade)
            {

            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Fountain { get; } = new BaseAction(ActionID.PvP_Fountain)
            {

            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Starfalldance { get; } = new BaseAction(ActionID.PvP_Starfalldance)
            {
                StatusProvide = new StatusID[1] { (StatusID)3161 },
            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Honingdance { get; } = new BaseAction(ActionID.PvP_Honingdance)
            {
                StatusProvide = new StatusID[2] { (StatusID)3162, (StatusID)3163 },
            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Fandance { get; } = new BaseAction(ActionID.PvP_Fandance)
            {

            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Curingwaltz { get; } = new BaseAction(ActionID.PvP_Curingwaltz, ActionOption.Heal)
            {

            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Enavant { get; } = new BaseAction(ActionID.PvP_Enavant)
            {
                StatusProvide = new StatusID[1] { (StatusID)2048 },
            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Closedposition { get; } = new BaseAction(ActionID.PvP_Closedposition)
            {

            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Reversecascade { get; } = new BaseAction(ActionID.PvP_Reversecascade)
            {
                StatusProvide = new StatusID[1] { (StatusID)3159 },
                StatusNeed = new StatusID[1] { (StatusID)2048 },
            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Fountainfall { get; } = new BaseAction(ActionID.PvP_Fountainfall)
            {
                StatusProvide = new StatusID[1] { (StatusID)3159 },
                StatusNeed = new StatusID[1] { (StatusID)2048 },
            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Saberdance { get; } = new BaseAction(ActionID.PvP_Saberdance)
            {
                StatusNeed = new StatusID[1] { (StatusID)3160 },
            };


            /// <summary>
            /// 
            /// </summary>
            private static IBaseAction PvP_Honingovation { get; } = new BaseAction(ActionID.PvP_Honingovation)
            {

            };


            /// <summary>
            /// 
            /// </summary>
            public static IBaseAction PvP_Contradance { get; } = new BaseAction(ActionID.PvP_Contradance)
            {
                FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
                ActionCheck = (t, m) => LimitBreakLevel >= 1,
            };

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia DNC(PvP)";
		public override string Description => "PvP Rotation for DNC.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;


        protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
			.SetInt(CombatType.PvP, "CDValue", 50000, "LB:コントラダンスを行うために必要な敵のHPは？", 1, 100000)
			//.SetBool(CombatType.PvP, "Repelling", true, "リペリングショットを使用します。")
			//.SetBool(CombatType.PvP, "Empyreal", true, "エンピリアルアローを常にチャージ３で使用します。")
			//.SetBool(CombatType.PvP, "ThunderclapPvP", true, "Use Thunderclap")
			.SetInt(CombatType.PvP, "CWValue", 40000, "癒やしのワルツを実行するプレイヤーのHPは？", 1, 100000)
            .SetBool(CombatType.PvP, "Enavant", false, "アン・アヴァンを使用します。")
            .SetBool(CombatType.PvP, "HDance", true, "刃の舞いを使用します。")
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
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("GuardPvP") && Player.CurrentHp < Configs.GetInt("GuardValue") && InCombat &&
                PvP_Recuperate.CanUse(out act, CanUseOption.MustUse)) return true;
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


			if (Configs.GetBool("LBInPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("CDValue") && PvP_Contradance.IsEnabled)
			{
				if (PvP_Contradance.CanUse(out act, CanUseOption.MustUse)) return true;
			}

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) &&
                PvP_Starfalldance.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("HDance") &&
                PvP_Honingdance.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_EnAvant) &&
                PvP_Reversecascade.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_EnAvant) &&
                PvP_Fountainfall.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_FlourishingSaberDance) &&
                PvP_Saberdance.CanUse(out act, CanUseOption.MustUse)) return true;


            if (PvP_Fountain.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_Cascade.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_Fountaincombo.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

		protected override bool AttackAbility(out IAction act)
		{
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) &&
                PvP_Fandance.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.CurrentHp < Configs.GetInt("CWValue") &&
                PvP_Curingwaltz.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("Enavant") && !Player.HasStatus(true, StatusID.PvP_EnAvant) &&
                PvP_Enavant.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

			return base.AttackAbility(out act);
		}
    }
}