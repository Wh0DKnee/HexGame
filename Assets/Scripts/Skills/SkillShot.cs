using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class SkillShot : Skill {

    public SkillShot(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) : base(userStats, skillCost, targetType, range) {}

    public override List<Cell> GetAffectedArea(Cell target) {
        throw new NotImplementedException();
    }
}
