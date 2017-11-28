using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class AOESkill : Skill {

    public int Radius { get; private set; }

    public AOESkill(Cost skillCost, TargetType targetType, int range, int radius) : base(skillCost, targetType, range) {
        Radius = radius;
    }

    public override List<Cell> GetAffectedArea(Cell target) {
        List<HexCoordinates> circleCoords = HexMath.HexCircle(target.coordinates, Radius);
        List<Cell> targetCells = HexGrid.Instance.GetCells(circleCoords);
        return targetCells;
    }

}
