using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Healer
{
	[RotationDesc(ActionID.PrimalRend)]
	public class SgePvPRotation : SGE_Base
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
        public static IBaseAction PvP_Dosis3 { get; } = new BaseAction(ActionID.PvP_Dosis);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Phlegma3 { get; } = new BaseAction(ActionID.PvP_Phlegma3);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Pneuma { get; } = new BaseAction(ActionID.PvP_Pneuma);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Eukrasia { get; } = new BaseAction(ActionID.PvP_Eukrasia,ActionOption.Buff);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Icarus { get; } = new BaseAction(ActionID.PvP_Icarus);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Toxikon { get; } = new BaseAction(ActionID.PvP_Toxikon);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Kardia { get; } = new BaseAction(ActionID.PvP_Kardia);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_EukrasianDosis3 { get; } = new BaseAction(ActionID.PvP_EukrasianDosis2,ActionOption.Buff);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Toxikon2 { get; } = new BaseAction(ActionID.PvP_Toxikon2);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Mesotes { get; } = new BaseAction(ActionID.PvP_Mesotes)
    {
        FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
        ActionCheck = (t, m) => LimitBreakLevel >= 1,
    };


    #endregion

		public override string GameVersion => "6.51";
		public override string RotationName => "Lelia SGE(PvP)";
		public override string Description => "PvP Rotation for SGE. \n This skill is manual operation.:Icarus,Kardia,Mesotes";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

        protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
            //.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            //			.SetInt(CombatType.PvP, "CRValue", 30000, "How much HP does the enemy have for LB:PCelestialRiver to be done", 1, 100000)
            //			.SetInt(CombatType.PvP, "DAValue", 30000, "How much HP does the enemy have for Burst_Attack to be done", 1, 100000)
            //			.SetInt(CombatType.PvP, "DHValue", 30000, "How much HP does the player have for Burst_Heal to be done", 1, 100000)
            //.SetInt(CombatType.PvP, "ABValue", 60000, "アスペクト・ベネフィクを使うプレイヤーHPの最低値", 1, 100000)
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



//			if (PvP_Onslaught.CanUse(out act, CanUseOption.MustUse) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("OSValue")) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Phlegma3.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Pneuma.CanUse(out act, CanUseOption.MustUse)) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Eukrasia.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Toxikon.CanUse(out act, CanUseOption.MustUse)) return true;

//			if (PvP_EukrasianDosis3.CanUse(out act, CanUseOption.MustUse)) return true;

			if (PvP_Dosis3.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
            //return false;
			#endregion
		}
        protected override bool AttackAbility(out IAction act)
        {
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_Addersting) && PvP_Toxikon2.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Toxikon.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            return base.AttackAbility(out act);
        }

    }
}
