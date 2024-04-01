using Dalamud.Game.ClientState.Objects.SubKinds;



namespace LeliaRotations.Magical;


[RotationDesc(ActionID.SearingLight)]
	public class SmnPvPRotation : SMN_Base
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

    #endregion

    public override string GameVersion => "6.51";
		public override string RotationName => "Lelia SMN(PvP)";
		public override string Description => "PvP Rotation for SMN.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

    protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
        .SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
        .SetInt(CombatType.PvP, "SBValue", 30, "LB:サモン・バハムートを行うために必要なターゲットのHPPは？", 1, 100)
        .SetInt(CombatType.PvP, "SPValue", 40, "LB:サモン・フェニックスを行うために必要なプレイヤーのHPPは？", 1, 100)
        //.SetInt(CombatType.PvP, "HSValue", 40000, "	ホーリーシェルトロンを使用するプレイヤーのHPは？", 1, 100000)
        .SetBool(CombatType.PvP, "CCPvP", true, "クリムゾンサイクロンを使用しますか？")
        .SetInt(CombatType.PvP, "CrimsonValue", 20000, "クリムゾンサイクロンを使用するターゲットのHPは？", 1, 100000)
        .SetBool(CombatType.PvP, "RadiantA", true, "守りの光を使用しますか？")
        .SetInt(CombatType.PvP, "RAValue", 40, "守りの光を使用するプレイヤーのHPPは？", 1, 100)
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


            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget &&
                ((HostileTarget.CurrentHp / HostileTarget.MaxHp) * 100) <= Configs.GetInt("SBValue") && ((Player.CurrentHp / Player.MaxHp) * 100) >= Configs.GetInt("SPValue") && PvP_SummonBahamut.IsEnabled)
            {
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_SummonBahamut.CanUse(out act, CanUseOption.MustUse)) return true;
            }
            else if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget &&
                ((HostileTarget.CurrentHp / HostileTarget.MaxHp) * 100) <= Configs.GetInt("SPValue") && ((Player.CurrentHp / Player.MaxHp) * 100) < Configs.GetInt("SPValue") && PvP_SummonPhoenix.IsEnabled)
            {
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_SummonPhoenix.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            //if (Configs.GetBool("CCPvP"))
            //    {
            //        if ((HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("CrimsonValue"))
            //            && PvP_CrimsonCyclone.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //    }
            if (Configs.GetBool("CCPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("CrimsonValue") && 
                PvP_CrimsonCyclone.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //if (PvP_CrimsonStrike.IsEnabled && PvP_CrimsonStrike.CanUse(out act, CanUseOption.MustUse)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && 
                PvP_Slipstream.CanUse(out act, CanUseOption.MustUse)) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_DreadwyrmTrance) &&
                PvP_AstralImpulse.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_FirebirdTrance) &&
                PvP_FountainOfFire.CanUse(out act, CanUseOption.MustUse)) return true;


            if (PvP_Ruin3.CanUse(out act, CanUseOption.MustUse)) return true;

        if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
        if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

    protected override bool AttackAbility(out IAction act)
    {
        if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard))
        {
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) &&
                PvP_MountainBuster.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && InCombat &&
                PvP_Fester.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

        }
        if (Configs.GetBool("RadiantA") && ((Player.CurrentHp / Player.MaxHp) * 100) <= Configs.GetInt("RAValue") &&
            PvP_RadiantAegis.CanUse(out act, CanUseOption.MustUse)) return true;

        return base.AttackAbility(out act);
    }


}
