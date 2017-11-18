using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO: make it possible to have line skills with proper highlighting
[Serializable]
public abstract class Skill{

    public int Range { get; set; }
    public Cost SkillCost { get; set;}
    public TargetType TargetType { get; private set; }

    protected Skill(Cost skillCost, TargetType targetType, int range) {
        this.SkillCost = skillCost;
        this.TargetType = targetType;
        this.Range = range;
    }

    public void Use(Champion user, Cell target) {
        SkillCost.ApplyCost(user);
        ApplyEffect(user, target);
    }

    public abstract void ApplyEffect(Champion user, Cell target);
    
}
