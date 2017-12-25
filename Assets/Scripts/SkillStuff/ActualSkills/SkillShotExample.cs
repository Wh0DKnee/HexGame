using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SkillShotExample : SkillShot {

    private int damage = 20;

    public SkillShotExample(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) : base(userStats, skillCost, targetType, range) {
    }

    public override void ApplyEffect(Cell target) {
        List<Cell> targetArea = GetAffectedArea(target);
        List<Champion> affectedChamps = GetAffectedChampions(targetArea, TargetType.enemy);

        foreach (Champion champ in affectedChamps) {
            champ.Stats.HP -= 20;
        }
    }
}
