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
        Q = SkillFactory.CreateMeleeAttackInstance();
        W = SkillFactory.CreateMeleeAttackInstance();
        E = SkillFactory.CreateMeleeAttackInstance();
        R = SkillFactory.CreateMeleeAttackInstance();
    }

    public override void InitializeStats() {
        HP = 20;
        Mana = 6;
        MaxMovementRange = 3;
    }
}
