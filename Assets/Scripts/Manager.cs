using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static private NetworkManager m_NetworkManager;
    public int numPlayers;
    public int maxPlayers = 4;

    void Awake()
    {
        m_NetworkManager = GetComponent<NetworkManager>();
        numPlayers = 0;
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!m_NetworkManager.IsClient && !m_NetworkManager.IsServer)
        {
            StartButtons();
        }
        else
        {
            StatusLabels();
            GUILayout.Label("Players: " + numPlayers + "/" + maxPlayers);
            SubmitNewPosition();
            getInput();
        }

        GUILayout.EndArea();
    }

    static void StartButtons()
    {
        if (GUILayout.Button("Host")) m_NetworkManager.StartHost();
        if (GUILayout.Button("Client")) m_NetworkManager.StartClient();
        if (GUILayout.Button("Server")) m_NetworkManager.StartServer();
    }

    static void StatusLabels()
    {
        var mode = m_NetworkManager.IsHost ?
            "Host" : m_NetworkManager.IsServer ? "Server" : "Client";

        GUILayout.Label("Transport: " +
            m_NetworkManager.NetworkConfig.NetworkTransport.GetType().Name);
        GUILayout.Label("Mode: " + mode);
    }

    static void SubmitNewPosition()
    {
        if (GUILayout.Button(m_NetworkManager.IsServer ? "Move" : "Request Position Change"))
        {
            if (m_NetworkManager.IsServer && !m_NetworkManager.IsClient)
            {
                foreach (ulong uid in m_NetworkManager.ConnectedClientsIds)
                  m_NetworkManager.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<PlayerScript>().RandomMove();
            }
            else
            {
                var playerObject = m_NetworkManager.SpawnManager.GetLocalPlayerObject();
                var player = playerObject.GetComponent<PlayerScript>();
                player.RandomMove();
            }
        }
    }

    static void getInput()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Horizontal") != 0))
            {
                if (m_NetworkManager.IsServer && !m_NetworkManager.IsClient)
                {
                    foreach (ulong uid in m_NetworkManager.ConnectedClientsIds)
                            m_NetworkManager.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<PlayerScript>().Move();
                }
                else
                {
                        var playerObject = m_NetworkManager.SpawnManager.GetLocalPlayerObject();
                        var player = playerObject.GetComponent<PlayerScript>();
                        player.Move();
                    
                }
            }
    }

    private void Update()
    {
        if (m_NetworkManager.IsServer)
        {
            numPlayers = m_NetworkManager.ConnectedClients.Count;
        }
    }

}
