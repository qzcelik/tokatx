using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public float speed = 0;
    public float health = 0;

    public static Player instance;
    private void Awake()
    {
        instance = this;
    }
     
    public GameObject GetPlayer()
    {
        return player;
    }

    public float GetPlayerHealth()
    {
        return health;
    }

    public void SetPlayerHealth(float health)
    {
        this.health = health;
    }

}
