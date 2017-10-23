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

    public TargetType targetType;

    public virtual bool CanUseAbility(Cell targetCell) {
        return false; //TODO: implement
    }
}
