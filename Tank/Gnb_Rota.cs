using Dalamud.Game.ClientState.Objects.SubKinds;
//using RotationSolver.Basic.Helpers;

namespace LeliaRotations.Tank
{

	[RotationDesc(ActionID.RoughDivide)]
	public class GnbPvPRotation : GNB_Base
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
        public static IBaseAction PvP_KeenEdge { get; } = new BaseAction(ActionID.PvP_KeenEdge);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_BrutalShell { get; } = new BaseAction(ActionID.PvP_BrutalShell);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_SolidBarrel { get; } = new BaseAction(ActionID.PvP_SolidBarrel);


        /// <summary>
        /// 
        /// </summary>
//        public static IBaseAction PvP_GnashingFang { get; } = new BaseAction(ActionID.PvP_GnashingFang, ActionOption.Buff);
        public static IBaseAction PvP_GnashingFang { get; } = new BaseAction(ActionID.PvP_GnashingFang);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_DoubleDown { get; } = new BaseAction(ActionID.PvP_DoubleDown);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Continuation { get; } = new BaseAction(ActionID.PvP_Continuation);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_RoughDivide { get; } = new BaseAction(ActionID.PvP_RoughDivide, ActionOption.Buff);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_DrawAndJunction { get; } = new BaseAction(ActionID.PvP_DrawAndJunction, ActionOption.Buff);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_JunctionCast { get; } = new BaseAction(ActionID.PvP_JunctionCast);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_BurstStrike { get; } = new BaseAction(ActionID.PvP_BurstStrike)
    {
        StatusNeed = new StatusID[] { StatusID.PvP_PowderBarrel },
    };

    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_SavageClaw { get; } = new BaseAction(ActionID.PvP_SavageClaw);


    /// <summary>
    /// 
    /// </summary>
    public static IBaseAction PvP_WickedTalon { get; } = new BaseAction(ActionID.PvP_WickedTalon, ActionOption.Buff);


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_HyperVelocity { get; } = new BaseAction(ActionID.PvP_HyperVelocity)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_ReadyToBlast },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_JugularRip { get; } = new BaseAction(ActionID.PvP_JugularRip)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_ReadyToRip },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_AbdomenTear { get; } = new BaseAction(ActionID.PvP_AbdomenTear)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_ReadyToTear },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_EyeGouge { get; } = new BaseAction(ActionID.PvP_EyeGouge)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_ReadyToGouge },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Nebula { get; } = new BaseAction(ActionID.PvP_Nebula)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_JunctionTank },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_BlastingZone { get; } = new BaseAction(ActionID.PvP_BlastingZone)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_JunctionDPS },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Aurora { get; } = new BaseAction(ActionID.PvP_Aurora)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_JunctionHealer },
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_RelentlessRush { get; } = new BaseAction(ActionID.PvP_RelentlessRush)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_TerminalTrigger { get; } = new BaseAction(ActionID.PvP_TerminalTrigger)
        {
            FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
            ActionCheck = (t, m) => LimitBreakLevel >= 1,
        };


        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia GNB(PvP)";
		public override string Description => "PvP Rotation for GNB.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LB���g�p���܂��B")
            .SetInt(CombatType.PvP, "RRValue", 30000, "LB:�A�������s�����߂ɕK�v�ȃ^�[�Q�b�g��HP�́H", 1, 100000)
            //.SetInt(CombatType.PvP, "SBValue", 50000, "	�V���h�E�u�����K�[���g�p����v���C���[��HP�́H", 1, 100000)
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


            //if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("RecuperatePvP") && Player.GetHealthRatio() <= Configs.GetInt("RCValue") &&
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("RecuperatePvP") && ((Player.CurrentHp / Player.MaxHp) * 100) < Configs.GetInt("RCValue") &&
                PvP_Recuperate.CanUse(out act, CanUseOption.MustUse)) return true;


            //if (Configs.GetBool("LBInPvP") && PvP_RelentlessRush.Target.CurrentHp < Configs.GetInt("RRValue") && PvP_RelentlessRush.IsEnabled && InCombat)
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("RRValue") && PvP_RelentlessRush.IsEnabled && InCombat)
            {
                    if (PvP_RelentlessRush.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            }

            //PvP_ReadyToGouge
            //PvP_ReadyToTear
            //PvP_ReadyToRip
            //if (PvP_GnashingFang.IsCoolingDown)
            //{
            //    if (HostileTarget && HostileTarget.DistanceToPlayer() < 5 && PvP_GnashingFang.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //}
            //if (HostileTarget && HostileTarget.DistanceToPlayer() < 5 && PvP_GnashingFang.IsEnabled && PvP_GnashingFang.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget && PvP_GnashingFang.IsEnabled && PvP_GnashingFang.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;


            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_DoubleDown.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //if (PvP_SavageClaw.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //if (PvP_BurstStrike.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //if (PvP_GnashingFang.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;


            //PvP_PowderBarrel
            if (PvP_SolidBarrel.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_BrutalShell.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_KeenEdge.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_HyperVelocity.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_JugularRip.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_AbdomenTear.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_EyeGouge.CanUse(out act, CanUseOption.MustUse)) return true;


            //PvP_JunctionTank
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Nebula.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //PvP_JunctionDPS
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_BlastingZone.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //PvP_JunctionHealer
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Aurora.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            //if (PvP_Continuation.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            //PvP_NoMercy
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_RoughDivide.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //PvP_PowderBarrel,PvP_JunctionTank,PvP_JunctionDPS,PvP_JunctionHealer
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_DrawAndJunction.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            //if (PvP_JunctionCast.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            return base.AttackAbility(out act);
        }


    }
}
