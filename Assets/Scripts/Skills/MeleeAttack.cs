using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeleeAttack : SingleTargetSkill {

    private int damage = 10;
    private HexCoordinates[] rangeVectors;

    void Awake() {
        rangeVectors = new HexCoordinates[]{
        new HexCoordinates(1,-1,0), new HexCoordinates(1,0,-1), new HexCoordinates(0,1,-1),
        new HexCoordinates(-1,1,0), new HexCoordinates(-1,0,1), new HexCoordinates(0,-1,1)};
    }

    public MeleeAttack(Cost skillCost, TargetType targetType) : base(skillCost, targetType) {}

    public override void ApplyEffect(Champion user, Cell target) {
        target.champion.HP -= damage;
    }

    public override HexCoordinates[] GetRangeVectors() {
        return rangeVectors;
    }
}
