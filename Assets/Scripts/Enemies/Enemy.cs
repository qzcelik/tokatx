using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public Slider healthSlider;
    public float health = 0;
    public float damage = 0;
    public EnemyType enemyType = 0;
    public EnemyBehaviour enemyBehaviour = 0;
    public GameObject player;
    public ParticleSystem bloodEffect;
    public GameObject gun;


    private void Start()
    {
        player = Player.instance.GetPlayer();
    }

    public float DistancePlayerAndEnemy()
    {
        return Vector3.Distance(player.transform.position, gameObject.transform.position);
    }

    public void FollowPlayer()
    {
        if (enemyBehaviour == EnemyBehaviour.walk)
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.destination = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + Random.Range(1, 5));
        }
    }

    public void AttackToPlayer(GameObject bullet)
    {
        var enemyBulletInstance = Instantiate(bullet);
        enemyBulletInstance.transform.position = this.transform.position;
        enemyBulletInstance.transform.LookAt(player.transform.position);
        enemyBulletInstance.LeanMove(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), .1f);
        StartCoroutine(AutoDestroyBullet(enemyBulletInstance));
    }

    IEnumerator AutoDestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(.3f);
        Destroy(bullet);
    }



    public void PlayerHealthDown(float damage)
    {
        var playerHealth = Player.instance.GetPlayerHealth();
        playerHealth -= damage;
        Player.instance.SetPlayerHealth(playerHealth);
    }

    public enum EnemyType
    {
        enemy1,
        enemy2,
        enemy3,
    }

    public enum PlayerDistaceControl
    {
        shortDistance = 5,
        middleDistance = 10,
        longDistance = 25,
        veryLongDistance = 100
    }

    public enum EnemyBehaviour
    {
        idle,
        walk,
        attack,
        died

    }
}
