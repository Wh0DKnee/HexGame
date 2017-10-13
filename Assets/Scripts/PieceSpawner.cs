using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour {

    public GameObject pawn;
    public Transform pieceContainer;

	// Use this for initialization
	void Awake () {
        GameObject p = (GameObject)Instantiate(pawn, pieceContainer);
        HexGrid.Instance.AddPiece(p.GetComponent<Piece>(), HexCoordinates.CreateInstance(0, 0, 0));
	}
	
	
}
