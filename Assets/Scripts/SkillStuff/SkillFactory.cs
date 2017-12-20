using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillFactory{

	public static MeleeAttack CreateMeleeAttackInstance(ChampionStats championStats) {
        return new MeleeAttack(championStats, new ManaCost(5), TargetType.enemy, 1);
    }

    public static AOEExampleSkill CreateAOEExampleSkill(ChampionStats championStats) {
        return new AOEExampleSkill(championStats, new ManaCost(1), TargetType.all, 5, 1);
    }

    public static SkillShotExample CreateSkillShotExample(ChampionStats championStats) {
        return new SkillShotExample(championStats, new ManaCost(2), TargetType.all, 4);
    }

    public static SingleTargetAllyHeal CreateSingleTargetAllyHeal(ChampionStats championStats) {
        return new SingleTargetAllyHeal(championStats, new ManaCost(1), TargetType.ally, 4);
    }
}
