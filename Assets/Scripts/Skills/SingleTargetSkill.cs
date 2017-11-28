using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class SingleTargetSkill : Skill {
    public SingleTargetSkill(Cost skillCost, TargetType targetType, int range) : base(skillCost, targetType, range) {}

    public override List<Cell> GetAffectedArea(Cell target) {
        return new List<Cell>() { target };
    }
}
