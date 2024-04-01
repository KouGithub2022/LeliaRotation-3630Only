using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Healer
{
	[RotationDesc(ActionID.ChainStratagem)]
	public class SchRotation : SCH_Base
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
        private static IBaseAction PvP_Broil { get; } = new BaseAction(ActionID.PvP_Broil)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Adloquilum { get; } = new BaseAction(ActionID.PvP_Adloquilum)
        {
            TargetStatus = new StatusID[2] { (StatusID)3087, (StatusID)3088 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Biolysis { get; } = new BaseAction(ActionID.PvP_Biolysis)
        {
            TargetStatus = new StatusID[2] { (StatusID)3089, (StatusID)3090 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_DeploymentTactics { get; } = new BaseAction(ActionID.PvP_DeploymentTactics)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Mummification { get; } = new BaseAction(ActionID.PvP_Mummification)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Expedient { get; } = new BaseAction(ActionID.PvP_Expedient)
        {
            StatusProvide = new StatusID[3] { (StatusID)3092, (StatusID)3093, (StatusID)3094 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Consolation { get; } = new BaseAction(ActionID.PvP_Consolation)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_SeraphicVeil { get; } = new BaseAction(ActionID.PvP_SeraphicVeil, ActionOption.Heal)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_SummonSeraph { get; } = new BaseAction(ActionID.PvP_SummonSeraph)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia SCH(PvP)";
		public override string Description => "PvP Rotation for SCH";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

        protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
            .SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            .SetInt(CombatType.PvP, "SSValue", 30000, "LB:サモン・セラフィムを行うために必要なプレイヤーのHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "AdloqValue", 30000, "鼓舞激励の策を使用するプレイヤーのHPは？", 1, 100000)
            .SetBool(CombatType.PvP, "Expedient", true, "疾風怒濤の計を使用します。")
            //.SetInt(CombatType.PvP, "AquaValue", 40000, "アクアヴェールを使用するプレイヤーのHPは？", 1, 100000)
            //.SetInt(CombatType.PvP, "MiracleOfNatureValue", 40000, "ミラクル・オブ・ネイチャーを使用する時の敵側のHPは？", 1, 100000)
            //.SetInt(CombatType.PvP, "SeraphStrikeValue", 25000, "セラフストライクを使用する時の敵側のHPは？", 1, 100000)
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


            if (Configs.GetBool("LBInPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.CurrentHp < Configs.GetInt("SSValue") &&
            //if (Configs.GetBool("LBInPvP") && !Target.HasStatus(true, StatusID.PvP_Guard) &&
                PvP_SummonSeraph.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Player.CurrentHp < Configs.GetInt("AdloqValue") && 
                PvP_Adloquilum.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) &&
                PvP_Biolysis.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) &&
                PvP_SeraphicVeil.CanUse(out act, CanUseOption.MustUse)) return true;


            if (HostileTarget.HasStatus(true, (StatusID)3089) || HostileTarget.HasStatus(true, (StatusID)3089) ||
                HostileTarget.HasStatus(true, (StatusID)3087) || HostileTarget.HasStatus(true, (StatusID)3088) ||
                HostileTarget.HasStatus(true, (StatusID)3087) || HostileTarget.HasStatus(true, (StatusID)3088))
            {
                    if (PvP_DeploymentTactics.CanUse(out act, CanUseOption.MustUse)) return true;
            }



			if (PvP_Broil.CanUse(out act, CanUseOption.MustUse)) return true;

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
                PvP_Mummification.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (Configs.GetBool("Expedient") &&
                PvP_Expedient.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (PvP_Consolation.IsEnabled && PvP_Consolation.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            return base.AttackAbility(out act);
        }

    }
}