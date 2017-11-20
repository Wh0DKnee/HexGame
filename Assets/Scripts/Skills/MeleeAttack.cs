using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeleeAttack : SingleTargetSkill {

    private int damage = 10;

    public MeleeAttack(Cost skillCost, TargetType targetType, int range, Champion user) : base(skillCost, targetType, range, user) {}

    public override void ApplyEffect(Cell target) {
        target.champion.HP -= damage;
    }

    public override StateHighlighter GetHighlighter() {
        return new SingleTargetSkillStateHighlighter(CellHighlighter.instance, User);
    }
}
