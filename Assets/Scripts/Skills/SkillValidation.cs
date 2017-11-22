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
        bool isValidTarget = skill.TargetType.IsValidTarget(target, champ);
        if (!isValidTarget) {
            Debug.Log("not a valid target");
        }
        return isValidTarget;
    }

    private static bool HasEnoughResources(Champion champ, Skill skill) {
        bool hasEnoughResources = skill.SkillCost.HasUserEnoughResources(champ);
        if (!hasEnoughResources) {
            Debug.Log("not enough resources");
        }
        return hasEnoughResources;
    }

    private static bool IsInRange(Champion champ, Skill skill, Cell target) {
        bool isInRange = HexMath.HexDistance(target.coordinates, champ.GetCell().coordinates) <= skill.Range;
        if (!isInRange) {
            Debug.Log("not in range");
        }
        return isInRange;
    }
}
