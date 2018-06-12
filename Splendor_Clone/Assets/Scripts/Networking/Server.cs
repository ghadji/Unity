using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;

public class Server : MonoBehaviour {

    public int port = 6321;

    //connected clients
    private List<ServerClient> clients;
    //which clients to disconnect
    private List<ServerClient> disconnectList;

    private TcpListener server;
    public bool serverStarted;

    public void Init() {
        DontDestroyOnLoad(gameObject);

        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try {
            //accept connection from any ip as long as they are connect to the specified port
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            StartListening();
            serverStarted = true;
        } catch (Exception e) {
            Debug.Log("Socket error: " + e.Message);
        }
    }
    private void Update() {
        if (!serverStarted)
            return;

        foreach (ServerClient c in clients) {
            //is the client still connected?
            if (!IsConnected(c.tcp)) {
                c.tcp.Close();
                disconnectList.Add(c);
                continue;
            } else {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable) {
                    StreamReader reader = new StreamReader(s, true);
                    string data = reader.ReadLine();

                    if (data != null) {
                        OnIncomingData(c, data);
                    }
                }
            }
        }

        for (int i = 0; i < disconnectList.Count - 1; i++) {
            //tell our player that somebody has disconnected

            clients.Remove(disconnectList[i]);
            disconnectList.RemoveAt(i);
        }
    }

    private void StartListening() {
        //Execute the handshake between server - client
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }
    private void AcceptTcpClient(IAsyncResult ar) {
        //grab the listener of the new connected client, store it in our client and 
        //add it to our list of the connected clients
        TcpListener listener = (TcpListener)ar.AsyncState;

        ServerClient sc = new ServerClient(listener.EndAcceptTcpClient(ar));
        clients.Add(sc);

        //continue listening
        StartListening();

        Debug.Log("Someone has connected!");
    }

    private bool IsConnected(TcpClient c) {
        try {
            if (c != null && c.Client != null && c.Client.Connected) {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);

                return true;
            } else {
                return false;
            }
        } catch {
            return false;
        }
    }

    //Server send
    private void Broadcast(string data, List<ServerClient> cl) {
        foreach(ServerClient sc in cl) {
            try {
                StreamWriter writer = new StreamWriter(sc.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();
            }catch(Exception e) {
                Debug.Log("Write error: " + e.Message);
            }
        }
    }
    //Server read
    private void OnIncomingData(ServerClient c, string data) {
        Debug.Log(c.clientName + ": " + data);
    }
}

public class ServerClient {
    public string clientName;
    public TcpClient tcp;

    public ServerClient(TcpClient tcp) {
        this.tcp = tcp;
    }
}
