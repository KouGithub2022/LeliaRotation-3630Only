using Dalamud.Game.ClientState.Objects.SubKinds;

namespace LeliaRotations.Melee
{

	[RotationDesc(ActionID.Shukuchi)]
	public class NinPvPRotation : NIN_Base
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
        public static IBaseAction PvP_Spinningedge { get; } = new BaseAction(ActionID.PvP_Spinningedge);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Gustslash { get; } = new BaseAction(ActionID.PvP_Gustslash);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Aeolianedge { get; } = new BaseAction(ActionID.PvP_Aeolianedge);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Fumashuriken { get; } = new BaseAction(ActionID.PvP_Fumashuriken);


		/// <summary>
		/// 
		/// </summary>
		//		public static IBaseAction PvP_Mug { get; } = new BaseAction(ActionID.PvP_Mug);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_ThreeMudra { get; } = new BaseAction(ActionID.PvP_Threemudra, ActionOption.Buff);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Bunshin { get; } = new BaseAction(ActionID.PvP_Bunshin, ActionOption.Buff);
		//		{
		//			StatusNeed = new StatusID[] { StatusID.PvP_Bunshin }
		//		};


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Shukuchi { get; } = new BaseAction(ActionID.PvP_Shukuchi, ActionOption.Buff);
//		{
//			StatusNeed = new StatusID[] { StatusID.PvP_Hidden }
//		};


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Forkedraiju { get; } = new BaseAction(ActionID.PvP_Forkedraiju)
        {
            StatusNeed = new StatusID[] { StatusID.PvP_ThreeMudra }
        };


        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction PvP_Fleetingraiju { get; } = new BaseAction(ActionID.PvP_Fleetingraiju);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Hyoshoranryu { get; } = new BaseAction(ActionID.PvP_Hyoshoranryu)
		{
			StatusNeed = new StatusID[] { StatusID.PvP_ThreeMudra }
		};


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Gokamekkyaku { get; } = new BaseAction(ActionID.PvP_Gokamekkyaku)
		{
			StatusNeed = new StatusID[] { StatusID.PvP_ThreeMudra }
		};


		/// <summary>
		/// 
		/// </summary>
//		public static IBaseAction PvP_Meisui { get; } = new BaseAction(ActionID.PvP_Meisui)
//		{
//			StatusNeed = new StatusID[] { StatusID.PvP_ThreeMudra }
//		};


		/// <summary>
		/// 
		/// </summary>
//		public static IBaseAction PvP_Huton { get; } = new BaseAction(ActionID.PvP_Huton)
//		{
//			StatusNeed = new StatusID[] { StatusID.PvP_ThreeMudra }
//		};


		/// <summary>
		/// 
		/// </summary>
//		public static IBaseAction PvP_Doton { get; } = new BaseAction(ActionID.PvP_Doton)
//		{
//			StatusNeed = new StatusID[] { StatusID.PvP_ThreeMudra }
//		};


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_HollowNozuchi { get; } = new BaseAction(ActionID.PvP_HollowNozuchi);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Assassinate { get; } = new BaseAction(ActionID.PvP_Assassinate);


		/// <summary>
		/// 
		/// </summary>
		public static IBaseAction PvP_Seitontenchu { get; } = new BaseAction(ActionID.PvP_Seitontenchu)
		{
			FilterForHostiles = tars => tars.Where(t => t is PlayerCharacter),
			ActionCheck = (t, m) => LimitBreakLevel >= 1,
		};
		#endregion

		public override string GameVersion => "6.51";
		public override string RotationName => "Lelia NIN(PvP)";
		public override string Description => "PvP Rotation for NIN";
		public override CombatType Type => CombatType.PvP;
		public override bool ShowStatus => true;

		protected override IRotationConfigSet CreateConfiguration() => base.CreateConfiguration()
			.SetBool(CombatType.PvP, "LBInPvP", true, "LBを使用します。")
			.SetInt(CombatType.PvP, "STValue", 30000, "LB:星遁天誅を行うために必要な敵のHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "MSValue", 30000, "命水を使用するプレイヤーのHPは？", 1, 100000)
            .SetInt(CombatType.PvP, "ForkedraijuValue", 40000, "月影雷獣爪を行うために必要な敵のHPは？", 1, 100000)
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


            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_Hidden) && PvP_Assassinate.CanUse(out act, CanUseOption.MustUse)) return true;

			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Configs.GetBool("LBInPvP") && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("STValue") && PvP_Seitontenchu.IsEnabled)
			{
				if (PvP_Seitontenchu.CanUse(out act, CanUseOption.MustUseEmpty)) return true;
			}

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_SealedDoton) && PvP_HollowNozuchi.CanUse(out act, CanUseOption.MustUse)) return true;

            //Meisui
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_SealedMeisui) && Player.CurrentHp < Configs.GetInt("MSValue") && PvP_Meisui.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //PvP_Forkedraiju
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_SeakedForkedRaiju) && HostileTarget && HostileTarget.CurrentHp < Configs.GetInt("ForkedraijuValue") && PvP_Forkedraiju.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            if (Player.HasStatus(true, StatusID.PvP_FleetingRaijuReady) && PvP_Fleetingraiju.CanUse(out act, CanUseOption.MustUse)) return true;
            //Doton
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_SealedDoton) && PvP_Doton.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //Hyoshoranryu
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_SealedHyoshoRanryu) && PvP_Fumashuriken.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
            //Gokamekkyaku
            //if (!Player.HasStatus(true, StatusID.PvP_SealedGokaMekkyaku) && PvP_Mug.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //Huton
            //if (Player.HasStatus(true, StatusID.PvP_SealedHuton) && PvP_Bunshin.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            //if (PvP_ThreeMudra.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
            //if (PvP_Shukuchi.CanUse(out act, CanUseOption.MustUse)) return true;

			if (!Player.HasStatus(true, StatusID.PvP_Hidden))
			{
				if (PvP_Aeolianedge.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_Gustslash.CanUse(out act, CanUseOption.MustUse)) return true;
				if (PvP_Spinningedge.CanUse(out act, CanUseOption.MustUse)) return true;
			}
			else
			{
                if (PvP_Assassinate.CanUse(out act, CanUseOption.MustUse)) return true;
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
			if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_ThreeMudra.CanUse(out act, CanUseOption.MustUseEmpty) && InCombat) return true;
            //Gokamekkyaku
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && !Player.HasStatus(true, StatusID.PvP_SealedGokaMekkyaku) && PvP_Mug.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;
            //Huton
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && Player.HasStatus(true, StatusID.PvP_SealedHuton) && PvP_Bunshin.CanUse(out act, CanUseOption.MustUse) && InCombat) return true;

            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Shukuchi.CanUse(out act, CanUseOption.MustUse)) return true;
            if (!HostileTarget.HasStatus(true, StatusID.PvP_Guard) && PvP_Bunshin.CanUse(out act, CanUseOption.MustUse)) return true;

            return base.AttackAbility(out act);
		}

	}
}