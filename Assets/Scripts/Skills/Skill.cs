using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill{

    public int Range { get; set; }
    public Cost SkillCost { get; set;}
    public TargetType TargetType { get; private set; }

    protected Skill(Cost skillCost, TargetType targetType) {
        this.SkillCost = skillCost;
        this.TargetType = targetType;
    }

    public virtual void Use(Champion user, Cell target) {
        SkillCost.ApplyCost(user);
    }
    
}
