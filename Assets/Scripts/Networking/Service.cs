﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Server;
using Hik.Collections;
using Hik.Communication.ScsServices.Service;
using System;
using NetworkingCommonLib;

public class Service : ScsService, IServiceProxy {

    private ThreadSafeSortedList<long, ServiceClient> clients;

    public event Action<IScsServiceClient> clientRegistered;
    
    private int readyCount;

    public Service() {
        clients = new ThreadSafeSortedList<long, ServiceClient>();
    }

    public void GetEnemyChampions() {
        var client = CurrentClient;
        IClientProxy proxy = client.GetClientProxy<IClientProxy>();
        Debug.Log("Client called GetEnemyChampions");
    }

    public void RequestMove(int championID, HexCoordinates coordinates) {
        foreach (ServiceClient client in clients.GetAllItems()) {
            client.ClientProxy.MoveChampion(championID, coordinates);
        }
    }

    public void RequestSkillUse(int userID, SkillEnum skillEnum, HexCoordinates target) {
        foreach (ServiceClient client in clients.GetAllItems()) {
            client.ClientProxy.UseSkill(userID, skillEnum, target);
        }
    }

    //No parameter necessary, we can access the callee via the CurrentClient property
    public void RegisterPlayer() {
        clients[CurrentClient.ClientId] = new ServiceClient(CurrentClient, CurrentClient.GetClientProxy<IClientProxy>());
        if(clientRegistered != null) { clientRegistered(CurrentClient); }
    }

    public int GetClientCount() {
        Debug.Log("client count: " + clients.GetAllItems().Count);
        return clients.GetAllItems().Count;
    }

    public void ChangeScene(string sceneName) {
        foreach (ServiceClient client in clients.GetAllItems()) {
            client.ClientProxy.ChangeScene(sceneName);
        }
    }

    public void GameSceneLoaded() {
        readyCount++;
        if (readyCount == 2) {
            StartGame();
        }
    }

    private void StartGame() {
        SendClientsInfo();
        SpawnChampions();
        InitializeGameState();
    }

    private ChampionPosition[] GetChampionPositions(int clientID) {
        return clients[clientID].ClientProxy.GetClientInfo().championPositions;
    }

    private void SendClientsInfo() {
        clients[1].ClientProxy.SendGameInfo(clients[2].ClientProxy.GetClientInfo().nickname, true);
        clients[2].ClientProxy.SendGameInfo(clients[1].ClientProxy.GetClientInfo().nickname, false);
    }

    private void SpawnChampions() {
        clients[1].ClientProxy.SpawnChampions(GetChampionPositions(1), GetChampionPositions(2));
        clients[2].ClientProxy.SpawnChampions(GetChampionPositions(2), GetChampionPositions(1));
    }

    private void InitializeGameState() {
        foreach (ServiceClient client in clients.GetAllItems()) {
            client.ClientProxy.InitializeGameState();
        }
    }

    public void TurnDone() {
        if (CurrentClient.ClientId == 1) {
            clients[2].ClientProxy.EnemyTurnDone();
        } else {
            clients[1].ClientProxy.EnemyTurnDone();
        }
    }

    private sealed class ServiceClient {

        public IScsServiceClient Client { get; private set; }

        public IClientProxy ClientProxy { get; private set; }

        public ServiceClient(IScsServiceClient client, IClientProxy clientProxy) {
            Client = client;
            ClientProxy = clientProxy;
        }
    }

}
