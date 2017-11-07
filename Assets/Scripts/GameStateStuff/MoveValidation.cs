using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveValidation{

    //TODO: should this become a performance issue, we might as well precalculate all possible moves at the start
    //of each turn and store them in a LUP
    public static bool CanChampMove(Champion champion, Cell target) {
        if (target.HasChamp()) { return false; }

        HexCoordinates[] moves = champion.GetMoves();
        bool reachable = false;
        foreach (HexCoordinates move in moves) {
            if (champion.GetCell().coordinates + move == target.coordinates) {
                reachable = true;
            }
        }
        return reachable;
    }

}
