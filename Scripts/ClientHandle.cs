using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        // Now that we have the client's id, connect UDP
        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();


        GameManager.players[_id].transform.position = _position;
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.players[_id].transform.rotation = _rotation;
    }

    public static void PlayerDisconnected(Packet _packet)
    {
        int _id = _packet.ReadInt();

        Destroy(GameManager.players[_id].gameObject);
        GameManager.players.Remove(_id);
    }


    public static void ProjectilePosition(Packet _packet)
    {

        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();
        int _id = _packet.ReadInt();

        if(GameManager.projectiles[_id] != null)
        {
            GameManager.projectiles[_id].transform.position = _position;
            GameManager.projectiles[_id].transform.rotation = _rotation;
        } else
        {
            Debug.Log(_id + " is NULL!");
        }

        
    }

    public static void BulletRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();
        GameManager.projectiles[_id].transform.rotation = _rotation;

    }

    public static void SpawnProjectile(Packet _packet)
    {

        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();
        int _shotById = _packet.ReadInt();

        GameManager.instance.SpawnProjectile(_id, _position, _rotation, _shotById);
    }

    public static void PlayerHealth(Packet _packet)
    {
        int _id = _packet.ReadInt();
        float _health = _packet.ReadFloat();
        GameManager.instance.SetPlayerHealth(_id, _health);
    }

    public static void PlayerRespawned(Packet _packet)
    {
        int _id = _packet.ReadInt();

        GameManager.players[_id].Respawn();
    }

    public static void ScoreIncrement(Packet _packet) 
    {
        int _teamNumber = _packet.ReadInt();

        GameManager.instance.IncrementPlayerScore(_teamNumber);

    }

    public static void ShadowPosition(Packet _packet)
    {
        Vector3 _position = _packet.ReadVector3();
        int _id = _packet.ReadInt();

        GameManager.instance.ShadowPosition(_position, _id);
    }

    public static void ShadowKill(Packet _packet)
    {
        int _id = _packet.ReadInt();

        GameManager.instance.ShadowKill(_id);
    }

    public static void ShowUsername(Packet _packet) //Dlete this
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();

    }

    public static void StartWaitTimer(Packet _packet)
    {
        int _seconds = _packet.ReadInt();

        GameManager.instance.StartWaitTimer(_seconds);
    }

    public static void PlayerReady(Packet _packet)
    {
        bool _bool = _packet.ReadBool();

        GameManager.instance.SetPlayersReady();
    }

}