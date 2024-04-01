namespace DefaultRotations.Healer;

[RotationDesc(ActionID.Divination)]
[SourceCode(Path = "main/DefaultRotations/Healer/AST_Default.cs")]
public sealed class ASTPvE_Default : AST_Base
{
    public override CombatType Type => CombatType.PvE;

    public override string GameVersion => "6.28";

    public override string RotationName => "Lelia Default";

    protected override IRotationConfigSet CreateConfiguration()
        => base.CreateConfiguration()
            .SetFloat(RotationSolver.Basic.Configuration.ConfigUnitType.Seconds, CombatType.PvE, "UseEarthlyStarTime", 15, "Use Earthly Star during countdown timer.", 4, 20);
    static IBaseAction AspectedBeneficDefense { get; } = new BaseAction(ActionID.AspectedBenefic, ActionOption.Hot)
    {
        ChoiceTarget = TargetFilter.FindAttackedTarget,
        ActionCheck = (b, m) => b.IsJobCategory(JobRole.Tank),
        TargetStatus = new StatusID[] { StatusID.AspectedBenefic },
    };

    protected override IAction CountDownAction(float remainTime)
    {
        if (remainTime < Malefic.CastTime + CountDownAhead
            && Malefic.CanUse(out var act, CanUseOption.IgnoreClippingCheck)) return act;
        if (remainTime < 3 && UseBurstMedicine(out act)) return act;
        if (remainTime < 4 && AspectedBeneficDefense.CanUse(out act, CanUseOption.IgnoreClippingCheck)) return act;
        if (remainTime < Configs.GetFloat("UseEarthlyStarTime")
            && EarthlyStar.CanUse(out act, CanUseOption.IgnoreClippingCheck)) return act;
        if (remainTime < 30 && Draw.CanUse(out act, CanUseOption.IgnoreClippingCheck)) return act;

        return base.CountDownAction(remainTime);
    }

    [RotationDesc(ActionID.CelestialIntersection, ActionID.Exaltation)]
    protected override bool DefenseSingleAbility(out IAction act)
    {
        //天星交$9519
        if (CelestialIntersection.CanUse(out act, CanUseOption.EmptyOrSkipCombo)) return true;

        //$7ED9T$51CF$4F24，$8FD9个很重要。
        if (Exaltation.CanUse(out act)) return true;
        return base.DefenseSingleAbility(out act);
    }

    [RotationDesc(ActionID.Macrocosmos)]
    protected override bool DefenseAreaGCD(out IAction act)
    {
        if (Macrocosmos.CanUse(out act)) return true;
        return base.DefenseAreaGCD(out act);
    }

    [RotationDesc(ActionID.CollectiveUnconscious)]
    protected override bool DefenseAreaAbility(out IAction act)
    {
        if (CollectiveUnconscious.CanUse(out act)) return true;

        return base.DefenseAreaAbility(out act);
    }

    protected override bool GeneralGCD(out IAction act)
    {
        //Add AspectedBeneficwhen not in combat.
        if (NotInCombatDelay && AspectedBeneficDefense.CanUse(out act)) return true;

        if (Gravity.CanUse(out act)) return true;

        //$5355体$8F93出
        if (Combust.CanUse(out act)) return true;
        if (Malefic.CanUse(out act)) return true;
        if (Combust.CanUse(out act, CanUseOption.MustUse)) return true;

        return base.GeneralGCD(out act);
    }

    [RotationDesc(ActionID.AspectedHelios, ActionID.Helios)]
    protected override bool HealAreaGCD(out IAction act)
    {
        //$9633星相位
        if (AspectedHelios.CanUse(out act)) return true;

        //$9633星
        if (Helios.CanUse(out act)) return true;

        return base.HealAreaGCD(out act);
    }

    protected override bool EmergencyAbility(IAction nextGCD, out IAction act)
    {
        if (base.EmergencyAbility(nextGCD, out act)) return true;

        if (PartyHealers.Count() == 1 && Player.HasStatus(false, StatusID.Silence)
            && HasHostilesInRange && EchoDrops.CanUse(out act)) return true;

        if (!InCombat) return false;

        //如果要群$5976了，先上个天$5BAB$56FE！
        if (nextGCD.IsTheSameTo(true, AspectedHelios, Helios))
        {
            if (Horoscope.CanUse(out act)) return true;

            //中$95F4学派
            if (NeutralSect.CanUse(out act)) return true;
        }

        //如果要$5355$5976了，先上星位合$56FE！
        if (nextGCD.IsTheSameTo(true, Benefic, Benefic2, AspectedBenefic))
        {
            if (Synastry.CanUse(out act)) return true;
        }
        return base.EmergencyAbility(nextGCD, out act);
    }

    protected override bool GeneralAbility(out IAction act)
    {
        //如果当前$8FD8没有$5361牌，那就抽一$5F20
        if (Draw.CanUse(out act)) return true;

        //如果当前$5361牌已$7ECF$62E5有了，就重抽
        if (Redraw.CanUse(out act)) return true;

        return base.GeneralAbility(out act);
    }

    [RotationDesc(ActionID.AspectedBenefic, ActionID.Benefic2, ActionID.Benefic)]
    protected override bool HealSingleGCD(out IAction act)
    {
        //吉星相位
        if (AspectedBenefic.CanUse(out act)
            && (IsMoving || AspectedBenefic.Target.GetHealthRatio() > 0.4)) return true;

        //福星
        if (Benefic2.CanUse(out act)) return true;

        //吉星
        if (Benefic.CanUse(out act)) return true;

        return base.HealSingleGCD(out act);
    }

    protected override bool AttackAbility(out IAction act)
    {
        if (IsBurst && !IsMoving && Divination.CanUse(out act)) return true;

        //如果当前$8FD8没有皇冠$5361牌，那就抽一$5F20
        if (MinorArcana.CanUse(out act, CanUseOption.EmptyOrSkipCombo)) return true;

        //如果当前$8FD8没有$5361牌，那就抽一$5F20
        if (Draw.CanUse(out act, IsBurst ? CanUseOption.EmptyOrSkipCombo : CanUseOption.None)) return true;

        //光速，$521B造更多的内插能力技的机会。
        if (IsMoving && Lightspeed.CanUse(out act)) return true;


        if (!IsMoving)
        {
            //如果没有地星也没有巨星，那就$8BD5$8BD5看能不能放个。
            if (!Player.HasStatus(true, StatusID.EarthlyDominance, StatusID.GiantDominance))
            {
                if (EarthlyStar.CanUse(out act, CanUseOption.MustUse)) return true;
            }
            //加星星的$8FDB攻Buff
            if (Astrodyne.CanUse(out act)) return true;
        }

        if (DrawnCrownCard == CardType.LORD || MinorArcana.WillHaveOneChargeGCD(1, 0))
        {
            //$8FDB攻牌，随便$53D1。或者CD要$8F6C好了，赶$7D27$53D1掉。
            if (MinorArcana.CanUse(out act, CanUseOption.MustUse)) return true;
        }

        //$53D1牌
        if (Redraw.CanUse(out act)) return true;
        if (PlayCard(out act)) return true;

        return base.AttackAbility(out act);
    }

    [RotationDesc(ActionID.EssentialDignity, ActionID.CelestialIntersection, ActionID.CelestialOpposition,
        ActionID.EarthlyStar, ActionID.Horoscope)]
    protected override bool HealSingleAbility(out IAction act)
    {
        //常$89C4$5976
        if (EssentialDignity.CanUse(out act)) return true;
        //$5E26盾$5976
        if (CelestialIntersection.CanUse(out act, CanUseOption.EmptyOrSkipCombo)) return true;

        //$5976量牌，要看情况。
        if (DrawnCrownCard == CardType.LADY && MinorArcana.CanUse(out act, CanUseOption.MustUse)) return true;

        var tank = PartyTanks;
        var isBoss = Malefic.Target.IsBossFromTTK();
        if (EssentialDignity.IsCoolingDown && tank.Count() == 1 && tank.Any(t => t.GetHealthRatio() < 0.5) && !isBoss)
        {
            //群Hot
            if (CelestialOpposition.CanUse(out act)) return true;

            //如果有巨星主宰
            if (Player.HasStatus(true, StatusID.GiantDominance))
            {
                //需要回血的$65F6候炸了。
                act = EarthlyStar;
                return true;
            }

            //天$5BAB$56FE
            if (!Player.HasStatus(true, StatusID.HoroscopeHelios, StatusID.Horoscope) && Horoscope.CanUse(out act)) return true;
            //$9633星天$5BAB$56FE
            if (Player.HasStatus(true, StatusID.HoroscopeHelios) && Horoscope.CanUse(out act)) return true;
            //超$7D27急情况天$5BAB$56FE
            if (tank.Any(t => t.GetHealthRatio() < 0.3) && Horoscope.CanUse(out act)) return true;
        }

        return base.HealSingleAbility(out act);
    }

    [RotationDesc(ActionID.CelestialOpposition, ActionID.EarthlyStar, ActionID.Horoscope)]
    protected override bool HealAreaAbility(out IAction act)
    {
        //群Hot
        if (CelestialOpposition.CanUse(out act)) return true;

        //如果有巨星主宰
        if (Player.HasStatus(true, StatusID.GiantDominance))
        {
            //需要回血的$65F6候炸了。
            act = EarthlyStar;
            return true;
        }

        //天$5BAB$56FE
        if (Player.HasStatus(true, StatusID.HoroscopeHelios) && Horoscope.CanUse(out act)) return true;

        //$5976量牌，要看情况。
        if (DrawnCrownCard == CardType.LADY && MinorArcana.CanUse(out act, CanUseOption.MustUse)) return true;

        return base.HealAreaAbility(out act);
    }
}
