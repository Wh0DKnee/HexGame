using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RangedAttack : SingleTargetSkill {

    private int damage = 10;

    public RangedAttack(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) : base(userStats, skillCost, targetType, range) {}

    public override void ApplyEffect(Cell target) {
        target.champion.Stats.HP -= damage;
    }

    public override SkillEnum GetSkillEnum() {
        return SkillEnum.Q;
    }
}
