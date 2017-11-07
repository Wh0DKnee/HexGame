using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using System;
using NetworkingCommonLib;

public class Client {

    IScsServiceClient<IServiceProxy> scsClient;
    public IClientProxy ClientProxy { get; private set; }

    public Client(string IPAdress, int port, string nickname) {

        ClientProxy = new ClientProxyImpl(new PlayerInfo(nickname));

        scsClient = ScsServiceClientBuilder.CreateClient<IServiceProxy>(new ScsTcpEndPoint(IPAdress, port), ClientProxy);
        scsClient.Connected += OnConnected;
        scsClient.Disconnected += OnDisconnected;
    }

    public bool TryConnect() {
        try {
            scsClient.Connect();
        } catch (NullReferenceException) {
            Debug.LogError("Could not connect to the specified server. Make sure the IP address and port match the host's.");
            return false;
        }
        return true;
    }

    public void Register() {
        scsClient.ServiceProxy.RegisterPlayer();
    }

    public void TellServerReady() {
        scsClient.ServiceProxy.GameSceneLoaded();
    }

    public void TellServerTurnDone() {
        scsClient.ServiceProxy.TurnDone();
    }

    public void TellServerMove(int championID, HexCoordinates coordinates) {
        scsClient.ServiceProxy.RequestMove(championID, coordinates);
    }

    void OnConnected(object sender, EventArgs e) {
        Debug.Log("I connected to server");
    }

    void OnDisconnected(object sender, EventArgs e) {
        Debug.Log("I disconnected from server");
    }

}
