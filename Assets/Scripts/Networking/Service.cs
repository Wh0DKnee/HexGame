using System.Collections;
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

    public Service() {
        clients = new ThreadSafeSortedList<long, ServiceClient>();
    }

    public void GetEnemyChampions() {
        var client = CurrentClient;
        IClientProxy proxy = client.GetClientProxy<IClientProxy>();
        Debug.Log("Client called GetEnemyChampions");
    }

    public void RequestMove(int championID, HexCoordinates coordinates) {
        throw new NotImplementedException();
    }

    public void RequestAbility(int championID, HexCoordinates target) {
        throw new NotImplementedException();
    }

    public void RegisterPlayer(PlayerInfo info) {
        Debug.Log("Registering " + info.nickname);
        clients[CurrentClient.ClientId] = new ServiceClient(CurrentClient, CurrentClient.GetClientProxy<IClientProxy>());
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

    private sealed class ServiceClient {

        public IScsServiceClient Client { get; private set; }

        public IClientProxy ClientProxy { get; private set; }

        public ServiceClient(IScsServiceClient client, IClientProxy clientProxy) {
            Client = client;
            ClientProxy = clientProxy;
        }
    }

}
