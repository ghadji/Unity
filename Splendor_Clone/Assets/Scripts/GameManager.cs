﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; set; }

    public GameObject mainMenu;
    public GameObject serverMenu;
    public GameObject connectMenu;

    public GameObject serverPrefab;
    public GameObject clientPrefab;

    public InputField nameInput;

    private void Start() {
        Instance = this;
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void ConnectButton() {
        mainMenu.SetActive(false);
        connectMenu.SetActive(true);
    }
    public void HostButton() {
        try {
            Server s = Instantiate(serverPrefab).GetComponent<Server>();
            s.Init();
            
            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.clientName = nameInput.text;
            if (c.clientName == "")
                c.clientName = "Host";
            c.ConnectToServer("127.0.0.1", 6321);
        } catch (Exception e) {
            Debug.Log("Failed to init server: " + e.Message);
        }
        mainMenu.SetActive(false);
        serverMenu.SetActive(true);
    }
    public void ExitButton() {
        Application.Quit();
    }
    public void BackButton() {
        serverMenu.SetActive(false);
        connectMenu.SetActive(false);
        mainMenu.SetActive(true);

        Server s = FindObjectOfType<Server>();
        if (s != null)
            Destroy(s.gameObject);

        Client c = FindObjectOfType<Client>();
        if (c != null)
            Destroy(c.gameObject);
    }

    public void ConnectToServerButton() {
        string hostAddress = GameObject.Find("HostInput").GetComponent<InputField>().text;

        if (hostAddress == "")
            hostAddress = "127.0.0.1";

        try {
            Client c = Instantiate(clientPrefab).GetComponent<Client>();
            c.ConnectToServer(hostAddress, 6321);
            c.clientName = nameInput.text;
            if (c.clientName == "") 
                c.clientName = "Client";
            
            connectMenu.SetActive(false);
        } catch (Exception e) {
            Debug.Log("Error connecting to server: " + e.Message);
        }
    }
}
