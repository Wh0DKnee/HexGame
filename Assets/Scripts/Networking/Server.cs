using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.ScsServices.Service;
using Hik.Communication.ScsServices.Client;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Server;
using NetworkingCommonLib;

public class Server : MonoBehaviour {

    IScsServiceApplication server;
    Service service;
    readonly int port = 100;

	// Use this for initialization
	public void StartServer () {
        server = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(port));
        service = new Service();
        server.AddService<IServiceProxy, Service>(service);

        server.ClientConnected += ClientConnected;
        server.ClientDisconnected += ClientDisconnected;

        server.Start();
	}

    private void ClientConnected(object sender, ServiceClientEventArgs e) {
        Debug.Log("client connected: " + e.Client.ClientId);
    }

    private void ClientDisconnected(object sender, ServiceClientEventArgs e) {
        Debug.Log("client disconnected: " + e.Client.ClientId);
    }

    private void OnApplicationQuit() {
        server.Stop();
    }

}
