using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public static Dictionary<int, ProjectileManager> projectiles = new Dictionary<int, ProjectileManager>();

    const int SHADOW_ID = 1000000;

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject projectilePrefab;
    public GameObject shadowPrefab;
    public GameObject sampleStage;

    public float timeBetweenRounds;
    public float currentTimeBetweenRounds;
    public float currentTime;

    public bool roundStarted = false;
    public bool playersReady;
    public bool firstRound = true;
    
    private GameObject currentshadow;

    int score1 = 0;
    int score2 = 0;

    private void Awake()
    {
        score1 = 0;
        score2 = 0;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
        playersReady = false;
    }

    private void FixedUpdate()
    {
        currentTimeBetweenRounds -= Time.deltaTime;
        if (playersReady == true)
        {
            RoundClock();
        }

    }

    /// <summary>Spawns a player.</summary>
    /// <param name="_id">The player's ID.</param>
    /// <param name="_name">The player's name.</param>
    /// <param name="_position">The player's starting position.</param>
    /// <param name="_rotation">The player's starting rotation.</param>
    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
            SoundManagerScript.PlayMusic("Music1");
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().Initialize(_id, _username);
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public void SpawnProjectile(int _id, Vector3 _position, Quaternion _rotation, int _shotById) //Change name to knives later
    {
        GameObject _projectile;
        //Maybe we don't need ID? Let's see...
        _projectile = Instantiate(projectilePrefab, _position, _rotation);
        _projectile.GetComponent<Projectile>().IgnorePlayer(_shotById);
        _projectile.GetComponent<ProjectileManager>().Initialize(_id);
        projectiles.Add(_id, _projectile.GetComponent<ProjectileManager>());
        

    }

    public void SetPlayerHealth(int _id, float _health)
    {
        players[_id].SetHealth(_health);
    }

    public void SetPlayerUsername(int _id, string _username)
    {

    }

    public void IncrementPlayerScore(int _teamNumber)
    {
        if(_teamNumber == 1)
        {
            score1++;
        }
        if(_teamNumber == 2)
        {
            score2++;
        }
        players[Client.instance.myId].SetScoreboard(score1, score2);

    }

    public void StartWaitTimer(int _seconds)
    {
        if(firstRound == true)
        {
            SoundManagerScript.PlaySound("GameStart");
            firstRound = false;
        } else
        {
            SoundManagerScript.PlaySound("NextRound");
        }
        roundStarted = false;
        players[Client.instance.myId].SetRoundTimer(_seconds);
        currentTimeBetweenRounds = _seconds;
        players[Client.instance.myId].SetAnnouncerText("READY UP");
    }

    public void EraseAnnouncerText()
    {
        players[Client.instance.myId].SetAnnouncerText("");
    }


    public void ShadowPosition(Vector3 position, int _id)
    {
        GameObject _shadow;
        //Maybe we don't need ID? Let's see...
        _shadow = Instantiate(shadowPrefab, position, Quaternion.identity);

        _shadow.GetComponent<ProjectileManager>().Initialize(_id + SHADOW_ID);
        _shadow.GetComponent<ProjectileManager>().SetType(10002);
        projectiles.Add(_id + SHADOW_ID, _shadow.GetComponent<ProjectileManager>());

    }

    public void ShadowKill(int _id)
    {

        projectiles[_id + SHADOW_ID].Destroy();
        projectiles.Remove(_id + SHADOW_ID);

    }

    public void RoundClock()
    {
        if (currentTimeBetweenRounds <= 0)
        {
            currentTimeBetweenRounds = 0;
            if (roundStarted == false)
            {
                players[Client.instance.myId].SetAnnouncerText("GO!");
                Invoke("EraseAnnouncerText", 4f);
                roundStarted = true;
            }
        }
    }

    public void SetPlayersReady()
    {
        playersReady = true;
    }




}