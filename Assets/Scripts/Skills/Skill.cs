using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Skill : IStateHandler{

    public int Range { get; set; }
    public Cost SkillCost { get; set;}
    public TargetType TargetType { get; private set; }
    public ChampionStats userStats;

    protected Skill(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) {
        this.SkillCost = skillCost;
        this.TargetType = targetType;
        this.Range = range;
        this.userStats = userStats;
    }

    public void Use(Cell target) {
        SkillCost.ApplyCost(userStats);
        ApplyEffect(target);
    }

    public abstract void ApplyEffect(Cell target);

    public virtual GameState GetNextState(StateChangeParams parameters) {
        return new SelectionState(parameters.gameStateController);
    }

    public abstract List<Cell> GetAffectedArea(Cell target);
}
