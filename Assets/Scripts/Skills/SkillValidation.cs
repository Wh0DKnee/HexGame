using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillValidation{

	public static bool ChampTryUseSkill(Champion champ, Skill skill, Cell target) {
        if(skill == null) { Debug.Log("skill is null"); return false; }

        return IsValidTarget(champ, skill, target)
            && HasEnoughResources(champ, skill)
            && IsInRange(skill, target);
    }

    private static bool IsValidTarget(Champion champ, Skill skill, Cell target) {
        return skill.targetType.IsValidTarget(target, champ);
    }

    private static bool HasEnoughResources(Champion champ, Skill skill) {
        return skill.SkillCost.HasUserEnoughResources(champ);
    }

    private static bool IsInRange(Skill skill, Cell target) {
        return true; //TODO: implement
    }
}
