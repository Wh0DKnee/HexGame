using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.IO;

public class ServerThread{

    // Stop-Flag
    public bool stop = false;
    // Flag für "Thread läuft"
    public bool running = false;
    // Die Verbindung zum Client
    private TcpClient connection = null;
    // Speichert die Verbindung zum Client und startet den Thread
    public ServerThread(TcpClient connection) {
        // Speichert die Verbindung zu Client,
        // um sie später schließen zu können
        this.connection = connection;
        // Initialisiert und startet den Thread
        new Thread(new ThreadStart(Run)).Start();
    }

    // Der eigentliche Thread
    public void Run() {
        // Setze Flag für "Thread läuft"
        this.running = true;
        // Hole den Stream für's schreiben
        Stream outStream = this.connection.GetStream ();
        String buf = null;
        bool loop = true;
        while (loop) {
            try {
                String time = DateTime.Now.ToString ();
                if (!time.Equals(buf)) {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes ( time + "\r\n" );
                    outStream.Write(sendBytes, 0, sendBytes.Length);
                    buf = time;
                }
                loop = !this.stop;
            } catch (Exception) {
                loop = false;
            }
        }
        this.connection.Close();
        this.running = false;
    }
}
