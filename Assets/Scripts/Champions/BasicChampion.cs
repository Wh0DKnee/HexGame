using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChampion : Champion {

    private HexCoordinates[] moves;

    void Awake() {
     moves = new HexCoordinates[]{
        new HexCoordinates(1,-1,0), new HexCoordinates(1,0,-1), new HexCoordinates(0,1,-1),
        new HexCoordinates(-1,1,0), new HexCoordinates(-1,0,1), new HexCoordinates(0,-1,1)};
    }

    public override void InitializeSkills() {
        Q = SkillFactory.CreateMeleeAttackInstance(this);
        W = SkillFactory.CreateMeleeAttackInstance(this);
        E = SkillFactory.CreateMeleeAttackInstance(this);
        R = SkillFactory.CreateMeleeAttackInstance(this);
    }

    public override void InitializeStats() {
        HP = 20;
        Mana = 6;
        MaxMovementRange = 3;
    }
}
