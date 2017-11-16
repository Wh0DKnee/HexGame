using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using System;
using NetworkingCommonLib;
using UnityEngine.SceneManagement;

public class ClientProxyImpl : IClientProxy {

    public PlayerInfo PlayerInfo { get; private set; }

    public ClientProxyImpl(PlayerInfo info) {
        PlayerInfo = info;
    }

    public event Action EnemyTurnEnd;

    public void MoveChampion(int championID, HexCoordinates coordinates) {
        UnityMainThreadDispatcher.Instance().Enqueue(() => HexGrid.Instance.GetChamp(championID).Move(coordinates));
    }

    public void UseSkill(int championID, Skill skill, HexCoordinates targetCellCoordinates) {
        UnityMainThreadDispatcher.Instance().Enqueue(() => HexGrid.Instance.GetChamp(championID).UseSkill(skill, HexGrid.Instance.GetCell(targetCellCoordinates)));
    }

    public void ChangeScene(string sceneName) {
        //TODO: maybe refactor this into some command pattern, so that we only have one place where we have to know
        // how to invoke methods thread safe in unity
        UnityMainThreadDispatcher.Instance().Enqueue(() => SceneManager.LoadScene("gameScene"));
    }

    public PlayerInfo GetClientInfo() {
        return PlayerInfo;
    }

    public void SpawnChampions(ChampionPosition[] allyChampionPositions, ChampionPosition[] enemyChampionPositions) {
        UnityMainThreadDispatcher.Instance().Enqueue(() => PieceSpawner.instance.InstantiateAllChampions(allyChampionPositions, enemyChampionPositions));
    }

    public void SendGameInfo(string opponentName, bool leftSide) {
        GameInfo.opponentName = opponentName;
        GameInfo.isLeftSide = leftSide;
    }

    public void InitializeGameState() {
        UnityMainThreadDispatcher.Instance().Enqueue(() => GameStateControllerInitializer.instance.InitializeGameStateController());
    }

    public void EnemyTurnDone() {
        Debug.Log("Enemy turn done");
        if(EnemyTurnEnd != null) { EnemyTurnEnd(); }
    }
}
