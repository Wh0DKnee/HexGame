using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChampion : Champion {

    public override void InitializeSkills() {
        Q = SkillFactory.CreateMeleeAttackInstance();
        W = SkillFactory.CreateMeleeAttackInstance();
        E = SkillFactory.CreateMeleeAttackInstance();
        R = SkillFactory.CreateAOEExampleSkill();
    }

    public override void InitializeStats() {
        HP = 20;
        Mana = 6;
        MaxMovementRange = 3;
    }
}
