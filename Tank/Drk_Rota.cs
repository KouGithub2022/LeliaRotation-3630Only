using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Tank
{

	[RotationDesc(ActionID.Plunge)]
	public class DrkPvPRotation : DRK_Base
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
        public static IBaseAction PvP_HardSlash { get; } = new BaseAction(ActionID.PvP_HardSlash);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_SyphonStrike { get; } = new BaseAction(ActionID.PvP_SyphonStrike);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_SoulEater { get; } = new BaseAction(ActionID.PvP_SoulEater);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Quietus { get; } = new BaseAction(ActionID.PvP_Quietus,ActionOption.Buff);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Shadowbringer { get; } = new BaseAction(ActionID.PvP_Shadowbringer, ActionOption.Defense)
        {
            StatusProvide = new StatusID[] { (StatusID)3033 },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Shadowbringer2 { get; } = new BaseAction((ActionID)29738, ActionOption.Defense)
        {
            StatusProvide = new StatusID[] { (StatusID)3033 },
        };

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Plunge { get; } = new BaseAction(ActionID.PvP_Plunge);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_BlackestNight { get; } = new BaseAction(ActionID.PvP_BlackestNight,ActionOption.Buff);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Bloodspiller { get; } = new BaseAction(ActionID.PvP_Bloodspiller)
    {
        StatusNeed = new StatusID[] { StatusID.PvP_Blackblood },
    };

    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_SaltedEarth { get; } = new BaseAction(ActionID.PvP_SaltedEarth,ActionOption.Buff);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_SaltAndDarkness { get; } = new BaseAction(ActionID.PvP_SaltAndDarkness,ActionOption.Buff);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Eventide { get; } = new BaseAction(ActionID.PvP_Eventide,ActionOption.Buff)
    {
        FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
        ActionCheck = (t, m) => LimitBreakLevel >= 1,
    };


    #endregion

		public override string GameVersion => "6.51";
		public override string RotationName => "Lelia DRK(PvP)";
		public override string Description => "PvP Rotation for DRK. \n This skill is manual operation.:Shadowbringer";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            .SetInt(CombatType.PvP, "EVValue", 20000, "LB:イーブンタイドを行うために必要なプレイヤーのHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "SBValue", 45000, "	シャドウブリンガーを使用するプレイヤーのHPは？", 1, 100000)
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


            //if (HostileTarget && PvP_Eventide.IsEnabled && PvP_Guard.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget && Player.CurrentHp < Configs.GetInt("EVValue") && PvP_Eventide.IsEnabled)
			{
				if (PvP_Eventide.CanUse(out act, CanUseOption.MustUse)) return true;
			}
   
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Quietus.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
   
			
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_Blackblood) && PvP_Bloodspiller.CanUse(out act, CanUseOption.MustUse)) return true;





            if (PvP_SoulEater.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_SyphonStrike.CanUse(out act, CanUseOption.MustUse)) return true;
			if (PvP_HardSlash.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {
            //if (PvP_Shadowbringer.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //if (PvP_Shadowbringer2.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //if (HostileTarget && PvP_Eventide.IsEnabled && PvP_Guard.CanUse(out act, CanUseOption.MustUse)) return true;
            //if (((!PvP_Shadowbringer.IsCoolingDown && HostileTarget && Player.CurrentHp > Configs.GetInt("SBValue")) || (Player.HasStatus(true, StatusID.PvP_UndeadRedemption) || Player.HasStatus(true, StatusID.PvP_DarkArts))) && PvP_Shadowbringer.CanUse(out act, CanUseOption.MustUse))
            //{
            //    return true;
            //}
            if (!Player.HasStatus(true, StatusID.PvP_Sprint) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && (!PvP_Shadowbringer.IsCoolingDown && Player.CurrentHp > Configs.GetInt("SBValue")) || 
                Player.HasStatus(true, StatusID.PvP_UndeadRedemption) || 
                Player.HasStatus(true, StatusID.PvP_DarkArts) || 
                Player.HasStatus(true, StatusID.PvP_UndeadRedemption) && Player.HasStatus(true, StatusID.PvP_Guard))
            {
                //if (PvP_Shadowbringer.CanUse(out act, CanUseOption.MustUseEmpty, 1))
                //{
                //    return true;
                //}
                //if (PvP_Shadowbringer2.CanUse(out act, CanUseOption.MustUseEmpty, 1))
                //{
                //    return true;
                //}
                act = PvP_Shadowbringer;
                return true;
            }

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_UndeadRedemption) && !PvP_BlackestNight.IsCoolingDown && PvP_BlackestNight.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_UndeadRedemption) && !PvP_Plunge.IsCoolingDown && PvP_Plunge.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_UndeadRedemption) && !PvP_SaltAndDarkness.IsCoolingDown && Player.HasStatus(true, StatusID.PvP_SaltedEarthDMG) && PvP_SaltAndDarkness.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_UndeadRedemption) && !PvP_SaltedEarth.IsCoolingDown && PvP_SaltedEarth.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            return base.AttackAbility(out act);
        }


    }
}
