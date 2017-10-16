using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {

    private HexCoordinates[] moves;

    void Awake() {
     moves = new HexCoordinates[]{
        HexCoordinates.CreateInstance(1,-1,0), HexCoordinates.CreateInstance(1,0,-1), HexCoordinates.CreateInstance(0,1,-1),
        HexCoordinates.CreateInstance(-1,1,0), HexCoordinates.CreateInstance(-1,0,1), HexCoordinates.CreateInstance(0,-1,1)};
    }

    public override HexCoordinates[] GetMoves() {
        return moves;
    }

    //this should not be in this class
    /*public void HighlightMoves() {
        Cell cell = GetCell();
        HexCoordinates target;
        for (int i = 0; i < moves.Length; i++) {
            target = cell.coordinates + moves[i];
            if (HexGrid.Instance.Contains(target)) {
                CellHighlighter.instance.Highlight(HexGrid.Instance.GetCell(target));
            }
        }
    }*/
}
