using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RangedAttack : SingleTargetSkill {

    private int damage = 10;

    public RangedAttack(Cost skillCost, TargetType targetType, int range) : base(skillCost, targetType, range) {}

    public override void ApplyEffect(Champion user, Cell target) {
        target.champion.HP -= damage;
    }
}
