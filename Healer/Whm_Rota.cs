using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Healer
{

	[RotationDesc(ActionID.AfflatusSolace)]
	public class WhmPvPRotation : WHM_Base
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
        //public static IBaseAction PvP_Glare3 { get; } = new BaseAction(ActionID.PvP_Glare3);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Cure2 { get; } = new BaseAction((ActionID)29224, ActionOption.Heal);

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_AfflatusMisery { get; } = new BaseAction(ActionID.PvP_AfflatusMisery);

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_Aquaveil { get; } = new BaseAction(ActionID.PvP_Aquaveil);

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_MiracleOfNature { get; } = new BaseAction(ActionID.PvP_MiracleOfNature);

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_SeraphStrike { get; } = new BaseAction(ActionID.PvP_SeraphStrike);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Cure3 { get; } = new BaseAction((ActionID)29225)
        {
            StatusNeed = new StatusID[1] { StatusID.PvP_Cure3Ready },
        };

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_AfflatusPurgation { get; } = new BaseAction(ActionID.PvP_AfflatusPurgation)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Glare3 { get; } = new BaseAction(ActionID.PvP_Glare3);

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_Cure2 { get; } = new BaseAction(ActionID.PvP_Cure2, ActionOption.Heal);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_AfflatusMisery { get; } = new BaseAction(ActionID.PvP_AfflatusMisery);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Aquaveil { get; } = new BaseAction(ActionID.PvP_Aquaveil, ActionOption.Defense);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_MiracleOfNature { get; } = new BaseAction(ActionID.PvP_MiracleOfNature);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_SeraphStrike { get; } = new BaseAction(ActionID.PvP_SeraphStrike);

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_Cure3 { get; } = new BaseAction(ActionID.PvP_Cure3, ActionOption.Heal)
        //{
        //    StatusNeed = new StatusID[] { StatusID.PvP_Cure3Ready },
        //};

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_AfflatusPurgation { get; } = new BaseAction(ActionID.PvP_AfflatusPurgation)
        //{
        //    FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
        //    ActionCheck = (t, m) => LimitBreakLevel >= 1,
        //};

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia WHM(PvP)";
		public override string Description => "PvP Rotation for WHM";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

        protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
            .SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            .SetInt(CombatType.PvP, "APValue", 30000, "LB:AfflatusPurgationを行うために必要な敵のHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "Cure2Value", 30000, "ケアルラを使用するプレイヤーのHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "AquaValue", 40000, "アクアヴェールを使用するプレイヤーのHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "MiracleOfNatureValue", 40000, "ミラクル・オブ・ネイチャーを使用する時の敵側のHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "SeraphStrikeValue", 25000, "セラフストライクを使用する時の敵側のHPは？", 1, 100000)
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


			if (Configs.GetBool("LBInPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("APValue") && PvP_AfflatusPurgation.CanUse(out act, CanUseOption.MustUse)) return true;

			if (Player.CurrentHp < Configs.GetInt("Cure2Value") && PvP_Cure2.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_AfflatusMisery.CanUse(out act, CanUseOption.MustUse)) return true;


            //if (PvP_Cure3.CanUse(out act, CanUseOption.MustUse)) return true;
            if (Player.HasStatus(true, StatusID.PvP_Cure3Ready) && PvP_Cure3.CanUse(out act, CanUseOption.MustUse)) return true;



            if (PvP_Glare3.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
            //return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.CurrentHp < Configs.GetInt("AquaValue") && PvP_Aquaveil.CanUse(out act, CanUseOption.MustUse)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("MiracleOfNatureValue") && PvP_MiracleOfNature.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("SeraphStrikeValue") && PvP_SeraphStrike.CanUse(out act, CanUseOption.MustUse)) return true;

            return base.AttackAbility(out act);
        }

    }
}