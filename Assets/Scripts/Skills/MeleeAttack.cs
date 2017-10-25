using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Skill {

    private int damage = 10;

    public MeleeAttack(Champion champ) : base(champ) { Debug.Log("Initializing melee attack for " + champ); }

    public override void InitializeCost() {
        SkillCost = new ManaCost(5, champion);
    }

    public override void InitializeTargetType() {
        targetType = TargetType.enemy;
    }

    public override void Use(Cell target) {
        base.Use(target);
        target.champion.HP -= damage;
    }
}
