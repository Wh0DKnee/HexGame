using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Skill{

    public int Range { get; set; }
    public Cost SkillCost { get; set;}
    public TargetType TargetType { get; private set; }
    public Champion User { get; private set; }

    protected Skill(Cost skillCost, TargetType targetType, int range, Champion user) {
        this.SkillCost = skillCost;
        this.TargetType = targetType;
        this.Range = range;
        this.User = user;
    }

    public void Use(Cell target) {
        SkillCost.ApplyCost(User);
        ApplyEffect(target);
    }

    public abstract void ApplyEffect(Cell target);

    public abstract StateHighlighter GetHighlighter();
    
}
