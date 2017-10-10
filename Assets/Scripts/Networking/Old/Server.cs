using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

public class Server : MonoBehaviour {

    public GameObject clientPrefab;
    private static TcpListener listener;
    private static ArrayList threads = new ArrayList();
    Thread mainThread;

    private void Start() {
        listener = new TcpListener(IPAddress.Any, 100);
        listener.Start();

        mainThread = new Thread(new ThreadStart(Run));
        mainThread.Start();
    }

    private void Update() {
        if (!Input.GetKeyDown(KeyCode.Escape)) {
            return;
        }

        mainThread.Abort();
        for (IEnumerator e = threads.GetEnumerator(); e.MoveNext();) {
            ServerThread st = (ServerThread) e.Current;
            st.stop = true;
            while (st.running) {
                Thread.Sleep(1000);
            }
        }
        listener.Stop();
    }

    public static void Run() {
        while (true) {
            TcpClient c = listener.AcceptTcpClient();
            threads.Add(new ServerThread(c));
        }
    }

    /*
    private static byte[] buffer = new byte[1024];
    public static List<Socket> clientSockets = new List<Socket>();
    private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    private void Start() {
        Init();
    }

    public static void Init() {
        print("initializing server...");
        serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
        serverSocket.Listen(5);
        serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
    }

    private static void AcceptCallback(IAsyncResult ar) {
        Socket socket = serverSocket.EndAccept(ar);
        clientSockets.Add(socket); // why is this only called once, even if I add multiple clients?
        print("client connected");

        print(clientSockets.Count);
        socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);

        serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
    }

    private static void ReceiveCallback(IAsyncResult ar) {
        Socket socket = (Socket)ar.AsyncState;
        int received = socket.EndReceive(ar);

        byte[] dataBuff = new byte[received];
        Array.Copy(buffer, dataBuff, received);

        string text = Encoding.ASCII.GetString(dataBuff);
        print("text received: " + text);

        string response = string.Empty;

        if(text.ToLower() != "get time") {
            response = "invalid request";
        } else {
            response = DateTime.Now.ToLongDateString();
        }

        byte[] data = Encoding.ASCII.GetBytes(response);

        foreach (Socket s in clientSockets) {
            s.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), s);
        }
        foreach (Socket s in clientSockets) {
            s.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), s);
        }
        //socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
        //socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
    }

    private static void SendCallback(IAsyncResult ar) {
        Socket socket = (Socket)ar.AsyncState;
        socket.EndSend(ar);
    }*/

}