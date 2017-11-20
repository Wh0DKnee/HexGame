using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RangedAttack : SingleTargetSkill {

    private int damage = 10;

    public RangedAttack(Cost skillCost, TargetType targetType, int range, Champion user) : base(skillCost, targetType, range, user) {}

    public override void ApplyEffect(Cell target) {
        target.champion.HP -= damage;
    }

    public override StateHighlighter GetHighlighter() {
        throw new NotImplementedException();
    }
}
