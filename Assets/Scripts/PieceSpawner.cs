using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour {

    public GameObject basicChamp;
    public Transform pieceContainer;
    private int idCounter = 0;

	// Use this for initialization
	public void Spawn () {
        InstantiateChampion(basicChamp, 0, 0, 0, false);
        InstantiateChampion(basicChamp, 0, 1, -1, false);
        InstantiateChampion(basicChamp, 2, -2, 0, true);
	}

    void InstantiateChampion(GameObject piece, int x, int y, int z, bool isEnemy) {
        GameObject go = (GameObject)Instantiate(basicChamp, pieceContainer);
        Champion champ = go.GetComponent<Champion>();
        champ.IsEnemyChamp = isEnemy;
        champ.ID = idCounter;
        idCounter++;
        HexGrid.Instance.AddPiece(champ, HexCoordinates.CreateInstance(x, y, z));
    }
	
	
}
