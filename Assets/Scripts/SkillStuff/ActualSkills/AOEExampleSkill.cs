using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AOEExampleSkill : AOESkill {

    private int damage = 20;

    public AOEExampleSkill(ChampionStats userStats, Cost skillCost, TargetType targetType, int range, int radius) : base(userStats, skillCost, targetType, range, radius) {}

    public override void ApplyEffect(Cell target) {
        List<Cell> targetArea = GetAffectedArea(target);
        List<Champion> affectedChamps = GetAffectedChampions(targetArea, TargetType.enemy);

        foreach (Champion champ in affectedChamps) {
            champ.Stats.HP -= damage;
        }
    }
}
