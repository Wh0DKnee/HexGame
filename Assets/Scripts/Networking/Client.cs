using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using System;
using NetworkingCommonLib;

public class Client {

    IScsServiceClient<IServiceProxy> scsClient;
    ClientProxyImpl clientProxyImpl;

    public Client(string IPAdress, int port, string nickname) {

        clientProxyImpl = new ClientProxyImpl(new PlayerInfo(nickname));

        scsClient = ScsServiceClientBuilder.CreateClient<IServiceProxy>(new ScsTcpEndPoint(IPAdress, port), clientProxyImpl);
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
        scsClient.ServiceProxy.RegisterPlayer(clientProxyImpl.PlayerInfo);
    }

    void OnConnected(object sender, EventArgs e) {
        Debug.Log("I connected to server");
    }

    void OnDisconnected(object sender, EventArgs e) {
        Debug.Log("I disconnected from server");
    }

}
