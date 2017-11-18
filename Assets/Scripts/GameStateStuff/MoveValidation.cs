using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveValidation{

    public static bool CanChampMove(Champion champion, Cell target, out List<HexCoordinates> path) {
        path = new List<HexCoordinates>();
        if (target.HasChamp()) { return false; }

        //TODO: we need to use pathfinding as soon as we introduce obstacles.
        path = HexMath.DrawLine(champion.GetCell().coordinates, target.coordinates);
        if(path.Count - 1 <= champion.RemainingMovementRange) {
            return true;
        } else {
            return false;
        }
    }

}
