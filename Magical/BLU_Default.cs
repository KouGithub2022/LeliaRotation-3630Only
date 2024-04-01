using Dalamud.Game.ClientState.Objects.SubKinds;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.ConfigModule;

namespace LeliaRotations.Magical
{
	[BetaRotation]

    public class BluRotation : BLU_Base
    {
        #region PvPDeclaration

        /// <summary>
        /// 
        /// </summary>
        public static IBaseAction BreathOfMagic { get; } = new BaseAction(ActionID.BreathOfMagic, ActionOption.Dot);

        #endregion

        public override CombatType Type => CombatType.PvE;

        public override string GameVersion => "6.18";

        public override string RotationName => "Lelia BLU Default";

        public override bool CanHealAreaSpell => base.CanHealAreaSpell && BlueId == BLUID.Healer;
        public override bool CanHealSingleSpell => base.CanHealSingleSpell && BlueId == BLUID.Healer;

        protected override IRotationConfigSet CreateConfiguration()
        {
            return base.CreateConfiguration()
                .SetBool(CombatType.PvE, "MoonFluteBreak", false, "Use Moon Flute")
                .SetBool(CombatType.PvE, "SingleAOE", true, "Use high-damage AoE skills on single target")
                .SetBool(CombatType.PvE, "GamblerKill", false, "Use skills with a chance to fail")
                .SetBool(CombatType.PvE, "WWind", true, "ホワイトウィンドを使用します")
                .SetBool(CombatType.PvE, "UseFinalSting", false, "Use Final Sting")
                .SetFloat(RotationSolver.Basic.Configuration.ConfigUnitType.Percent, CombatType.PvE, "FinalStingHP", 0, "Target HPP for Final Sting");
        }

        private bool MoonFluteBreak => Configs.GetBool("MoonFluteBreak");
        private bool UseFinalSting => Configs.GetBool("UseFinalSting");
        private float FinalStingHP => Configs.GetFloat("FinalStingHP");
        /// <summary>
        /// 0-70$7EC3$7EA7,快速$7EC3$7EA7,滑舌拉怪
        /// </summary>
        private static bool QuickLevel => false;
        /// <summary>
        /// $8D4C几率秒$6740
        /// </summary>
        private bool GamblerKill => Configs.GetBool("GamblerKill");
        /// <summary>
        /// $5355体$65F6是否$91CA放高$4F24害AOE
        /// </summary>
        private bool SingleAOE => Configs.GetBool("SingleAOE");

        protected override bool EmergencyAbility(IAction nextGCD, out IAction act)
        {
            if (nextGCD.IsTheSameTo(false, SelfDestruct, FinalSting))
            {
                if (Swiftcast.CanUse(out act)) return true;
            }
            return base.EmergencyAbility(nextGCD, out act);
        }

        protected override bool GeneralGCD(out IAction act)
        {
            act = null;

            if (Player.HasStatus(true, StatusID.WaningNocturne)) return false;
            //鬼宿脚
			if (PhantomFlurry.IsCoolingDown && !PhantomFlurry.ElapsedOneChargeAfter(1) || Player.HasStatus(true, StatusID.PhantomFlurry))
            {
                if (!Player.WillStatusEnd(0.1f, true, StatusID.PhantomFlurry) && Player.WillStatusEnd(1, true, StatusID.PhantomFlurry) && PhantomFlurry2.CanUse(out act, CanUseOption.MustUse)) return true;
                return false;
            }

            //月の笛
            if (MoonFluteBreak && DBlueBreak(out act)) return true;

            //PrimalSpell
            if (PrimalSpell(out act)) return true;
            //AreaGCD
            if (AreaGCD(out act)) return true;
            //SingleGCD
            if (SingleGCD(out act)) return true;

            return base.GeneralGCD(out act);
        }

        protected override bool HealSingleGCD(out IAction act)
        {
            if (BlueId == BLUID.Healer)
            {
                //有某些非常危$9669的状$6001。
                if (IsEsunaStanceNorth && WeakenPeople.Any() || DyingPeople.Any())
                {
                    if (Exuviation.CanUse(out act, CanUseOption.MustUse)) return true;
                }
                if (AngelsSnack.CanUse(out act)) return true;
                if (Stotram.CanUse(out act)) return true;
                if (PomCure.CanUse(out act)) return true;
            }
            else
            {
                if (Configs.GetBool("WWind") && WhiteWind.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            return base.HealSingleGCD(out act);
        }

        /// <summary>
        /// D青爆$53D1
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        private bool DBlueBreak(out IAction act)
        {
            if (TripleTrident.OnSlot && TripleTrident.WillHaveOneChargeGCD(OnSlotCount(Whistle, Tingle), 0))
            {
                //064:ホイッスル
                if (Whistle.CanUse(out act)) return true;
                //$54D4哩$54D4哩
                //if (!Player.HasStatus(true, StatusID.Tingling)
                //    && Tingle.CanUse(out act, CanUseOption.MustUse)) return true;
                if (OffGuard.CanUse(out act)) return true;
                //$9C7C叉
                if (TripleTrident.CanUse(out act, CanUseOption.MustUse)) return true;
            }

            if (AllOnSlot(Whistle, FinalSting, BasicInstinct) && UseFinalSting)
            {
               if (Whistle.CanUse(out act)) return true;
                //破防
                if (OffGuard.CanUse(out act)) return true;
                //$54D4哩$54D4哩
                if (Tingle.CanUse(out act)) return true;
            }


            //039:月の笛	
            if (CanUseMoonFlute(out act)) return true;
            if (!Player.HasStatus(true, StatusID.WaxingNocturne)) return false;


            //080:Aジャスティスキック
            if (JKick.CanUse(out act, CanUseOption.MustUse)) return true;
            //078:A徹甲散弾	
            if (Surpanakha.CurrentCharges >= 4 && Surpanakha.CanUse(out act, CanUseOption.MustUse | CanUseOption.EmptyOrSkipCombo)) return true;
            //100:マトラマジック
            if (MatraMagic.CanUse(out act, CanUseOption.MustUse)) return true;
            //104:A月下彼岸花		
            if (NightBloom.CanUse(out act, CanUseOption.MustUse)) return true;
            //090:闘霊弾	
            if (TheRoseOfDestruction.CanUse(out act)) return true;
            //044:Aフェザーレイン
            if (FeatherRain.CanUse(out act, CanUseOption.MustUse)) return true;
            //118:断罪の飛翔
            if (WingedReprobation.CanUse(out act)) return true;
            //047:Aショックストライク
            if (ShockStrike.CanUse(out act, CanUseOption.MustUse)) return true;
            //048:A氷雪乱舞
            if (GlassDance.CanUse(out act, CanUseOption.MustUse)) return true;
            //122:グルグルザパーン
            if (SeaShanty.CanUse(out act)) return true;
            //124:死すべき定め
            if (BeingMortal.CanUse(out act)) return true;

            return false;
        }


        /// <summary>
        /// 月笛条件
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        private static bool CanUseMoonFlute(out IAction act)
        {
            if (!MoonFlute.CanUse(out act) && !HasHostilesInRange) return false;

            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;

            if (Player.HasStatus(true, StatusID.Harmonized)) return true;

            return false;
        }

        /// <summary>
        /// $7EC8$6781$9488$7EC4合
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        private bool CanUseFinalSting(out IAction act)
        {
            act = null;
            if (!UseFinalSting) return false;
            if (!FinalSting.CanUse(out _)) return false;

            var useFinalSting = Player.HasStatus(true, StatusID.WaxingNocturne, StatusID.Harmonized);

            if (AllOnSlot(Whistle, MoonFlute, FinalSting) && !AllOnSlot(BasicInstinct))
            {
                if (HostileTarget?.GetHealthRatio() > FinalStingHP) return false;

                if (Whistle.CanUse(out act)) return true;
                if (MoonFlute.CanUse(out act)) return true;
                if (useFinalSting && FinalSting.CanUse(out act)) return true;
            }

            if (AllOnSlot(Whistle, MoonFlute, FinalSting, BasicInstinct))
            {
                //破防
                if (Player.HasStatus(true, StatusID.WaxingNocturne) && OffGuard.CanUse(out act)) return true;

                if (HostileTarget?.GetHealthRatio() > FinalStingHP) return false;
                if (Whistle.CanUse(out act)) return true;
                if (MoonFlute.CanUse(out act)) return true;
                if (useFinalSting && FinalSting.CanUse(out act)) return true;
            }

            return false;
        }


        /// <summary>
        /// $5355体GCD填充
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        private bool SingleGCD(out IAction act)
        {
            act = null;
            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;

            var option = SingleAOE ? CanUseOption.MustUse : CanUseOption.None;



            //080:Aジャスティスキック
            if (JKick.CanUse(out act, CanUseOption.MustUse)) return true;

            //100:マトラマジック
            if (MatraMagic.CanUse(out act, CanUseOption.MustUse)) return true;

            //090:闘霊弾	
            if (TheRoseOfDestruction.CanUse(out act)) return true;

            //063:ソニックブーム
            if (SonicBoom.CanUse(out act)) return true;
			//ドリルキャノン
            if (DrillCannons.CanUse(out act, CanUseOption.MustUse)) return true;

            return false;
        }

        /// <summary>
        /// 范$56F4GCD填充
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        private bool AreaGCD(out IAction act)
        {
            act = null;
            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;

            var option = SingleAOE ? CanUseOption.MustUse : CanUseOption.None;

            //104:A月下彼岸花		
            if (NightBloom.CanUse(out act, CanUseOption.MustUse)) return true;
            //044:Aフェザーレイン
            if (FeatherRain.CanUse(out act, CanUseOption.MustUse)) return true;
            //047:Aショックストライク
            if (ShockStrike.CanUse(out act, CanUseOption.MustUse)) return true;
            //048:A氷雪乱舞
            if (GlassDance.CanUse(out act, CanUseOption.MustUse)) return true;
            //122:グルグルザパーン
            if (SeaShanty.CanUse(out act, option)) return true;
            //124:死すべき定め
            if (BeingMortal.CanUse(out act, option)) return true;

            //045:エラプション	
            if (Eruption.CanUse(out act, option)) return true;
            return false;
        }

        /// <summary>
        /// 有CD的技能
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        private bool PrimalSpell(out IAction act)
        {
            act = null;
            if (Player.HasStatus(true, StatusID.WaxingNocturne)) return false;

            var option = SingleAOE ? CanUseOption.MustUse : CanUseOption.None;

            //121:必滅の炎
            if (!HostileTarget.HasStatus(true, (StatusID)3643) && MortalFlame.CanUse(out act)) return true;

            //ガードオファ
            if (OffGuard.CanUse(out act)) return true;

            //怒髪天&苦悶の歌
            if (AllOnSlot(Bristle, SongOfTorment) && SongOfTorment.CanUse(out _))
            {
                //怒髪天
                if (Bristle.CanUse(out act)) return true;
				//苦悶の歌
                if (SongOfTorment.CanUse(out act)) return true;
            }
            if (SongOfTorment.CanUse(out act)) return true;

            //078:A徹甲散弾	
            if (Surpanakha.CurrentCharges >= 4 && Surpanakha.CanUse(out act, CanUseOption.MustUse | CanUseOption.EmptyOrSkipCombo)) return true;
            if (Player.HasStatus(true, StatusID.SurpanakhaFury))
            {
                if (Surpanakha.CanUse(out act, CanUseOption.MustUse | CanUseOption.EmptyOrSkipCombo)) return true;
            }

            //103:A鬼宿脚
            if (PhantomFlurry.CanUse(out act, option)) return true;
            if (PhantomFlurry.IsCoolingDown && !PhantomFlurry.ElapsedOneChargeAfter(1) || Player.HasStatus(true, StatusID.PhantomFlurry))
            {
                if (!Player.WillStatusEnd(0.1f, true, StatusID.PhantomFlurry) && Player.WillStatusEnd(1, true, StatusID.PhantomFlurry) && PhantomFlurry2.CanUse(out act, CanUseOption.MustUse)) return true;
                return false;
            }

            //116:コンヴィクション・マルカート
            if (Player.HasStatus(true, (StatusID)3641))
            {
                if (ConvictionMarcato.CanUse(out act, option)) return true;
            }
            //118:断罪の飛翔
            if (WingedReprobation.CanUse(out act, option)) return true;

            return false;
        }
    }
}


