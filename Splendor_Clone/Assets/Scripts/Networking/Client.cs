using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class Client : MonoBehaviour {
    public string clientName;

    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;

    public bool ConnectToServer(string host, int port) {
        if (socketReady)
            return false;

        try {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            socketReady = true;
        } catch (Exception e) {
            Debug.Log("Socket error: " + e.Message);
        }

        return socketReady;
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (socketReady) {
            if (stream.DataAvailable) {
                string data = reader.ReadLine();
                if (data != null) {
                    OnIncomingData(data);
                    Send(data);
                }
            }
        }
    }

    //sending messages to the server
    public void Send(string data) {
        if (!socketReady)
            return;

        writer.WriteLine(data);
        writer.Flush();
    }

    //read messages from server
    private void OnIncomingData(string data) {
        Debug.Log(data);
    }

    private void OnApplicationQuit() {
        CloseSocket();
    }
    private void OnDisable() {
        CloseSocket();
    }
    private void CloseSocket() {
        if (!socketReady)
            return;

        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }
}

public class GameClient {
    //add any info regarding player
    public string name;
    public bool isHost;
    public Color color;
}
