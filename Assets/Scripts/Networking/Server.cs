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

	public Server(int port) {
        serviceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(port));
        service = new Service();
        serviceApplication.AddService<IServiceProxy, Service>(service);

        serviceApplication.ClientConnected += ClientConnected;
        serviceApplication.ClientDisconnected += ClientDisconnected;
	}

    private void ClientConnected(object sender, ServiceClientEventArgs e) {
        Debug.Log("client connected: " + e.Client.ClientId);
        if (e.Client.ClientId == 2) {    //this is shit code. What it's supposed to do is start the game when two players are connected
                                        //however, we should not rely on the clientId.
                                        //TODO: use the Service.GetClientCount() method. The problem right now is that the ClientConnected event
                                        //is fired before the client calls the register method, and therefore here, the client count is not correct
            service.ChangeScene("gameScene");
        }
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
