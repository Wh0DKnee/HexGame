using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Skill : IStateHandler{

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
        ApplyEffect(target);
    }

    public abstract void ApplyEffect(Cell target);

    public abstract StateHighlighter GetHighlighter(Champion user);

    public virtual GameState GetNextState(StateChangeParams parameters) {
        return new SelectionState(parameters.gameStateController);
    }
}
