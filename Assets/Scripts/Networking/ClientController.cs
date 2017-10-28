using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using System;
using NetworkingCommonLib;

public class ClientController : MonoBehaviour {

    IScsServiceClient<IServerProxy> scsClient;

    void Start() {

        Client client = new Client(new PlayerInfo("WhoDKnee"));

        scsClient = ScsServiceClientBuilder.CreateClient<IServerProxy>(new ScsTcpEndPoint("127.0.0.1", 100), client);
        scsClient.Connected += OnConnected;
        scsClient.Disconnected += OnDisconnected;

        scsClient.ServiceProxy.RegisterPlayer(client.PlayerInfo);
    }

    void OnConnected(object sender, EventArgs e) {
        Debug.Log("I connected to server");
    }

    void OnDisconnected(object sender, EventArgs e) {
        Debug.Log("I disconnected from server");
    }

}
