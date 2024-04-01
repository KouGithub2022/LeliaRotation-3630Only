using Dalamud.Game.ClientState.Objects.SubKinds;


namespace LeliaRotations.Melee
{

    [RotationDesc(ActionID.ElusiveJump)]
	public class DrgPvPRotation : DRG_Base
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
        public static IBaseAction PvP_RaidenThrust { get; } = new BaseAction(ActionID.PvP_RaidenThrust);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_FangAndClaw { get; } = new BaseAction(ActionID.PvP_FangAndClaw);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_WheelingThrust { get; } = new BaseAction(ActionID.PvP_WheelingThrust);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_ChaoticSpring { get; } = new BaseAction(ActionID.PvP_ChaoticSpring);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Geirskogul { get; } = new BaseAction(ActionID.PvP_Geirskogul)
        {
            //StatusProvide = new StatusID[] { StatusID.PvP_LifeOfTheDragon },
            StatusProvide = new StatusID[1] { (StatusID)3177 },
        };


        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_HighJump { get; } = new BaseAction(ActionID.PvP_HighJump, ActionOption.Buff);
        [Obsolete]
        public static IBaseAction PvP_HighJump { get; } = new BaseAction(ActionID.PvP_HighJump)
        {
            ActionCheck = (BattleChara b, bool m) => Target.DistanceToPlayer() <= 20,
            StatusProvide = new StatusID[] { StatusID.PvP_Heavensent },
        };

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_ElusiveJump { get; } = new BaseAction(ActionID.PvP_ElusiveJump)
        {
            StatusProvide = new StatusID[] { StatusID.PvP_FirstmindsFocus },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_HorridRoar { get; } = new BaseAction(ActionID.PvP_HorridRoar);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_HeavensThrust { get; } = new BaseAction(ActionID.PvP_HeavensThrust)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_Heavensent },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Nastrond { get; } = new BaseAction(ActionID.PvP_Nastrond)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_LifeOfTheDragon },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_WyrmwindThrust { get; } = new BaseAction(ActionID.PvP_WyrmwindThrust)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_FirstmindsFocus },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_SkyHigh { get; } = new BaseAction(ActionID.PvP_SkyHigh)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_SkyShatter { get; } = new BaseAction(ActionID.PvP_SkyShatter)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia DRG(PvP)";
		public override string Description => "PvP Rotation for ERG.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
            //.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            //.SetInt(CombatType.PvP, "PHValue", 30000, "LB:ファランクスを行うために必要なプレイヤーのHPは？", 1, 100000)
            //.SetInt(CombatType.PvP, "HSValue", 40000, "	ホーリーシェルトロンを使用するプレイヤーのHPは？", 1, 100000)
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


            //if (Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("APValue") && PvP_AfflatusPurgation.CanUse(out act, CanUseOption.MustUse)) return true;

            //Ability
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_HighJump.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 20) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_ElusiveJump.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 5) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Geirskogul.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 15) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Nastrond.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 15) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_HorridRoar.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 5) return true;
            ////////////////////////////////////////

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_WyrmwindThrust.CanUse(out act, CanUseOption.MustUse)) return true;
            //if (Player.HasStatus(true, StatusID.PvP_FirstmindsFocus)
            //    && PvP_WyrmwindThrust.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_HeavensThrust.CanUse(out act, CanUseOption.MustUse)) return true;
            //if (Player.HasStatus(true, StatusID.PvP_Heavensent)
            //    && PvP_HeavensThrust.CanUse(out act, CanUseOption.MustUse)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_ChaoticSpring.CanUse(out act, CanUseOption.MustUse)) return true;

            if (PvP_WheelingThrust.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_FangAndClaw.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_RaidenThrust.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            //return base.GeneralGCD(out act);
            return false;
			#endregion
		}

        //protected override bool AttackAbility(out IAction act)
        //{
        //    if (PvP_HighJump.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 20) return true;
        //    if (PvP_ElusiveJump.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 5) return true;
        //    if (PvP_Geirskogul.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 15 && HostileTarget.DistanceToPlayer() >= 0) return true;
        //    if (PvP_Nastrond.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 15) return true;
        //    if (PvP_HorridRoar.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 5) return true;
        //    return base.AttackAbility(out act);
        //}


    }
}
