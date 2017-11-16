using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.ScsServices.Client;
using System;

namespace NetworkingCommonLib {

    public interface IClientProxy {

        event Action EnemyTurnEnd;

        PlayerInfo GetClientInfo();

        void SendGameInfo(string opponentName, bool leftSide);

        void MoveChampion(int championID, HexCoordinates coordinates);

        void UseSkill(int championID, Skill skill, HexCoordinates targetCellCoordinates);

        void EnemyTurnDone();

        void ChangeScene(string sceneName);

        void SpawnChampions(ChampionPosition[] allyChampionPositions, ChampionPosition[] enemyChampionPositions);

        //TODO: should really the server call this, or can the clients automatically initialize the state after the champions are spawned?
        void InitializeGameState();
    }
}
