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
        StartServer();
        CreateLocalClient();
        ConnectClient();
    }

	private void StartServer() {
        networkSession.Server = new Server(100);
        networkSession.StartServer();
    }

    private void CreateLocalClient() {
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
        if (networkSession.Client.TryConnect()) {
            networkSession.Client.Register();
        }
    }
}
