using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeleeAttack : SingleTargetSkill {

    private int damage = 10;

    public MeleeAttack(Cost skillCost, TargetType targetType, int range) : base(skillCost, targetType, range) {}

    public override void ApplyEffect(Cell target) {
        target.champion.HP -= damage;
    }

    public override StateHighlighter GetHighlighter(Champion user) {
        return new SingleTargetSkillStateHighlighter(CellHighlighter.instance, user);
    }
}
