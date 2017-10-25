﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour {

    public GameObject pawn;
    public Transform pieceContainer;

	// Use this for initialization
	public void Spawn () {
        InstantiateAlly(pawn, 0, 0, 0);
        InstantiateAlly(pawn, 0, 1, -1);
        InstantiateEnemy(pawn, 2, -2, 0);
	}

    void InstantiateAlly(GameObject piece, int x, int y, int z) {
        GameObject p = (GameObject)Instantiate(pawn, pieceContainer);
        HexGrid.Instance.AddPiece(p.GetComponent<Champion>(), HexCoordinates.CreateInstance(x, y, z));
    }

    void InstantiateEnemy(GameObject piece, int x, int y, int z) {
        GameObject p = (GameObject)Instantiate(pawn, pieceContainer);
        p.GetComponent<Champion>().IsEnemyChamp = true;
        HexGrid.Instance.AddPiece(p.GetComponent<Champion>(), HexCoordinates.CreateInstance(x, y, z));
    }
	
	
}
