using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.Scs.Client;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.ScsServices.Client;
using System;

public class MyClient : MonoBehaviour {

    IScsClient client;

	void Start () {
        client = ScsClientFactory.CreateClient(new ScsTcpEndPoint("127.0.0.1",100));

        client.MessageReceived += MessageReceived;

        client.Connect();
        client.SendMessage(new ScsTextMessage("hi"));
	}

    private void OnApplicationQuit() {
        client.Disconnect();
    }

    private void OnMouseDown() {
        client.SendMessage(new ScsTextMessage("move"));
    }

    private void MessageReceived(object sender, MessageEventArgs e) {
        var message = e.Message as ScsTextMessage;

        if(message == null) {
            return;
        }

        print("server sent message: " + message.Text);
    }
}
