using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SkillValidation{

	public static bool CanChampUseSkill(Champion champ, Skill skill, Cell target) {
        if(skill == null) { Debug.Log("skill is null"); return false; }

        return IsValidTarget(champ, skill, target)
            && HasEnoughResources(champ, skill)
            && IsInRange(champ, skill, target);
    }

    private static bool IsValidTarget(Champion champ, Skill skill, Cell target) {
        return skill.TargetType.IsValidTarget(target, champ);
    }

    private static bool HasEnoughResources(Champion champ, Skill skill) {
        return skill.SkillCost.HasUserEnoughResources(champ);
    }

    private static bool IsInRange(Champion champ, Skill skill, Cell target) {
        HexCoordinates vector = target.coordinates - champ.GetCell().coordinates;
        if (Array.IndexOf(skill.GetRangeVectors(), vector) > -1) {
            return true;
        } else {
            return false;
        }
    }
}
