using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {

    private HexCoordinates[] moves;

    void Awake() {
     moves = new HexCoordinates[]{
        HexCoordinates.CreateInstance(1,-1,0) * 2, HexCoordinates.CreateInstance(1,0,-1) * 2, HexCoordinates.CreateInstance(0,1,-1) * 2,
        HexCoordinates.CreateInstance(-1,1,0) * 2, HexCoordinates.CreateInstance(-1,0,1) * 2, HexCoordinates.CreateInstance(0,-1,1) * 2};
    }

    public override HexCoordinates[] GetMoves() {
        return moves;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            HighlightMoves();
        }
    }

    public void HighlightMoves() {
        Cell cell = GetCell();
        HexCoordinates target;
        for (int i = 0; i < moves.Length; i++) {
            target = cell.coordinates + moves[i];
            if (HexGrid.Instance.Contains(target)) {
                HexGrid.Instance.GetCell(target).Highlight();
            }
        }
    }

    public override void Move(HexCoordinates coords) {
        this.gameObject.transform.position = coords.ToWorldPosition();
        HexGrid.Instance.MovePiece(this, coords);
    }
}
