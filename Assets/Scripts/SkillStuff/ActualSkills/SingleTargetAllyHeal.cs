using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetAllyHeal : SingleTargetSkill {

    private int healAmount = 10;

    public SingleTargetAllyHeal(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) : base(userStats, skillCost, targetType, range) {}

    public override void ApplyEffect(Cell target) {
        target.champion.Stats.HP += healAmount;
    }

    public override SkillEnum GetSkillEnum() {
        return SkillEnum.W;
    }
}
