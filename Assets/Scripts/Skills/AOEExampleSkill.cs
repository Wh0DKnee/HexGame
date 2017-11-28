﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AOEExampleSkill : AOESkill {

    private int damage = 20;

    public AOEExampleSkill(Cost skillCost, TargetType targetType, int range, int radius) : base(skillCost, targetType, range, radius) {}

    public override void ApplyEffect(Cell target) {
        List<Cell> targetCells = GetAffectedArea(target);
        foreach (Cell cell in targetCells) {
            if(cell.champion != null) {
                cell.champion.HP -= damage;
            }
        }
    }
}