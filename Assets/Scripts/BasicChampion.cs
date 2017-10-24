using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChampion : Champion {

    private HexCoordinates[] moves;

    void Awake() {
     moves = new HexCoordinates[]{
        HexCoordinates.CreateInstance(1,-1,0), HexCoordinates.CreateInstance(1,0,-1), HexCoordinates.CreateInstance(0,1,-1),
        HexCoordinates.CreateInstance(-1,1,0), HexCoordinates.CreateInstance(-1,0,1), HexCoordinates.CreateInstance(0,-1,1)};
    }

    public override HexCoordinates[] GetMoves() {
        return moves;
    }

    public override bool TryAttack(Cell target) {
        print("trying to attack");
        hasAttacked = true;
        return true;
    }
}
