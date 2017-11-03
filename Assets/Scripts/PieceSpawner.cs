using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkingCommonLib;

public class PieceSpawner : MonoBehaviour {

    public static PieceSpawner instance;

    public GameObject basicChamp;

    public Transform pieceContainer;
    private int idCounter = 0;

    private void Awake() {
        if(instance != null) {
            Debug.Log("more than one piecespawner");
        } else {
            instance = this;
        }
    }

    //TODO: refactor this piece of shit
    public void InstantiateAllChampions(ChampionPosition[] allyChampionPositions, ChampionPosition[] enemyChampionPositions, bool leftSide) {
        if (leftSide) {
            for (int i = 0; i < allyChampionPositions.Length; i++) {
                InstantiateChampion(allyChampionPositions[i].ChampionName, allyChampionPositions[i].Coordinates, false);
            }
            for (int i = 0; i < enemyChampionPositions.Length; i++) {
                InstantiateChampion(enemyChampionPositions[i].ChampionName, enemyChampionPositions[i].Coordinates, true);
            }
        } else {
            for (int i = 0; i < enemyChampionPositions.Length; i++) {
                InstantiateChampion(enemyChampionPositions[i].ChampionName, enemyChampionPositions[i].Coordinates, true);
            }
            for (int i = 0; i < allyChampionPositions.Length; i++) {
                InstantiateChampion(allyChampionPositions[i].ChampionName, allyChampionPositions[i].Coordinates, false);
            }
        }
    }

    public void InstantiateChampion(string championName, HexCoordinates coordinates, bool isEnemy) {
        GameObject go = (GameObject)Instantiate(ChampionNameToGameObject(championName), pieceContainer);
        Champion champ = go.GetComponent<Champion>();
        champ.IsEnemyChamp = isEnemy;
        if (isEnemy) {
            go.GetComponent<MeshRenderer>().material.color = Color.red; //for testing
        }
        champ.ID = idCounter;
        idCounter++;
        HexGrid.Instance.AddPiece(champ, coordinates);
    }

    private GameObject ChampionNameToGameObject(string championName) {
        switch (championName) {
            case "BasicChampion":
                return basicChamp;
            default:
                return null;
        }
    }
		
}
