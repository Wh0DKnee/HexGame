using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeleeAttack : SingleTargetSkill {

    private int damage = 10;

    public MeleeAttack(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) : base(userStats, skillCost, targetType, range) {}

    public override void ApplyEffect(Cell target) {
        target.champion.Stats.HP -= damage;
    }

    public override SkillEnum GetSkillEnum() {
        return SkillEnum.Q;
    }
}
