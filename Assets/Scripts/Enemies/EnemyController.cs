using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Enemy
{
    [SerializeField]
    private GameObject enemyBullet;
    public Animator enemyAnimator;
    bool deadControl = true;
    private void Start()
    {
        StartCoroutine(DistanceControl());
        EnemyBullet.OnPlayerHealth += PlayerHealthDown;
    }

    private IEnumerator DistanceControl()
    {
        while (deadControl)
        {
            if(enemyBehaviour == EnemyBehaviour.died)
            {
                gun.SetActive(false);
                deadControl = false;
                break;
            }

            enemyAnimator.SetTrigger("run");
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));

            float distance = DistancePlayerAndEnemy();

            if (distance < (float)PlayerDistaceControl.longDistance)
            {
                AttackToPlayer(enemyBullet);
            }
            FollowPlayer();
        }
    }

   

}
