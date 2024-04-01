using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Magical;


[RotationDesc(ActionID.Manaward)]
public class BlmPvPRotation : BLM_Base
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
    public static IBaseAction PvP_Fire { get; } = new BaseAction(ActionID.PvP_Fire);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Blizzard { get; } = new BaseAction(ActionID.PvP_Blizzard);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Burst { get; } = new BaseAction(ActionID.PvP_Burst, ActionOption.Defense);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Paradox { get; } = new BaseAction(ActionID.PvP_Paradox);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Nightwing { get; } = new BaseAction(ActionID.PvP_Nightwing);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_AetherialManipulation { get; } = new BaseAction(ActionID.PvP_AetherialManipulation);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Superflare { get; } = new BaseAction(ActionID.PvP_Superflare);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Fire4 { get; } = new BaseAction(ActionID.PvP_Fire4, ActionOption.Buff)
    {
        StatusNeed = new StatusID[] { StatusID.PvP_AstralFire2 },
    };


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Flare { get; } = new BaseAction(ActionID.PvP_Flare)
    {
        StatusNeed = new StatusID[] { StatusID.PvP_AstralFire3 },
    };


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Blizzard4 { get; } = new BaseAction(ActionID.PvP_Blizzard4, ActionOption.Buff)
    {
        StatusNeed = new StatusID[] { StatusID.PvP_UmbralIce2 },
    };


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Freeze { get; } = new BaseAction(ActionID.PvP_Freeze)
    {
        StatusNeed = new StatusID[] { StatusID.PvP_UmbralIce3 },
    };


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Foul { get; } = new BaseAction(ActionID.PvP_Foul)
    {
        StatusNeed = new StatusID[] { StatusID.PvP_Polyglot },
    };


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_SoulResonance { get; } = new BaseAction(ActionID.PvP_SoulResonance)
    {
        FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
        ActionCheck = (t, m) => LimitBreakLevel >= 1,
    };

    #endregion

    public override string GameVersion => "6.51";
	public override string RotationName => "Lelia BLM(PvP)";
	public override string Description => "PvP Rotation for BLM";
	public override CombatType Type => CombatType.PvP;
	public override bool ShowStatus => true;

	protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
		.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
		.SetInt(CombatType.PvP, "SRValue", 30000, "LB:SoulResonanceを行うために必要な敵のHPは？", 1, 100000)
		.SetBool(CombatType.PvP, "AMInPvP", true, "エーテリアルステップを使用します。")
		.SetInt(CombatType.PvP, "AMValue", 25000, "エーテリアルステップを行うために必要な敵のHPは？", 1, 100000)
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


		if (Configs.GetBool("LBInPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("SRValue") && PvP_SoulResonance.IsEnabled )
		{
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_SoulResonance.CanUse(out act, CanUseOption.MustUse)) return true;

			//if (PvP_Superflare.CanUse(out act, CanUseOption.MustUse)) return true;
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Foul.CanUse(out act, CanUseOption.MustUse)) return true;
                //if (PvP_AetherialManipulation.CanUse(out act, CanUseOption.MustUse)) return true;
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Burst.CanUse(out act, CanUseOption.MustUse)) return true;
			if (HostileTarget.HasStatus(true, StatusID.PvP_AstralWarmth) || HostileTarget.HasStatus(true, StatusID.PvP_UmbralFreeze))
			{
				if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Paradox.CanUse(out act, CanUseOption.MustUse)) return true;
			}
		    if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Blizzard.CanUse(out act, CanUseOption.MustUse)) return true;
		}

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Burst.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (HostileTarget.HasStatus(true, StatusID.PvP_AstralWarmth) || HostileTarget.HasStatus(true, StatusID.PvP_UmbralFreeze))
            {
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Paradox.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Burst.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            if (PvP_Blizzard.CanUse(out act, CanUseOption.MustUse)) return true;

        if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
        if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
            PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
        return base.GeneralGCD(out act);
            //return false;
		#endregion
	}
        protected override bool AttackAbility(out IAction act)
        {
            if (Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("SRValue") && PvP_SoulResonance.IsEnabled)
            {
                //if (PvP_SoulResonance.CanUse(out act, CanUseOption.MustUse)) return true;

                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Superflare.CanUse(out act, CanUseOption.MustUse)) return true;
                //if (PvP_Foul.CanUse(out act, CanUseOption.MustUse)) return true;
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("AMInPvP") && PvP_AetherialManipulation.CanUse(out act, CanUseOption.MustUse)) return true;
                //if (PvP_Burst.CanUse(out act, CanUseOption.MustUse)) return true;
                //if (PvP_Paradox.CanUse(out act, CanUseOption.MustUse)) return true;

                //if (PvP_Blizzard.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("AMInPvP") && PvP_AetherialManipulation.CanUse(out act, CanUseOption.MustUse) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("AMValue")) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Nightwing.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Superflare.CanUse(out act, CanUseOption.MustUse) && HostileTarget && HostileTarget.DistanceToPlayer() < 9 && InCombat) return true;

            return base.AttackAbility(out act);
        }

    }
