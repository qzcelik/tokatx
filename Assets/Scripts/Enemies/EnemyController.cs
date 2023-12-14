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
    bool detectedPlayer = false;
    public PlayerDistaceControl playerDistaceControl;
    AnimatorStateInfo animatorStateInfo;
    private void Start()
    {
        StartCoroutine(DistanceControl());

        EnemyBullet.OnPlayerHealth += PlayerHealthDown;
        enemyAnimator.SetTrigger("idle");

    }

    private IEnumerator DistanceControl()
    {
        while (deadControl)
        {
            animatorStateInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.IsName("idle") && animatorStateInfo.normalizedTime >= 1.0f && !detectedPlayer)
            {
                enemyAnimator.SetTrigger("idle");
            }

            float distance = DistancePlayerAndEnemy();

            if (enemyBehaviour == EnemyBehaviour.died)
            {
                gun.SetActive(false);
                deadControl = false;
                break;
            }

            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));


            if (distance < (float)playerDistaceControl)
            {
                detectedPlayer = true;
            }


            if (detectedPlayer)
            {
                enemyAnimator.SetTrigger("run");
                AttackToPlayer(enemyBullet);
                FollowPlayer();
            }
        }
    }



}
