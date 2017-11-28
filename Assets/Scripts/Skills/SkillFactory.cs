using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillFactory{

	public static MeleeAttack CreateMeleeAttackInstance() {
        return new MeleeAttack(new ManaCost(5), TargetType.enemy, 1);
    }

    public static AOEExampleSkill CreateAOEExampleSkill() {
        return new AOEExampleSkill(new ManaCost(0), TargetType.all, 5, 1);
    }
}
