using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hik.Communication.ScsServices.Service;
using Hik.Communication.ScsServices.Client;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Server;
using NetworkingCommonLib;

public class Server{

    IScsServiceApplication serviceApplication;
    Service service;

	// Use this for initialization
	public Server(int port) {
        serviceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(port));
        service = new Service();
        serviceApplication.AddService<IServiceProxy, Service>(service);

        serviceApplication.ClientConnected += ClientConnected;
        serviceApplication.ClientDisconnected += ClientDisconnected;
	}

    private void ClientConnected(object sender, ServiceClientEventArgs e) {
        Debug.Log("client connected: " + e.Client.ClientId);
    }

    private void ClientDisconnected(object sender, ServiceClientEventArgs e) {
        Debug.Log("client disconnected: " + e.Client.ClientId);
    }

    public void Start() {
        serviceApplication.Start();
    }

    public void Stop() {
        serviceApplication.Stop();
    }

}
