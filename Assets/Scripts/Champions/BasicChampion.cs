using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChampion : Champion {

    public override void InitializeSkills() {
        Q = SkillFactory.CreateMeleeAttackInstance(Stats);
        W = SkillFactory.CreateMeleeAttackInstance(Stats);
        E = SkillFactory.CreateSkillShotExample(Stats);
        R = SkillFactory.CreateAOEExampleSkill(Stats);
    }

    public override void InitializeStats() {
        Stats.HP = 20;
        Stats.Mana = 100;
        Stats.MaxMovementRange = 3;
    }
}
