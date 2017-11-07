using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType {
    enemy,
    ally,
    self,
    AOE,
    empty
}

static class TargetTypeMethods {
    
    public static bool IsValidTarget(this TargetType targetType, Cell targetCell, Champion user) {
        switch (targetType) {
        case TargetType.enemy:
            return targetCell.HasEnemyChamp();
        case TargetType.ally:
            return targetCell.HasAlliedChamp() && targetCell.champion != user;
        case TargetType.self:
            return targetCell.champion == user;
        case TargetType.AOE:
            return true;
        case TargetType.empty:
            return !targetCell.HasChamp();
        default:
            return false;
    }
    }
}
