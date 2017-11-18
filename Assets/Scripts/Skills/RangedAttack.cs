using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RangedAttack : Skill {

    private int damage = 10;

    public RangedAttack(Cost skillCost, TargetType targetType) : base(skillCost, targetType) {}

    public override void ApplyEffect(Champion user, Cell target) {
        target.champion.HP -= damage;
    }

    public override HexCoordinates[] GetRangeVectors() {
        throw new NotImplementedException();
    }
}
