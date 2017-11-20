using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class SingleTargetSkill : Skill {
    public SingleTargetSkill(Cost skillCost, TargetType targetType, int range, Champion user) : base(skillCost, targetType, range, user) {}
}
