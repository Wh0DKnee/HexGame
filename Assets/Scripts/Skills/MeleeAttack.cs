using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Skill {

    private int damage = 10;

    public MeleeAttack(Cost skillCost, TargetType targetType) : base(skillCost, targetType) {}

    public override void Use(Champion user, Cell target) {
        base.Use(user, target);
        target.champion.HP -= damage;
    }
}
