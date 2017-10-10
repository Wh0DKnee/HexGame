using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Server;
using Hik.Collections;
using System;

public class MyServer : MonoBehaviour {

    IScsServer server;

	// Use this for initialization
	void Start () {
        server = ScsServerFactory.CreateServer(new ScsTcpEndPoint(100));

        server.ClientConnected += ClientConnected;
        server.ClientDisconnected += ClientDisconnected;

        server.Start();

        print("server started");
	}

    private void ClientDisconnected(object sender, ServerClientEventArgs e) {
        print("client disconnected: " + e.Client.ClientId);
    }

    private void ClientConnected(object sender, ServerClientEventArgs e) {
        print("client connected: " + e.Client.ClientId);

        e.Client.MessageReceived += MessageReceived;
    }

    private void OnApplicationQuit() {
        server.Stop();
    }

    private void MessageReceived(object sender, MessageEventArgs e) {
        var message = e.Message as ScsTextMessage;
        if(message == null) {
            return;
        }

        ScsTextMessage response = new ScsTextMessage();

        var client = sender as IScsServerClient;

        print("client " + client.ClientId + " sent message: " + message.Text);

        if(message.Text == "move") {
            response.Text = "moving";
            Broadcast(response);
        } else {
            response.Text = "yo";
            client.SendMessage(response);
        }
    }

    private void Broadcast(ScsTextMessage msg) {
        foreach (IScsServerClient client in server.Clients.GetAllItems()) {
            client.SendMessage(msg);
        }
    }
}
