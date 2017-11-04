using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkingCommonLib;
using System;

public class PieceSpawner : MonoBehaviour {

    public static PieceSpawner instance;

    public GameObject basicChamp;

    public Transform pieceContainer;
    private int idCounter = 0;

    public event Action championsLoaded;

    private void Awake() {
        if(instance != null) {
            Debug.Log("more than one piecespawner");
        } else {
            instance = this;
        }
    }

    //TODO: refactor this piece of shit
    public void InstantiateAllChampions(ChampionPosition[] allyChampionPositions, ChampionPosition[] enemyChampionPositions) {
        if (GameInfo.isLeftSide) {
            for (int i = 0; i < allyChampionPositions.Length; i++) {
                InstantiateChampion(allyChampionPositions[i].ChampionName, ExtractHexCoordsFromChampionPosition(allyChampionPositions[i]), false);
            }
            for (int i = 0; i < enemyChampionPositions.Length; i++) {
                InstantiateChampion(enemyChampionPositions[i].ChampionName, HexMath.HexMirrorAtOrigin(ExtractHexCoordsFromChampionPosition(enemyChampionPositions[i])), true);
            }
        } else {
            for (int i = 0; i < enemyChampionPositions.Length; i++) {
                InstantiateChampion(enemyChampionPositions[i].ChampionName, ExtractHexCoordsFromChampionPosition(enemyChampionPositions[i]), true);
            }
            for (int i = 0; i < allyChampionPositions.Length; i++) {
                InstantiateChampion(allyChampionPositions[i].ChampionName, HexMath.HexMirrorAtOrigin(ExtractHexCoordsFromChampionPosition(allyChampionPositions[i])), false);
            }
        }
        
        if(championsLoaded != null) { championsLoaded(); }
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

    private HexCoordinates ExtractHexCoordsFromChampionPosition(ChampionPosition championPosition) {
        return HexCoordinates.CreateInstance(championPosition.X, championPosition.Y, championPosition.Z);
    }
		
}
