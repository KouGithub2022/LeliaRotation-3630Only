using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Ranged
{

	[RotationDesc(ActionID.Wildfire)]
	public class BrdPvPRotation : BRD_Base
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

        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia BRD(PvP)";
		public override string Description => "PvP Rotation for BRD.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;


        protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
            .SetBool(CombatType.PvP, @"LBInPvP""", true, "LBを使用します。")
            .SetInt(CombatType.PvP, @"FFValue""", 50000, "LB:英雄のファンタジアを行うために必要な敵のHPは？", 1, 100000)
            .SetBool(CombatType.PvP, @"Repelling""", true, "リペリングショットを使用します。")
            //.SetBool(CombatType.PvP, @"Empyreal""", true, "エンピリアルアローを常にチャージ３で使用します。")
            .SetCombo(CombatType.PvP, @"EmpyrealCh""", 2, "エンピリアルアローを使うチャージ数。", "1", "2", "3")
            .SetBool(CombatType.PvP, @"SNocturne""", true, "黙者のノクターンを使用します。")
            .SetBool(CombatType.PvP, @"SprintPvP""", true, "スプリントを使います。")
            .SetBool(CombatType.PvP, @"RecuperatePvP""", true, "快気を使います。")
            .SetInt(CombatType.PvP, @"RCValue""", 75, "快気を使うプレイヤーのHP%%は？", 1, 100)
            .SetBool(CombatType.PvP, @"PurifyPvP""", true, "浄化を使います。")
            .SetBool(CombatType.PvP, @"1343PvP""", true, "スタン")
            .SetBool(CombatType.PvP, @"3219PvP""", true, "氷結")
            .SetBool(CombatType.PvP, @"3022PvP""", true, "徐々に睡眠")
            .SetBool(CombatType.PvP, @"1348PvP""", true, "睡眠")
            .SetBool(CombatType.PvP, @"1345PvP""", false, "バインド")
            .SetBool(CombatType.PvP, @"1344PvP""", false, "ヘヴィ")
            .SetBool(CombatType.PvP, @"1347PvP""", true, "沈黙")
            //.SetBool(CombatType.PvP, "ThunderclapPvP", true, "Use Thunderclap")
            //.SetInt(CombatType.PvP, "SCValue", 30000, "How much HP does the enemy have for Thunderclap to be done", 1, 100000)
            .SetBool(CombatType.PvP, @"GuardPvP""", true, "防御を使う")
            .SetInt(CombatType.PvP, @"GuardValue""", 15000, "防御を使うプレイヤーのHPは？", 1, 100000)
            .SetBool(CombatType.PvP, @"GuardCancel""", true, "自分が防御中は攻撃を中止します。");


        //private int EmpyrealCh => Configs.GetCombo(@"EmpyrealCh""");
        protected override bool GeneralGCD(out IAction act)
		{
			act = null;

            #region PvP

            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool(@"GuardPvP""") && Player.CurrentHp < Configs.GetInt("GuardValue") && InCombat && 
            //if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool(@"GuardPvP""") && Player.GetHealthRatio() <= Configs.GetInt("GuardValue") &&
                PvP_Guard.CanUse(out act, CanUseOption.MustUse)) return true;
            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;


            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool(@"PurifyPvP"""))
            {
                if (Configs.GetBool(@"1343PvP""") && Player.HasStatus(true, (StatusID)1343) && 
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool(@"3219PvP""") && Player.HasStatus(true, (StatusID)3219) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool(@"3022PvP""") && Player.HasStatus(true, (StatusID)3022) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool(@"1348PvP""") && Player.HasStatus(true, (StatusID)1348) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool(@"1345PvP""") && Player.HasStatus(true, (StatusID)1345) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool(@"1344PvP""") && Player.HasStatus(true, (StatusID)1344) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
                else if (Configs.GetBool(@"1347PvP""") && Player.HasStatus(true, (StatusID)1347) &&
                    PvP_Purify.CanUse(out act, CanUseOption.MustUse) && !PvP_Purify.IsCoolingDown) return true;
            }


            //if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("RecuperatePvP") && Player.GetHealthRatio() <= Configs.GetInt("RCValue") &&
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool(@"RecuperatePvP""") && ((Player.CurrentHp / Player.MaxHp) * 100) < Configs.GetInt("RCValue") &&
                PvP_Recuperate.CanUse(out act, CanUseOption.MustUse)) return true;


			if (HostileTarget && Configs.GetBool(@"LBInPvP""") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && HostileTarget.CurrentHp < Configs.GetInt(@"FFValue""") && PvP_FinalFantasia.IsEnabled)
			{
				if (PvP_FinalFantasia.CanUse(out act, CanUseOption.MustUse)) return true;
			}


			if (HostileTarget && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_ApexArrow.CanUse(out act, CanUseOption.MustUse)) return true;

			if (HostileTarget && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_BlastArrowReady) && PvP_BlastArrow.CanUse(out act, CanUseOption.MustUse)) return true;
			if (HostileTarget && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_Repertoire) && PvP_PitchPerfect.CanUse(out act, CanUseOption.MustUse)) return true;


            //if (PvP_EmpyrealArrow.IsCoolingDown && HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_PowerfulShot.CanUse(out act, CanUseOption.IgnoreCastCheck)) return true;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && PvP_PowerfulShot.CanUse(out act, CanUseOption.IgnoreCastCheck)) return true;

            if (Configs.GetBool(@"GuardCancel""") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool(@"SprintPvP""") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

		protected override bool AttackAbility(out IAction act)
		{
            //if (Configs.GetBool(@"RecuperatePvP""") && ((Player.CurrentHp / Player.MaxHp) * 100) < Configs.GetInt("RCValue") &&
            //    PvP_Recuperate.CanUse(out act, CanUseOption.MustUse)) return true;

            
            if (HostileTarget && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && 
                PvP_EmpyrealArrow.CurrentCharges >= (Configs.GetCombo(@"EmpyrealCh""") + 1) && 
                PvP_EmpyrealArrow.CanUse(out act, CanUseOption.MustUseEmpty)) return true;

            //if (Configs.GetBool("Empyreal") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard))
            //{
            //    if (PvP_EmpyrealArrow.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //}
            //else
            //{
            //    if (PvP_EmpyrealArrow.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
            //}


            if (!Player.HasStatus(true, StatusID.PvP_Repertoire) &&
                !PvP_TheWardensPaean.IsCoolingDown && PvP_TheWardensPaean.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (HostileTarget && !Player.HasStatus(true, StatusID.PvP_Repertoire) && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && 
                Configs.GetBool(@"SNocturne""") && !PvP_SilentNocturne.IsCoolingDown && PvP_SilentNocturne.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            
			if (HostileTarget && Configs.GetBool(@"Repelling""") && !HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !PvP_RepellingShot.IsCoolingDown && PvP_RepellingShot.CanUse(out act, CanUseOption.MustUse)) return true;

            //if (Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) && 
			//	PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;

            return base.AttackAbility(out act);
		}
    }
}