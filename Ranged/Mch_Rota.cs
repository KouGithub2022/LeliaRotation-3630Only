using Dalamud.Game.ClientState.Objects.SubKinds;
using RotationSolver.Basic.Rotations;



namespace LeliaRotations.Ranged
{

    [RotationDesc(ActionID.Wildfire)]
	public class MchPvPRotation : MCH_Base
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
        private static new IBaseAction PvP_Scattergun { get; } = new BaseAction(ActionID.PvP_Scattergun)
        {
            ActionCheck = (BattleChara b, bool m) => !Player.HasStatus(true, StatusID.PvP_Overheated) && !CustomRotation.Player.HasStatus(true, StatusID.PvP_Guard),
        };


        /// <summary>
        /// 
        /// </summary>
        private static new IBaseAction PvP_ChainSaw { get; } = new BaseAction(ActionID.PvP_ChainSaw)
        {
            StatusNeed = new StatusID[1] { StatusID.PvP_ChainSawPrimed },
            StatusProvide = new StatusID[1] { StatusID.PvP_DrillPrimed },
        };

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia MCH(PvP)";
		public override string Description => "PvP Rotation for MCH.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

        protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
            .SetBool(CombatType.PvP, "LBInPvP", true, "LB���g�p���܂��B")
            .SetInt(CombatType.PvP, "MSValue", 45, "LB:���e�̎ˎ���s�����߂ɕK�v�ȃ^�[�Q�b�g��HP%�́H", 1, 100)
            //.SetInt(CombatType.PvP, "HSValue", 40000, "	�z�[���[�V�F���g�������g�p����v���C���[��HP�́H", 1, 100000)
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
        //.SetBool(CombatType.PvP, "GuardOK", true, "�G���K�[�h���ł��U���𑱍s���܂��B");

        //private int MSValue => Configs.GetCombo(@"MSValue""");
        protected override bool GeneralGCD(out IAction act)
		{
			act = null;

            #region PvP
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("GuardPvP") && Player.CurrentHp  < Configs.GetInt("GuardValue") &&
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
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("RecuperatePvP") && Player.GetHealthRatio()*100 < Configs.GetInt("RCValue") &&
                PvP_Recuperate.CanUse(out act, CanUseOption.MustUse)) return true;


            //if (Configs.GetBool("LBInPvP") && PvP_RelentlessRush.Target.CurrentHp < Configs.GetInt("RRValue") && PvP_RelentlessRush.IsEnabled && InCombat)
            if (LimitBreakLevel >= 1 && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && Target.GetHealthRatio() * 100 <= Configs.GetInt("MSValue"))
            //if (LimitBreakLevel >= 1 && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && Target.GetHealthRatio() * 100 <= MSValue)
            {
                    if (PvP_MarksmansSpite.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard))
            {
                //if (!Target.HasStatus(true, StatusID.PvP_Guard) &&
                //    PvP_Scattergun.CanUse(out act, CanUseOption.MustUse)) return true;
                if (PvP_Scattergun.CanUse(out act, CanUseOption.MustUseEmpty, 1) && HostileTarget.DistanceToPlayer() <= 12)
                {
                    return true;
                }
                //if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard)  && !PvP_Scattergun.IsCoolingDown && HostileTarget.DistanceToPlayer() <= 12)
                //{
                //    act = PvP_Scattergun;
                //    return true;
                //}
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_Overheated) &&
                    PvP_HeatBlast.CanUse(out act, CanUseOption.MustUse)) return true;
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_BioblasterPrimed) && HostileTarget.DistanceToPlayer() <= 12 &&
                    PvP_Bioblaster.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_AirAnchorPrimed) &&
                    PvP_AirAnchor.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

                if (PvP_ChainSaw.CanUse(out act, CanUseOption.MustUseEmpty, 1))
                {
                    return true;
                }
                //if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_ChainSawPrimed) && PvP_ChainSaw.CurrentCharges > 0 && HostileTarget.DistanceToPlayer() <= 25)
                //{
                //    act = PvP_ChainSaw;
                //    return true;
                //}


            }
            if (Player.HasStatus(true, StatusID.PvP_DrillPrimed) &&
                PvP_Drill.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            if (PvP_BlastCharge.CanUse(out act, CanUseOption.IgnoreCastCheck)) return true;


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
                    PvP_Wildfire.CanUse(out act, CanUseOption.MustUse)) return true;
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && InCombat &&
                    PvP_BishopAutoTurret.CanUse(out act, CanUseOption.MustUse) && HostileTarget.DistanceToPlayer() <= 25) return true;
                if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !HostileTarget.HasStatus(true, StatusID.PvP_Analysis) && !Player.HasStatus(true, StatusID.PvP_BioblasterPrimed) && InCombat &&
                    PvP_Analysis.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            }

            return base.AttackAbility(out act);
        }


    }
}
