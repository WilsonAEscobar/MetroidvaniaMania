using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth: MonoBehaviour 
{
    public int maxHealth = 10;
    public int health;

    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LevelSelection");
        }
    }

}
