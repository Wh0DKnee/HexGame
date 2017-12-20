using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class SkillShot : Skill {

    public SkillShot(ChampionStats userStats, Cost skillCost, TargetType targetType, int range) : base(userStats, skillCost, targetType, range) {}

    public override List<Cell> GetAffectedArea(Cell target) {
        List<Cell> result = new List<Cell>();
        if(!HexMath.AreInStraightLine(userStats.Coordinates, target.coordinates)) {
            return result;
        }
        //TODO: refactor this
        HexCoordinates distance = target.coordinates - userStats.Coordinates;
        int normalizedX = DivideByAbsIsNotZero(distance.X);
        int normalizedY = DivideByAbsIsNotZero(distance.Y);
        int normalizedZ = DivideByAbsIsNotZero(distance.Z);
        HexCoordinates normalizedDistance = new HexCoordinates(normalizedX, normalizedY, normalizedZ);

        for (int i = 0; i <= Range; i++) {
            Cell c = HexGrid.Instance.GetCell(userStats.Coordinates + normalizedDistance * i);
            if(c != null) {
                result.Add(c);
            }
        }

        return result;
    }

    private int DivideByAbsIsNotZero(int val) {
        if(val == 0) {
            return val;
        }

        return val / Math.Abs(val);
    }
}
