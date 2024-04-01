namespace DefaultRotations.Melee;

[SourceCode(Path = "main/DefaultRotations/Melee/SAM_Default.cs")]
public sealed class SAMPvE_Default : SAM_Base
{
    public override CombatType Type => CombatType.PvE;

    public override string GameVersion => "6.28";

    public override string RotationName => "Lelia Default";

    protected override IRotationConfigSet CreateConfiguration()
    {
        return base.CreateConfiguration()
            .SetInt(CombatType.PvE, "addKenki", 50, "Use Kenki above.", min: 0, max: 85, speed: 5);
    }

    /// <summary>
    /// 明$955C止水
    /// </summary>
    private static bool HaveMeikyoShisui => Player.HasStatus(true, StatusID.MeikyoShisui);

    protected override bool GeneralGCD(out IAction act)
    {
        //奥$4E49回返
        if (KaeshiNamikiri.CanUse(out act, CanUseOption.MustUse)) return true;

        var IsTargetBoss = HostileTarget?.IsBossFromTTK() ?? false;
        var IsTargetDying = HostileTarget?.IsDying() ?? false;

        //燕回返
        if (KaeshiGoken.CanUse(out act, CanUseOption.MustUse | CanUseOption.EmptyOrSkipCombo)) return true;
        if (KaeshiSetsugekka.CanUse(out act, CanUseOption.MustUse | CanUseOption.EmptyOrSkipCombo)) return true;

        //奥$4E49$65A9浪
        if ((!IsTargetBoss || (HostileTarget?.HasStatus(true, StatusID.Higanbana) ?? false)) && HasMoon && HasFlower
            && OgiNamikiri.CanUse(out act, CanUseOption.MustUse)) return true;

        //$5904理居合$672F
        if (SenCount == 1 && IsTargetBoss && !IsTargetDying)
        {
            if (HasMoon && HasFlower && Higanbana.CanUse(out act)) return true;
        }
        if (SenCount == 2)
        {
            if (TenkaGoken.CanUse(out act, !MidareSetsugekka.EnoughLevel ? CanUseOption.MustUse : CanUseOption.None)) return true;
        }
        if (SenCount == 3)
        {
            if (MidareSetsugekka.CanUse(out act)) return true;
        }

        //$8FDE$51FB2
        if ((!HasMoon || IsMoonTimeLessThanFlower || !Oka.EnoughLevel) && Mangetsu.CanUse(out act, HaveMeikyoShisui && !HasGetsu ? CanUseOption.EmptyOrSkipCombo : CanUseOption.None)) return true;
        if ((!HasFlower || !IsMoonTimeLessThanFlower) && Oka.CanUse(out act, HaveMeikyoShisui && !HasKa ? CanUseOption.EmptyOrSkipCombo : CanUseOption.None)) return true;
        if (!HasSetsu && Yukikaze.CanUse(out act, HaveMeikyoShisui && HasGetsu && HasKa && !HasSetsu ? CanUseOption.EmptyOrSkipCombo : CanUseOption.None)) return true;

        //$8FDE$51FB3
        if (Gekko.CanUse(out act, HaveMeikyoShisui && !HasGetsu ? CanUseOption.EmptyOrSkipCombo : CanUseOption.None)) return true;
        if (Kasha.CanUse(out act, HaveMeikyoShisui && !HasKa ? CanUseOption.EmptyOrSkipCombo : CanUseOption.None)) return true;

        //$8FDE$51FB2
        if ((!HasMoon || IsMoonTimeLessThanFlower || !Shifu.EnoughLevel) && Jinpu.CanUse(out act)) return true;
        if ((!HasFlower || !IsMoonTimeLessThanFlower) && Shifu.CanUse(out act)) return true;

        if (!HaveMeikyoShisui)
        {
            //$8FDE$51FB1
            if (Fuko.CanUse(out act)) return true;
            if (!Fuko.EnoughLevel && Fuga.CanUse(out act)) return true;
            if (Hakaze.CanUse(out act)) return true;

            //燕$98DE
            if (Enpi.CanUse(out act)) return true;
        }

        return base.GeneralGCD(out act);
    }

    protected override bool AttackAbility(out IAction act)
    {
        var IsTargetBoss = HostileTarget?.IsBossFromTTK() ?? false;
        var IsTargetDying = HostileTarget?.IsDying() ?? false;

        //意气冲天
        if (Kenki <= 50 && Ikishoten.CanUse(out act)) return true;

        //叶$9690
        if ((HostileTarget?.HasStatus(true, StatusID.Higanbana) ?? false) && (HostileTarget?.WillStatusEnd(32, true, StatusID.Higanbana) ?? false) && !(HostileTarget?.WillStatusEnd(28, true, StatusID.Higanbana) ?? false) && SenCount == 1 && IsLastAction(true, Yukikaze) && !HaveMeikyoShisui)
        {
            if (Hagakure.CanUse(out act)) return true;
        }

        //$95EA影、$7EA2$83B2
        if (HasMoon && HasFlower)
        {
            if (HissatsuGuren.CanUse(out act, !HissatsuSenei.EnoughLevel ? CanUseOption.MustUse : CanUseOption.None)) return true;
            if (HissatsuSenei.CanUse(out act)) return true;
        }

        //照破、无明照破
        if (Shoha2.CanUse(out act)) return true;
        if (Shoha.CanUse(out act)) return true;

        //震天、九天
        if (Kenki >= 50 && Ikishoten.WillHaveOneCharge(10) || Kenki >= Configs.GetInt("addKenki") || IsTargetBoss && IsTargetDying)
        {
            if (HissatsuKyuten.CanUse(out act)) return true;
            if (HissatsuShinten.CanUse(out act)) return true;
        }

        return base.AttackAbility(out act);
    }
    protected override bool EmergencyAbility(IAction nextGCD, out IAction act)
    {
        var IsTargetBoss = HostileTarget?.IsBossFromTTK() ?? false;
        var IsTargetDying = HostileTarget?.IsDying() ?? false;

        //明$955C止水
        if (HasHostilesInRange && IsLastGCD(true, Yukikaze, Mangetsu, Oka) &&
            (!IsTargetBoss || (HostileTarget?.HasStatus(true, StatusID.Higanbana) ?? false) && !(HostileTarget?.WillStatusEnd(40, true, StatusID.Higanbana) ?? false) || !HasMoon && !HasFlower || IsTargetBoss && IsTargetDying))
        {
            if (MeikyoShisui.CanUse(out act, CanUseOption.EmptyOrSkipCombo)) return true;
        }
        return base.EmergencyAbility(nextGCD, out act);
    }


    protected override IAction CountDownAction(float remainTime)
    {
        //$5F00局使用明$955C
        if (remainTime <= 5 && MeikyoShisui.CanUse(out _, CanUseOption.IgnoreClippingCheck)) return MeikyoShisui;
        //真北防止boss面向没到位
        if (remainTime <= 2 && TrueNorth.CanUse(out _, CanUseOption.IgnoreClippingCheck)) return TrueNorth;
        return base.CountDownAction(remainTime);
    }
}