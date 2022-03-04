using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public float health;
    public float maxHealth = 100f;
    public MeshRenderer model;


    public HealthBar healthBar;
    public HealthBar healthBarAbove;
    public Score score1;
    public Score score2;
    public RoundTimer timer;
    public Announcer announcertext;
    public GameObject prefabEffect;

    public Username usernametext;

    private float currentTime;
    private float timeBetweenShadows = 0.015f;

    public void Update()
    {
        if(currentTime <= 0)
        {
            Instantiate(prefabEffect, transform.position, transform.rotation);
            currentTime = timeBetweenShadows;
        }
        currentTime -= Time.deltaTime;
        
    }

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        SetUsername(username);
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void SetHealth(float _health)
    {
        health = _health;
        healthBar.SetHealth(_health);
        healthBarAbove.SetHealth(_health);
        if (health <= 0f)
        {
            Die();
        }
    }

    public void SetUsername(string _username)
    {
        usernametext.SetUsername(_username);
    }

    public void SetScoreboard(int _score1, int _score2)
    {
        score1.SetScore(_score1);
        score2.SetScore(_score2);
    }

    public void SetRoundTimer(int _seconds)
    {
        timer.SetTimer(_seconds);
        Debug.Log("Setting timer to " + _seconds);
    }

    public void SetAnnouncerText(string _text)
    {
        announcertext.SetText(_text);
        Debug.Log(_text);
    }

    public void Die()
    {
        model.enabled = false;
    }

    public void Respawn()
    {
        model.enabled = true;
        SetHealth(maxHealth);
    }

    public void SpawnShadow()
    {

    }

    public int GetId()
    {
        return id;
    }
}