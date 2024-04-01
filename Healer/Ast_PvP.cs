using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Healer
{
	[RotationDesc(ActionID.Divination)]
	public class AstPvPRotation : AST_Base
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
        public static IBaseAction PvP_FallMalefic { get; } = new BaseAction(ActionID.PvP_FallMalefic);
//    {
//        StatusProvide = PvP_FallMalefic2.StatusNeed,
//    };

    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_AspectedBenefic { get; } = new BaseAction(ActionID.PvP_AspectedBenefic,ActionOption.Heal);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Gravity { get; } = new BaseAction(ActionID.PvP_Gravity);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_DoubleCast { get; } = new BaseAction(ActionID.PvP_DoubleCast);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Draw { get; } = new BaseAction(ActionID.PvP_Draw);
//    public static IBaseAction PvP_Draw { get; } = new BaseAction(ActionID.PvP_Draw)
//    {
//        ActionCheck = (b, m) => DrawnCard == CardType.NONE,
//    };

    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Macrocosmos { get; } = new BaseAction(ActionID.PvP_Macrocosmos,ActionOption.Dot);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_FallMalefic2 { get; } = new BaseAction(ActionID.PvP_FallMalefic2);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_AspectedBenefic2 { get; } = new BaseAction(ActionID.PvP_AspectedBenefic2,ActionOption.Heal);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Gravity2 { get; } = new BaseAction(ActionID.PvP_Gravity2);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_DrawTheBalance { get; } = new BaseAction(ActionID.PvP_DrawTheBalance);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_DrawTheBole { get; } = new BaseAction(ActionID.PvP_DrawTheBole);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_DrawTheArrow { get; } = new BaseAction(ActionID.PvP_DrawTheArrow);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_Microcosmos { get; } = new BaseAction(ActionID.PvP_Microcosmos,ActionOption.Heal);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_CelestialRiver { get; } = new BaseAction(ActionID.PvP_CelestialRiver)
    {
        FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
        ActionCheck = (t, m) => LimitBreakLevel >= 1,
    };


    #endregion

		public override string GameVersion => "6.51";
		public override string RotationName => "Lelia AST(PvP)";
		public override string Description => "PvP Rotation for AST with Sloth";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LB���g�p���܂��B")
//			.SetInt(CombatType.PvP, "CRValue", 30000, "How much HP does the enemy have for LB:PCelestialRiver to be done", 1, 100000)
//			.SetInt(CombatType.PvP, "DAValue", 30000, "How much HP does the enemy have for Burst_Attack to be done", 1, 100000)
//			.SetInt(CombatType.PvP, "DHValue", 30000, "How much HP does the player have for Burst_Heal to be done", 1, 100000)
			.SetInt(CombatType.PvP, "ABValue", 60000, "�A�X�y�N�g�E�x�l�t�B�N���g���v���C���[HP�̍Œ�l", 1, 100000)
            .SetBool(CombatType.PvP, "SprintPvP", true, "�X�v�����g���g���܂��B")
            .SetBool(CombatType.PvP, "RecuperatePvP", true, "���C���g���܂��B")
            .SetInt(CombatType.PvP, "RCValue", 75, "���C���g���v���C���[��HP%%�́H", 1, 100)
            .SetBool(CombatType.PvP, "PurifyPvP", true, "�򉻂��g���܂��B")
            .SetBool(CombatType.PvP, "1343PvP", true, "�X�^��")
            .SetBool(CombatType.PvP, "3219PvP", true, "�X��")
            .SetBool(CombatType.PvP, "3022PvP", true, "���X�ɐ���")
            .SetBool(CombatType.PvP, "1348PvP", true, "����")
            .SetBool(CombatType.PvP, "1345PvP", false, "�o�C���h")
            .SetBool(CombatType.PvP, "1344PvP", false, "�w���B")
            .SetBool(CombatType.PvP, "1347PvP", true, "����")
            .SetBool(CombatType.PvP, "GuardPvP", true, "�h����g��")
            .SetInt(CombatType.PvP, "GuardValue", 15000, "�h����g���v���C���[��HP�́H", 1, 100000)
            .SetBool(CombatType.PvP, "GuardCancel", true, "�������h�䒆�͍U���𒆎~���܂��B");


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

            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("RecuperatePvP") && ((Player.CurrentHp / Player.MaxHp) * 100) < Configs.GetInt("RCValue") &&
                PvP_Recuperate.CanUse(out act, CanUseOption.MustUse)) return true;


			if (Configs.GetBool("LBInPvP") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_CelestialRiver.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            if (PvP_AspectedBenefic.CanUse(out act, CanUseOption.MustUseEmpty) && Player.CurrentHp < Configs.GetInt("ABValue")) return true;

            if (PvP_DrawTheBalance.CanUse(out act, CanUseOption.MustUse) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_BalanceDrawn)) return true;
			if (PvP_DrawTheBole.CanUse(out act, CanUseOption.MustUse) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_BoleDrawn)) return true;
			if (PvP_DrawTheArrow.CanUse(out act, CanUseOption.MustUse) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_ArrowDrawn)) return true;
			if (PvP_Draw.CanUse(out act, CanUseOption.MustUse) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && InCombat) return true;


            if (PvP_Gravity.CanUse(out act, CanUseOption.MustUse) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard)) return true;
            if (PvP_Macrocosmos.CanUse(out act, CanUseOption.MustUse) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && InCombat) return true;

            if (PvP_FallMalefic.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;

            return base.GeneralGCD(out act);
            //return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {
            if (PvP_FallMalefic2.IsEnabled && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_FallMalefic2.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            if (PvP_Gravity2.IsEnabled && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Gravity2.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            if (PvP_AspectedBenefic2.IsEnabled && PvP_AspectedBenefic2.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            //if (PvP_DoubleCast.IsEnabled && PvP_DoubleCast.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            return base.AttackAbility(out act);
            //return false;
        }

    }
}
