using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public static class MoveValidation{

    public static bool CanChampMove(Champion champion, Cell target, out List<Cell> path) {
        path = new List<Cell>();
        if (target.HasChamp()) { return false; }

        path = AStarPathfinding.FindPath(champion.GetCell(), target);
        if(path.Count - 1 <= champion.RemainingMovementRange) {
            return true;
        } else {
            return false;
        }
    }

    public static bool CanChampMove(Champion champion, Cell target) {
        List<Cell> path = new List<Cell>();
        return CanChampMove(champion, target, out path);
    }

}
