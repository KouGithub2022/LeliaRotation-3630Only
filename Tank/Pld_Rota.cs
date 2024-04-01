using Dalamud.Game.ClientState.Objects.SubKinds;


namespace LeliaRotations.Tank
{

    [RotationDesc(ActionID.Intervene)]
	public class PldPvPRotation : PLD_Base
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
        public static IBaseAction PvP_Fastblade { get; } = new BaseAction(ActionID.PvP_Fastblade);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Riotblade { get; } = new BaseAction(ActionID.PvP_Riotblade);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Royalauthority { get; } = new BaseAction(ActionID.PvP_Royalauthority);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Confiteor { get; } = new BaseAction(ActionID.PvP_Confiteor);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Shieldbash { get; } = new BaseAction(ActionID.PvP_Shieldbash);


        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_Intervene { get; } = new BaseAction(ActionID.PvP_Intervene);

        /// <summary>
        /// Rushes target and delivers an attack with a potency of 2,000.
        /// Additional Effect: Grants a stack of Sword Oath, up to a maximum of 3
        /// </summary>
        private static IBaseAction PvP_Intervene { get; } = new BaseAction(ActionID.PvP_Intervene)
        {
            // Sword Oath ID = 1991
            StatusProvide = new StatusID[1] { (StatusID)1991 },
        };


        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_Guardian { get; } = new BaseAction(ActionID.PvP_Guardian);

        /// <summary>
        /// Rush to a target party member's side.
        /// Additional Effect: Take all damage intended for the targeted party member
        /// </summary>
        [Obsolete]
        private static IBaseAction PvP_Guardian { get; } = new BaseAction(ActionID.PvP_Guardian, ActionOption.Friendly)
        {
            ActionCheck = (BattleChara b, bool m) => Target.DistanceToPlayer() <= 10,
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_HolySheltron { get; } = new BaseAction(ActionID.PvP_HolySheltron);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Atonement { get; } = new BaseAction(ActionID.PvP_Atonement);


        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_BladeOfFaith { get; } = new BaseAction(ActionID.PvP_BladeOfFaith)
        //{
        //    StatusNeed = new StatusID[] { StatusID.PvP_ReadyForBladeOfFaith
        //}:


        /// <summary>
        /// Deals unaspected damage with a potency of 6,000
        /// </summary>
        private static IBaseAction PvP_BladeOfFaith { get; } = new BaseAction(ActionID.PvP_BladeOfFaith)
        {
            // Blade of Faith Ready ID = 3250
            StatusNeed = new StatusID[1] { (StatusID)3250 },
            // Sacred Claim ID = 3025
            TargetStatus = new StatusID[1] { (StatusID)3025 },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_BladeOfTruth { get; } = new BaseAction(ActionID.PvP_BladeOfTruth);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_BladeOfValor { get; } = new BaseAction(ActionID.PvP_BladeOfValor);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Phalanx { get; } = new BaseAction(ActionID.PvP_Phalanx)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };


        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia PLD(PvP)";
		public override string Description => "PvP Rotation for PLD.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            .SetInt(CombatType.PvP, "PHValue", 30000, "LB:ファランクスを行うために必要なプレイヤーのHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "HSValue", 40000, "	ホーリーシェルトロンを使用するプレイヤーのHPは？", 1, 100000)
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


            //if (Configs.GetBool("LBInPvP") && PvP_RelentlessRush.Target.CurrentHp < Configs.GetInt("RRValue") && PvP_RelentlessRush.IsEnabled && InCombat)
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("PHValue") && PvP_Phalanx.IsEnabled)
            {
                if (PvP_Phalanx.CanUse(out act, CanUseOption.MustUse)) return true;
                
            }
            //if (PvP_Phalanx.IsEnabled && PvP_Phalanx.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_BladeOfValor.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_BladeOfTruth.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_BladeOfFaith.CanUse(out act, CanUseOption.MustUse)) return true;
            //if (PvP_Phalanx.IsCoolingDown && PvP_Phalanx.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            //if (!PvP_Phalanx.IsEnabled)
            //{
            //    act = PvP_BladeOfFaith;
            //   return true;
            //}

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Confiteor.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;


            if (PvP_Royalauthority.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_Riotblade.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_Fastblade.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Shieldbash.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Intervene.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Guardian.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.CurrentHp <= Configs.GetInt("HSValue") && PvP_HolySheltron.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;



            return base.AttackAbility(out act);
        }


    }
}
