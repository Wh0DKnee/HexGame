using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill{

    public int Range { get; set; }
    public Cost SkillCost { get; set;}
    public TargetType targetType;

    protected Skill(Cost skillCost, TargetType targetType) {
        this.SkillCost = skillCost;
        this.targetType = targetType;
    }

    public virtual void Use(Champion user, Cell target) {
        SkillCost.ApplyCost(user);
    }
    
}
