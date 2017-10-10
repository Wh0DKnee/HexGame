using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.IO;


public class Client : MonoBehaviour {

    TcpClient c;
    StreamReader inStream;

    private void Start() {
        c = new TcpClient ( "localhost", 100 );
        // Stream zum lesen holen
        inStream = new StreamReader ( c.GetStream () );
        
    }

    private void Update() {
        bool loop = !Input.GetKeyDown(KeyCode.Space);
        if (loop) {
            try {
                String time = inStream.ReadLine ();
                loop = !time.Equals("");
                print(time);
            } catch (Exception) {
                loop = false;
            }
            return;
        }
        c.Close();
    }

    /*private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    private void Start() {
        LoopConnect();
    }

    private void OnMouseDown() {
        byte[] buffer = Encoding.ASCII.GetBytes("get time");
        clientSocket.Send(buffer);

        byte[] receivedBuffer = new byte[1024];
        int rec = clientSocket.Receive(receivedBuffer);
        byte[] data = new byte[rec];
        Array.Copy(receivedBuffer, data, rec);
        print(name + " received: "+ Encoding.ASCII.GetString(data));
    }

    private static void LoopConnect() {

        int attempts = 0;

        while (!clientSocket.Connected) {
            try {
                attempts++;
                clientSocket.Connect(IPAddress.Loopback, 100);
            } catch (SocketException ex) {
                print("connection attempts: " + attempts);
            }
        }

        print("connected");
    }*/
}
