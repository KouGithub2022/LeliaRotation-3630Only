using Dalamud.Game.ClientState.Objects.SubKinds;
using RotationSolver.Basic.Rotations;


namespace LeliaRotations.Melee
{

    [RotationDesc(ActionID.HellsIngress)]
	public class RprPvPRotation : RPR_Base
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
        /// 1-2-3 combo for RPR
        /// </summary>
        private static IBaseAction PvP_Slice { get; } = new BaseAction(ActionID.PvP_Slice)
        {

        };


        /// <summary>
        /// 1-2-3 combo for RPR
        /// </summary>
        private static IBaseAction PvP_WaxingSlice { get; } = new BaseAction(ActionID.PvP_WaxingSlice)
        {

        };


        /// <summary>
        /// 1-2-3 combo for RPR
        /// </summary>
        private static IBaseAction PvP_InfernalSlice { get; } = new BaseAction(ActionID.PvP_InfernalSlice)
        {

        };


        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_SoulSlice { get; } = new BaseAction(ActionID.PvP_SoulSlice)
        {
            //PvP_ImmortalSacrifice
            StatusProvide = new StatusID[1] { (StatusID)3204 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_PlentifulHarvest { get; } = new BaseAction((ActionID)29546)
        {
            StatusNeed = new StatusID[1] { (StatusID)3204 },
            ActionCheck = (BattleChara b, bool m) => PvP_PlentifulHarvest.Target.DistanceToPlayer() <= 15,
        };

        /// <summary>
        /// 
        /// </summary>
        private static IBaseAction PvP_GrimSwathe { get; } = new BaseAction(ActionID.PvP_GrimSwathe)
        {
            //PvP_SoulReaver
            StatusProvide = new StatusID[1] { (StatusID)2854 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_DeathWarrant { get; } = new BaseAction(ActionID.PvP_DeathWarrant)
        {
            //PvP_DeathWarrant 3206
            TargetStatus = new StatusID[1] { (StatusID)3206 },
            //PvP_Soulsow 2750
            StatusProvide = new StatusID[1] { (StatusID)2750 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_HellsIngress { get; } = new BaseAction(ActionID.PvP_HellsIngress)
        {
            //Threshold 2860
            StatusProvide = new StatusID[1] { (StatusID)2860 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_ArcaneCrest { get; } = new BaseAction(ActionID.PvP_ArcaneCrest)
        {
            //Crest of Time = 2861
            StatusProvide = new StatusID[1] { (StatusID)2861 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_Guillotine { get; } = new BaseAction(ActionID.PvP_Guillotine)
        {
            // PvP_SoulReaver = 2854
            StatusNeed = new StatusID[1] { (StatusID)2854 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_VoidReaping { get; } = new BaseAction(ActionID.PvP_VoidReaping)
        {
            // Ripe for Reaping = 2858
            StatusProvide = new StatusID[1] { (StatusID)2858 },
            // PvP_Enshrouded = 2863
            StatusNeed = new StatusID[1] { (StatusID)2863 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_CrossReaping { get; } = new BaseAction(ActionID.PvP_CrossReaping)
        {
            // PvP_Enshrouded = 2863,Ripe for Reaping = 2858
            StatusNeed = new StatusID[2] { (StatusID)2863, (StatusID)2858 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_LemuresSlice { get; } = new BaseAction(ActionID.PvP_LemuresSlice)
        {
            // PvP_Enshrouded = 2863
            StatusNeed = new StatusID[1] { (StatusID)2863 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_HarvestMoon { get; } = new BaseAction(ActionID.PvP_HarvestMoon)
        {
            // PvP_Soulsow = 2750
            StatusNeed = new StatusID[1] { (StatusID)2750 },
        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_Regress { get; } = new BaseAction(ActionID.PvP_Regress)
        {

        };


        /// <summary>
        ///
        /// </summary>
        private static IBaseAction PvP_Communio { get; } = new BaseAction(ActionID.PvP_Communio)
        {

        };


        /// <summary>
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        private static IBaseAction PvP_TenebraeLemurum { get; } = new BaseAction(ActionID.PvP_TenebraeLemurum)
        {
            ActionCheck = (BattleChara t, bool m) => CustomRotation.LimitBreakLevel >= 1
        };


        #endregion

        public override string GameVersion => "6.51";
		public override string RotationName => "Lelia RPR(PvP)";
		public override string Description => "PvP Rotation for RPR.";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
            .SetInt(CombatType.PvP, "TLValue", 30000, "LB:\tレムール・テネブレーを行うために必要なプレイヤーのHPは？", 1, 100000)
            //.SetInt(CombatType.PvP, "HSValue", 40000, "	ホーリーシェルトロンを使用するプレイヤーのHPは？", 1, 100000)
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
            .SetInt(CombatType.PvP, "GuardValue", 15000, "防御を使うプレイヤーのHP%%は？", 1, 100000)
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
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("TLValue") && PvP_TenebraeLemurum.IsEnabled && InCombat)
            {
                if (PvP_TenebraeLemurum.CanUse(out act, CanUseOption.MustUse)) return true;
                
            }

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Communio.CanUse(out act, CanUseOption.MustUse) && Player.HasStatus(true, StatusID.PvP_Enshrouded)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_SoulSlice.CanUse(out act, CanUseOption.MustUseEmpty) && !Player.HasStatus(true, StatusID.PvP_Enshrouded)) return true;

            if (!Player.HasStatus(true, StatusID.PvP_Enshrouded) && Player.HasStatus(true, StatusID.PvP_ImmortalSacrifice) && 
                PvP_PlentifulHarvest.CanUse(out act, CanUseOption.MustUse)) return true;
            //if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !PvP_PlentifulHarvest.IsCoolingDown && 
            //    !Player.HasStatus(true, StatusID.PvP_Enshrouded) && Player.HasStatus(true, StatusID.PvP_ImmortalSacrifice) &&
            //    HostileTarget.IsTargetable && !Player.HasStatus(true, StatusID.PvP_Sprint) && !Player.HasStatus(true, (StatusID)2861) && InCombat)
            //{
            //    if (PvP_PlentifulHarvest.CanUse(out act, CanUseOption.MustUse)) return true;
                //act = PvP_PlentifulHarvest;
                //return true;
            //}
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_PlentifulHarvest.CanUse(out act, CanUseOption.MustUse) && !Player.HasStatus(true, StatusID.PvP_Enshrouded)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_ArcaneCrest.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Guillotine.CanUse(out act, CanUseOption.MustUse) && Player.HasStatus(true, StatusID.PvP_SoulReaver)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_CrossReaping.CanUse(out act, CanUseOption.MustUse) && Player.HasStatus(true, StatusID.PvP_Enshrouded) && Player.HasStatus(true, (StatusID)2858)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_VoidReaping.CanUse(out act, CanUseOption.MustUse) && Player.HasStatus(true, StatusID.PvP_Enshrouded)) return true;


            if (PvP_InfernalSlice.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_WaxingSlice.CanUse(out act, CanUseOption.MustUse)) return true;
            if (PvP_Slice.CanUse(out act, CanUseOption.MustUse)) return true;

            if (Configs.GetBool("GuardCancel") && Player.HasStatus(true, StatusID.PvP_Guard)) return false;
            if (!Player.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("SprintPvP") && !Player.HasStatus(true, StatusID.PvP_Sprint) &&
                PvP_Sprint.CanUse(out act, CanUseOption.MustUse)) return true;
            return base.GeneralGCD(out act);
			//return false;
			#endregion
		}

        protected override bool AttackAbility(out IAction act)
        {

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_GrimSwathe.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_DeathWarrant.CanUse(out act, CanUseOption.MustUse)) return true;
            //if (PvP_HellsIngress.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_LemuresSlice.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_HarvestMoon.CanUse(out act, CanUseOption.MustUse)) return true;



            return base.AttackAbility(out act);
        }


    }
}
