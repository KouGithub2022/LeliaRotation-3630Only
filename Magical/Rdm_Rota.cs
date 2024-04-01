using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Ranged
{

	[RotationDesc(ActionID.CorpsACorps)]
	public class RdmPvPRotation : RDM_Base
	{

        #region PvPDeclaration

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_ApexArrow { get; } = new BaseAction(ActionID.PvP_ApexArrow);


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
        //public static IBaseAction PvP_Guard { get; } = new BaseAction(ActionID.PvP_Guard)
        //{
        //
        //};


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Verstone { get; } = new BaseAction(ActionID.PvP_Verstone)
        {
            StatusProvide = new StatusID[1] { (StatusID)1393 },
            StatusNeed = new StatusID[1] { (StatusID)3245 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Verfire { get; } = new BaseAction(ActionID.PvP_Verfire)
        {
            StatusProvide = new StatusID[1] { (StatusID)1393 },
            StatusNeed = new StatusID[1] { (StatusID)3246 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Veraero3 { get; } = new BaseAction(ActionID.PvP_Veraero3)
        {
            StatusNeed = new StatusID[2] { (StatusID)3245, (StatusID)1393 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Verthunder3 { get; } = new BaseAction(ActionID.PvP_Verthunder3)
        {
            StatusNeed = new StatusID[2] { (StatusID)3246, (StatusID)1393 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Enchantedriposte { get; } = new BaseAction(ActionID.PvP_Enchantedriposte)
        {
            StatusProvide = new StatusID[1] { (StatusID)3234 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Enchantedzwerchhau { get; } = new BaseAction(ActionID.PvP_Enchantedzwerchhau)
        {
            StatusProvide = new StatusID[1] { (StatusID)3235 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Enchantedredoublement { get; } = new BaseAction(ActionID.PvP_Enchantedredoublement)
        {
            TargetStatus = new StatusID[1] { (StatusID)3236 },
            StatusProvide = new StatusID[1] { (StatusID)3233 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Verholy { get; } = new BaseAction(ActionID.PvP_Verholy)
        {
            StatusNeed = new StatusID[2] { (StatusID)3245, (StatusID)3233 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Verflare { get; } = new BaseAction(ActionID.PvP_Verflare)
        {
            StatusNeed = new StatusID[2] { (StatusID)3246, (StatusID)3233 },
        };


        /// <summary>
        /// 
        /// </summary>
    	private static IBaseAction PvP_Resolution { get; } = new BaseAction((ActionID)29695)
        {
            //TargetStatus = new StatusID[2] { (StatusID)1347, (StatusID)1345 },
            //TargetStatus = new StatusID[1] { (StatusID)1347 },
        };


        /// <summary>
        /// 
        /// </summary>
    	private static IBaseAction PvP_Resolution2 { get; } = new BaseAction((ActionID)29696)
        {
            //TargetStatus = new StatusID[2] { (StatusID)1347, (StatusID)1345 },
            //TargetStatus = new StatusID[1] { (StatusID)1345 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Magickbarrier { get; } = new BaseAction(ActionID.PvP_Magickbarrier)
        {
            StatusNeed = new StatusID[1] { (StatusID)3245 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Frazzle { get; } = new BaseAction(ActionID.PvP_Frazzle)
        {
            StatusNeed = new StatusID[1] { (StatusID)3246 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Corpsacorps { get; } = new BaseAction(ActionID.PvP_Corpsacorps)
        {
            TargetStatus = new StatusID[1] { (StatusID)3242 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Displacement { get; } = new BaseAction(ActionID.PvP_Displacement)
        {
            StatusProvide = new StatusID[1] { (StatusID)3243 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Blackshift { get; } = new BaseAction(ActionID.PvP_Blackshift)
        {
            StatusProvide = new StatusID[1] { (StatusID)3246 },
            StatusNeed = new StatusID[1] { (StatusID)3245 },
        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_Whiteshift { get; } = new BaseAction(ActionID.PvP_Whiteshift)
        {
            StatusProvide = new StatusID[1] { (StatusID)3246 },
            StatusNeed = new StatusID[1] { (StatusID)3246 },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_SouthernCross { get; } = new BaseAction(ActionID.PvP_SouthernCross)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };


        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia RDM(PvP)";
		public override string Description => "PvP Rotation for RDM.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;


        protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
            .SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            .SetInt(CombatType.PvP, "SCValue", 30000, "LB:サザンクロスを行うために必要な敵のHPは？", 1, 100000)
            .SetBool(CombatType.PvP, "CCPvP", true, "コル・ア・コルを使います")
            .SetInt(CombatType.PvP, "CCValue", 30000, "How much HP does the enemy have for Thunderclap to be done", 1, 100000)
            .SetBool(CombatType.PvP, "DMPvP", true, "デプラスマンを使います")
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


            //if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("GuardPvP") && ((Player.CurrentHp / Player.MaxHp) * 100) < Configs.GetInt("GuardValue") &&
            //if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("GuardPvP") && Player.GetHealthRatio() <= Configs.GetInt("GuardValue") &&
            //    PvP_Guard.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

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


			if (Configs.GetBool("LBInPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("SCValue") && PvP_SouthernCross.IsEnabled)
			{
				if (PvP_SouthernCross.CanUse(out act, CanUseOption.MustUse)) return true;
			}


            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && Player.HasStatus(true, StatusID.PvP_WhiteShift) && 
                PvP_Resolution.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && Player.HasStatus(true, StatusID.PvP_BlackShift) && 
                PvP_Resolution2.CanUse(out act, CanUseOption.MustUse)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_WhiteShift))
            {
                if (Player.HasStatus(true, StatusID.PvP_VermilionRadiance) && PvP_Verholy.CanUse(out act, CanUseOption.MustUse)) return true;
                if (PvP_Enchantedriposte.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            }
            else
            {
                if (Player.HasStatus(true, StatusID.PvP_VermilionRadiance) && PvP_Verflare.CanUse(out act, CanUseOption.MustUse)) return true;
                if (PvP_Enchantedriposte.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            }


            if (Player.HasStatus(true, StatusID.PvP_WhiteShift))// || Player.HasStatus(true, StatusID.PvP_BlackShift))
            {
                if (PvP_Verstone.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            }
            else
            {
                if (Player.HasStatus(true, StatusID.PvP_Dualcast) && Player.HasStatus(true, StatusID.PvP_BlackShift) &&
                    PvP_Verthunder3.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
                if (PvP_Verfire.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            }


            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;

            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

		protected override bool AttackAbility(out IAction act)
		{
            if (Configs.GetBool("CCPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !PvP_Enchantedriposte.IsCoolingDown &&
                HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("CCValue") &&
                PvP_Corpsacorps.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (Configs.GetBool("CCPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_VermilionRadiance) &&
                PvP_Displacement.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            if (Player.HasStatus(true, StatusID.PvP_WhiteShift))
            {
                if (PvP_Magickbarrier.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            }
            else if (Player.HasStatus(true, StatusID.PvP_BlackShift))
            {
                if (PvP_Frazzle.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            }

            return base.AttackAbility(out act);
		}
    }
}