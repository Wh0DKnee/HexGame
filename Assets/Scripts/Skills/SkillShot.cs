using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class SkillShot : Skill {

    public SkillShot(Cost skillCost, TargetType targetType, int range) : base(skillCost, targetType, range) {}

    public override List<Cell> GetAffectedArea(Cell target) {
        throw new NotImplementedException();
    }
}
