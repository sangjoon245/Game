﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    /// <summary>Sends a packet to the server via TCP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    /// <summary>Sends a packet to the server via UDP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    /// <summary>Lets the server know that the welcome message was received.</summary>
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);
            _packet.Write(Client.instance.teamNumber);

            SendTCPData(_packet);
        }
    }

    /// <summary>Sends player input to the server.</summary>
    /// <param name="_inputs"></param>
    public static void PlayerMovement(bool[] _inputs)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach (bool _input in _inputs)
            {
                _packet.Write(_input);
            }
            _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);

            SendUDPData(_packet);
        }
    }

    public static void PlayerShoot(Quaternion _rotation)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerShoot))
        {
            
            _packet.Write(_rotation);

            SendUDPData(_packet);
        }
    }
    
    

    public static void PlayerJump(bool _input)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerJump))
        {
            _packet.Write(_input);
            SendUDPData(_packet);
        }
    }

    public static void PlayerA1(bool _input, bool _recast)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerA1))
        {
            _packet.Write(_input);
            _packet.Write(_recast);
            SendUDPData(_packet);
        }
    }

    public static void PlayerA2(bool _input)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerA2))
        {
            _packet.Write(_input);
            SendUDPData(_packet);
        }
    }

    public static void KillAndRespawn(bool _true)
    {
        using (Packet _packet = new Packet((int)ClientPackets.killAndRespawn))
        {
            _packet.Write(_true);
            SendTCPData(_packet);
        }
    }

    #endregion
}