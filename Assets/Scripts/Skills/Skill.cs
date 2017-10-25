using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill{

    public enum TargetType {
        enemy,
        ally,
        self,
        AOE
    }
    public int range;
    public Cost SkillCost { get; set;}
    public TargetType targetType;
    public Champion champion;

    protected Skill(Champion champion) {
        this.champion = champion;
        InitializeTargetType();
        InitializeCost();
    }

    public abstract void InitializeTargetType();
    public abstract void InitializeCost();

    public virtual bool IsValidTarget(Cell targetCell) {
        switch (targetType) {
            case TargetType.enemy:
                return targetCell.HasEnemyChamp();
            case TargetType.ally:
                return targetCell.HasAlliedChamp() && targetCell.champion != champion;
            case TargetType.self:
                return targetCell.champion == champion;
            case TargetType.AOE:
                return true;
            default:
                return false;
        }
    }

    public bool TryUse(Cell target) {
        if (!IsValidTarget(target)/*create function that checks this plus range, mana, etc*/) {
            Debug.Log("Invalid target");
            return false;
        }
        Use(target);
        return true;
    }
    
    public virtual void Use(Cell target) {
        SkillCost.ApplyCost();
    }
    
}
