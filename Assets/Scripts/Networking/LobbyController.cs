using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hik.Communication.ScsServices.Service;

public class LobbyController : MonoBehaviour {

    public NetworkSession networkSession;

    public InputField hostNick;
    public InputField connectorNick;
    public InputField IP;
    public InputField connectorPort;

    public void HostLocal() {
        Debug.Log("host local clicked");
        StartServer();
        CreateLocalClient();
        ConnectClient();
    }

	private void StartServer() {
        Debug.Log("starting server");
        networkSession.Server = new Server(100);
        networkSession.StartServer();
    }

    private void CreateLocalClient() {
        Debug.Log("creating local client");
        networkSession.Client = new Client("127.0.0.1", 100, hostNick.text);
    }

    public void OnConnectButtonPressed() {
        networkSession.Server = null;
        CreateRemoteClient();
        ConnectClient();
    }

    private void CreateRemoteClient() {
        networkSession.Client = new Client(IP.text, int.Parse(connectorPort.text), connectorNick.text);
    }

    private void ConnectClient() {
        Debug.Log("trying to connect client");
        if (networkSession.Client.TryConnect()) {
            Debug.Log("client connected");
            networkSession.Client.Register();
        }
    }
}
