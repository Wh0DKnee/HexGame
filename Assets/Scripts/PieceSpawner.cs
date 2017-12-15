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
                InstantiateChampion(allyChampionPositions[i].ChampionName, allyChampionPositions[i].HexCoordinates, false);
            }
            for (int i = 0; i < enemyChampionPositions.Length; i++) {
                InstantiateChampion(enemyChampionPositions[i].ChampionName, HexMath.HexMirrorAtOrigin(enemyChampionPositions[i].HexCoordinates), true);
            }
        } else {
            for (int i = 0; i < enemyChampionPositions.Length; i++) {
                InstantiateChampion(enemyChampionPositions[i].ChampionName, enemyChampionPositions[i].HexCoordinates, true);
            }
            for (int i = 0; i < allyChampionPositions.Length; i++) {
                InstantiateChampion(allyChampionPositions[i].ChampionName, HexMath.HexMirrorAtOrigin(allyChampionPositions[i].HexCoordinates), false);
            }
        }
        
        if(championsLoaded != null) { championsLoaded(); }
    }

    public void InstantiateChampion(string championName, HexCoordinates coordinates, bool isEnemy) {
        print("instantiating champ");
        GameObject champGO = ChampionNameToGameObject(championName);
        print(champGO.name);
        GameObject go = Instantiate(ChampionNameToGameObject(championName), pieceContainer);
        Champion champ = go.GetComponent<Champion>();
        print(go.transform.parent.name);
        champ.IsEnemyChamp = isEnemy;
        if (isEnemy) {
            go.GetComponent<MeshRenderer>().material.color = Color.red; //for testing
        }
        champ.Stats.ID = idCounter;
        idCounter++;
        HexGrid.Instance.AddChamp(champ, coordinates);
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
