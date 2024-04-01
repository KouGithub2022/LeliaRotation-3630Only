using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Melee
{

	[RotationDesc(ActionID.Brotherhood)]
	public class MnkPvPRotation : MNK_Base
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
        public static IBaseAction PvP_Enlightenment { get; } = new BaseAction(ActionID.PvP_Enlightenment)
        {
            TargetStatus = new StatusID[1] { (StatusID)3172 },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Phantomrushcombo { get; } = new BaseAction(ActionID.PvP_Phantomrushcombo);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Bootshine { get; } = new BaseAction(ActionID.PvP_Bootshine);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Truestrike { get; } = new BaseAction(ActionID.PvP_Truestrike);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Snappunch { get; } = new BaseAction(ActionID.PvP_Snappunch);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Dragonkick { get; } = new BaseAction(ActionID.PvP_Dragonkick);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Twinsnakes { get; } = new BaseAction(ActionID.PvP_Twinsnakes);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Demolish { get; } = new BaseAction(ActionID.PvP_Demolish);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Phantomrush { get; } = new BaseAction(ActionID.PvP_Phantomrush);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Sixsidedstar { get; } = new BaseAction(ActionID.PvP_Sixsidedstar);

        /// <summary>
        /// 
        /// </summary>
        //public static IBaseAction PvP_Enlightenment { get; } = new BaseAction(ActionID.PvP_Enlightenment);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Risingphoenix { get; } = new BaseAction(ActionID.PvP_Risingphoenix, ActionOption.Buff);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Riddleofearth { get; } = new BaseAction(ActionID.PvP_Riddleofearth, ActionOption.Buff);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Thunderclap { get; } = new BaseAction(ActionID.PvP_Thunderclap);

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Earthsreply { get; } = new BaseAction(ActionID.PvP_Earthsreply, ActionOption.Buff)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_EarthResonance },
        };

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Meteodrive { get; } = new BaseAction((ActionID)29485)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia MNK(PvP)";
		public override string Description => "PvP Rotation for MNK";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            .SetInt(CombatType.PvP, "MDValue", 30000, "LB:メテオドライヴを行うために必要な敵のHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "ENValue", 60000, "万象闘気圏を行うために必要な敵のHPは？", 1, 100000)
            .SetBool(CombatType.PvP, "TCInPvP", true, "抜重歩法を個別に使用します。")
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


			if (Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("MDValue") && PvP_Phantomrush.IsEnabled && PvP_Meteodrive.IsEnabled && InCombat)
			{
				if (PvP_Risingphoenix.CanUse(out act, CanUseOption.MustUse)) return true;
				//if (!PvP_Enlightenment.IsCoolingDown && InCombat)
				//{
                //    if (PvP_Enlightenment.CanUse(out act, CanUseOption.MustUse)) return true;
                //    //act = PvP_Enlightenment;
				//	//return true;
                //}
				if (HostileTarget && PvP_Enlightenment.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_Sixsidedstar.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_Meteodrive.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
				if (PvP_Risingphoenix.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_Phantomrush.CanUse(out act, CanUseOption.MustUse)) return true;
 				
			}

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_Sprint) && !PvP_Enlightenment.IsCoolingDown && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("ENValue") && InCombat)
            {
                if (HostileTarget && PvP_Enlightenment.CanUse(out act, CanUseOption.MustUse)) return true;
                //act = PvP_Enlightenment;
                //return true;
            }
            //if (PvP_Enlightenment.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

			if (PvP_Phantomrush.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Demolish.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Twinsnakes.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Dragonkick.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Snappunch.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Truestrike.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_Bootshine.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
            //return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("MDValue") && PvP_Phantomrush.IsEnabled && PvP_Meteodrive.IsEnabled && InCombat)
            {
                if (PvP_Risingphoenix.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
                //if (PvP_Enlightenment.CanUse(out act, CanUseOption.MustUse)) return true;
                if (PvP_Sixsidedstar.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
                //if (PvP_Meteodrive.CanUse(out act, CanUseOption.MustUse)) return true;
                if (PvP_Risingphoenix.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
                //if (PvP_Phantomrush.CanUse(out act, CanUseOption.MustUse)) return true;

            }

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("TCInPvP") && HostileTarget && InCombat)
            {
                if (PvP_Thunderclap.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            }
            else
            {
                if (PvP_Thunderclap.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
            }

            //if (PvP_Thunderclap.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Sixsidedstar.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //if (PvP_Enlightenment.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Risingphoenix.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Riddleofearth.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_EarthResonance) && InCombat)
            {
                if (PvP_Earthsreply.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            return base.AttackAbility(out act);
        }
    }
}
